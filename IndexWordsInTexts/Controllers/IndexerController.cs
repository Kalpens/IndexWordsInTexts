using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IndexWordsInTexts.Controllers
{
    public class IndexerController : IIndexerController
    {
        public Task<IHttpActionResult> IndexSearchWord(SearchWords searchWord)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpActionResult> IndexText(Texts text)
        {
            throw new NotImplementedException();
        }
    }
}
