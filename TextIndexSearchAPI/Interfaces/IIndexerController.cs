using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WordIndexer.Entites;

namespace TextIndexSearchAPI
{
    public interface IIndexerController
    {
        /// <summary>
        /// The controller should call the IndexSearchWord method. See IIndexer interface.
        /// </summary>
        /// <param name="searchWord">
        /// The given SearchWord to be indexed.
        /// </param>
        /// <returns>
        /// If the IndexSearchWord method returns false, then the controller method should return BadRequest.
        /// If the IndexSearchWord method returns true, then the controller method should return OK.
        /// </returns>
        Task<IHttpActionResult> IndexSearchWord(SearchWords searchWord);
        /// <summary>
        /// The controller should call the IndexText method. See IIndexer interface.
        /// </summary>
        /// <param name="text">
        /// The given Text object to be indexed.
        /// </param>
        /// <returns>
        /// If the IndexText method returns false, then the controller method should return BadRequest.
        /// If the IndexText method returns true, then the controller method should return OK.
        /// </returns>
        Task<IHttpActionResult> IndexText(Texts text);
    }
}
