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
    public class IndexerController : ApiController, IIndexerController
    {
        [HttpPost]
        public Task<IHttpActionResult> IndexSearchWord(SearchWords searchWord)
        {
            return Task.Run(() =>
            {
                var logic = new Indexer();
                bool result = logic.IndexSearchWord(searchWord);
                return (IHttpActionResult)Ok(result);

            });
        }
        [HttpPost]
        public Task<IHttpActionResult> IndexText(Texts text)
        {
            return Task.Run(() =>
            {
                var logic = new Indexer();
                bool result = logic.IndexText(text);
                return (IHttpActionResult)Ok(result);

            });
        }
    }
}
