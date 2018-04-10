using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WordIndexer.Entites;
using WordIndexer.Interfaces;

namespace WordIndexer.Logic
{
    public class Indexer : IIndexer
    {
        /// <summary>
        /// Indexes the text into database,
        /// if contains searchwords, they all are indexed after adding the text to db.
        /// Updates the existing searchwords to link to this text
        /// </summary>
        /// <param name="text">
        /// Provided text to be indexed
        /// </param>
        /// <returns>
        /// boolean with value depending if text indexing was succesfull
        /// </returns>
        public bool IndexText(Texts text)
        {
            try
            {
                using (var db = new SearcherContext())
                {
                    //Storing searchwords before adding text to db
                    var listOfSearchwordsToAdd = text.SearchWords;
                    text.SearchWords = null;
                    db.Texts.Add(text);
                    //new text added to db
                    db.SaveChanges();
                    //If it contained searchwords, now they will be indexed.
                    if (listOfSearchwordsToAdd.Count > 0)
                    {
                        foreach (var searchWord in listOfSearchwordsToAdd)
                        {
                            IndexSearchWord(searchWord);
                        }
                    }
                    //finding all searchwords that are in text
                    var searchwords = db.SearchWords.Where(s => text.text.Contains(s.SearchWord)).ToList();
                    //Updating these searchwords in database
                    foreach (var searchword in searchwords)
                    {
                        IndexSearchWord(searchword);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Indexes a searchword, finds all texts containig it and adds 
        /// a connection to database between seachword and text.
        /// </summary>
        /// <param name="searchword">
        /// Provided searchword
        /// </param>
        /// <returns>
        /// boolean with value depending if indexing was succesfull
        /// </returns>
        public bool IndexSearchWord(SearchWords searchword)
        {
            try
            {
                using (var db = new SearcherContext())
                {
                    //List of texts containing searchword
                    List<Texts> texts = db.Texts.Where(t => t.text.Contains(searchword.SearchWord))
                        .Include(t => t.SearchWords)
                        .ToList();
                    foreach (var text in texts)
                    {
                        bool update = true;
                        //For each loop checks if there is already such searchword for this text
                        foreach (var searchWordInText in text.SearchWords)
                        {
                            if (searchWordInText.SearchWord.Contains(searchword.SearchWord))
                            {
                                update = false;
                            }
                        }
                        //If there is no such search word for text, it is indexed
                        if (update)
                        {
                            //Fiding the actual searchword from table
                            SearchWords existingSearchword =
                                db.SearchWords.FirstOrDefault(s => s.SearchWord.Equals(searchword.SearchWord));
                            if (existingSearchword != null)
                            {
                                text.SearchWords.Add(existingSearchword);
                                db.Entry(text).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                            else
                            {
                                text.SearchWords.Add(searchword);
                                db.Entry(text).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
