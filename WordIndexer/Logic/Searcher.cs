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
        public List<Texts> SearchTextsWithString(string searchword)
        {
            using (var db = new SearcherContext())
            {
                return (from c in db.Texts
                    where c.SearchWords.Contains(c.SearchWords.FirstOrDefault(x => x.SearchWord == searchword))
                    select c)
                    //For now I do not include searchwords, as tey cause endless loop, as they also have words, who also have search words etc..
                    //.Include(texts => texts.SearchWords)
                    .ToList();
            }

        }

        public List<string> SearchTextsWithList(List<string> searchwords)
        {
            throw new NotImplementedException();
        }
    }
}