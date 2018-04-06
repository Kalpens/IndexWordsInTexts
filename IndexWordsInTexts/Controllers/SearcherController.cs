using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IndexWordsInTexts.Controllers
{
    public class SearcherController : ISearcherController
    {
        public Task<IHttpActionResult> SearchTextsWithString(SearchWords searchWord)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpActionResult> SearchTextsWithList(List<SearchWords> searchWords)
        {
            throw new NotImplementedException();
        }
    }
}
