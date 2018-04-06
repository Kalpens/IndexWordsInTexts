using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WordIndexer.Entites;
using WordIndexer.Logic;

namespace TextIndexSearchAPI.Controllers
{
    public class SearcherController : ApiController//, ISearcherController
    {
        [HttpGet]
        public Task<IHttpActionResult> SearchTextsWithString(string searchWord)
        {
            return Task.Run(() =>
            {
                var logic = new Searcher();
                var texts = logic.SearchTextsWithString(searchWord);

                return (IHttpActionResult)Ok(texts);
            });
        }
        [HttpGet]
        public Task<IHttpActionResult> SearchTextsWithList(List<SearchWords> searchWords)
        {
            throw new NotImplementedException();
        }
    }
}
