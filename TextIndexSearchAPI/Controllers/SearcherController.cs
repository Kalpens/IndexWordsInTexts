using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TextIndexSearchAPI.Interfaces;
using WordIndexer.Entites;
using WordIndexer.Logic;

namespace TextIndexSearchAPI.Controllers
{
    public class SearcherController : ApiController, ISearcherController
    {
        [HttpPost]
        public Task<IHttpActionResult> SearchTextsWithString(SearchWords searchWord)
        {
            return Task.Run(() =>
            {
                var logic = new Searcher();
                var texts = logic.SearchTextsWithString(searchWord.SearchWord);

                return (IHttpActionResult)Ok(texts);
            });
        }
        [HttpPost]
        public Task<IHttpActionResult> SearchTextsWithList(List<SearchWords> searchWords)
        {
            return Task.Run(() =>
            {
                var logic = new Searcher();
                var stringList = new List<string>();
                foreach (var searchWord in searchWords)
                {
                    stringList.Add(searchWord.SearchWord);
                }
                var strings = logic.SearchTextsWithList(stringList);

                return (IHttpActionResult)Ok(strings);
            });
        }
    }
}
