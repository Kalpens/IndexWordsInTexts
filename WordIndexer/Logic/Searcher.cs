using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WordIndexer.Entites;
using WordIndexer.Interfaces;

namespace WordIndexer.Logic
{
    public class Searcher : ISearcher
    {

        /// <summary>
        /// Searches for texts in db who are linked to searchword with
        /// equal word as provided parameter
        /// </summary>
        /// <param name="searchword">
        /// provided string with 
        /// </param>
        /// <returns>
        /// List of texts linked to searchwords
        /// </returns>
        public List<Texts> SearchTextsWithString(string searchword)
        {
            using (var db = new SearcherContext())
            {
                return (from t in db.Texts
                    where t.SearchWords.Contains(t.SearchWords.FirstOrDefault(x => x.SearchWord == searchword))
                    select t)
                    //For now I do not include searchwords, as they cause endless loop in json or xml,
                    //as they also have words, who also have search words etc..
                    //.Include(texts => texts.SearchWords)
                    .ToList();
            }

        }

        /// <summary>
        /// Searches for texts that are linked to provided parameter
        /// in database
        /// </summary>
        /// <param name="searchwords">
        /// Provided list of searchwords
        /// </param>
        /// <returns>
        /// Empty list if exception occured or if no results found,
        /// List with strings sorted descening by occurance of searchwords in text
        /// </returns>
        public List<string> SearchTextsWithList(List<string> searchwords)
        {
            try
            {
                using (var db = new SearcherContext())
                {
                    List<Texts> listOfFoundTexts = new List<Texts>();
                    Dictionary<int, int> textsWithSearchwordCount = new Dictionary<int, int>();
                    //Foreach loop for provided list of words
                    foreach (var searchword in searchwords)
                    {
                        //Finding list of text for item in list
                        var textList = (from c in db.Texts
                            where c.SearchWords.Contains(c.SearchWords.FirstOrDefault(x => x.SearchWord == searchword))
                            select c).ToList();
                        //going throught every text in found list
                        foreach (var text in textList)
                        {
                            //If dictionary has the key of found text id, then adds to its value
                            if (textsWithSearchwordCount.ContainsKey(text.id))
                            {
                                textsWithSearchwordCount[text.id] += 1;
                            }
                            //If dictionary has no key of found text id, then adds key and value of 1
                            else
                            {
                                textsWithSearchwordCount.Add(text.id, 1);
                                listOfFoundTexts.Add(text);
                            }
                        }
                    }
                    //Descending sorting of values in dictionary
                    var items = from pair in textsWithSearchwordCount
                                orderby pair.Value descending 
                        select pair;
                    List<string> listOfFoundStrings = new List<string>();
                    foreach (KeyValuePair<int, int> pair in items)
                    {
                        //Adding the strings from texts to list in previously sorted manner
                        listOfFoundStrings.Add(listOfFoundTexts.FirstOrDefault(t => t.id == pair.Key).text);
                    }
                    
                    return listOfFoundStrings;
                }
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
    }
}