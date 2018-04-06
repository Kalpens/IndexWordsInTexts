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
