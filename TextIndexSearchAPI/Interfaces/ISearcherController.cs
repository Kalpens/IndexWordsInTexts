using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WordIndexer.Entites;

namespace TextIndexSearchAPI.Interfaces
{
    public interface ISearcherController
    {
        /// <summary>
        /// The controller should call the SearchTextWithString method. See ISearcher Interface.
        /// </summary>
        /// <param name="searchWord">
        /// The given SearchWords object to be passed as parameter to the SearchTextWithString method
        /// </param>
        /// <returns>
        ///  Always return OK with a list of text as a result. If the list is empty just return the empty list
        /// </returns>
        Task<IHttpActionResult> SearchTextsWithString(SearchWords searchWord);
        /// <summary>
        /// The controller should call the SearchTextWithList method. See ISearcher Interface.
        /// </summary>
        /// <param name="searchWords">
        /// The given List of SearchWords objects to be passed as parameter to the SearchTextWithString method
        /// </param>
        /// <returns>
        ///  Always return OK with a list of text as a result. If the list is empty just return the empty list. we gotchu fam!
        /// </returns>
        Task<IHttpActionResult> SearchTextsWithList(List<SearchWords> searchWords);
    }
}
