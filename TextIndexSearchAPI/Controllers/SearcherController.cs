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
        /// <summary>
        /// Calls Searcher class SearchTextsWithString method
        /// </summary>
        /// <param name="searchWord">
        /// Given searchword with whom texts are searched
        /// </param>
        /// <returns>
        /// HttpActionResult with a list of found texts, 
        /// if non are found, then returns empty list
        /// </returns>
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
        /// <summary>
        /// Calls Searcher class SearchTextsWithList method
        /// </summary>
        /// <param name="searchWords">
        /// Given list of Searchwords
        /// </param>
        /// <returns>
        /// HttpActionResult with List of strings sorted descending by 
        /// how many relations they have to provided parameters
        /// or empty list if non found
        /// </returns>
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
