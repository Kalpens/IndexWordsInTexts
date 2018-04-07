using System;
using WordIndexer.Entites;
using WordIndexer.Interfaces;

namespace WordIndexer.Logic
{
    public class Indexer : IIndexer
    {
        public bool IndexText(Texts text)
        {
            try
            {
                using (var db = new SearcherContext())
                {
                    //This is alright, it adds text into table, if it has pre attached searchwords, then it also adds them.
                    //In future it would be nice adding the searchwords to the text before adding text into db
                    db.Texts.Add(text);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IndexSearchWord(SearchWords searchword)
        {
            try
            {
                using (var db = new SearcherContext())
                {
                    //This is wrong, it should also establish a connection between text and searchword, 
                    //not only add it into searchwords table
                    db.SearchWords.Add(searchword);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
