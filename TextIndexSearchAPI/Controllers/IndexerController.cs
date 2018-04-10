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
    public class IndexerController : ApiController, IIndexerController
    {
        [HttpPost]
        public Task<IHttpActionResult> IndexSearchWord(SearchWords searchWord)
        {
            return Task.Run(() =>
            {
                var logic = new Indexer();
                bool result = logic.IndexSearchWord(searchWord);
                if (result)
                {
                    return (IHttpActionResult) Ok(result);
                }
                else
                {
                    return BadRequest(result.ToString());
                }

            });
        }
        [HttpPost]
        public Task<IHttpActionResult> IndexText(Texts text)
        {
            return Task.Run(() =>
            {
                var logic = new Indexer();
                bool result = logic.IndexText(text);
                if (result)
                {
                    return (IHttpActionResult)Ok(result);
                }
                else
                {
                    return BadRequest(result.ToString());
                }

            });
        }
    }
}
