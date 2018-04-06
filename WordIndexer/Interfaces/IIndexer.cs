using WordIndexer.Entites;

namespace WordIndexer.Interfaces
{
    interface IIndexer
    {
        /// <summary>
        /// This method should find all the SearchWords in the database that the given text contains.
        /// For each searchword found, a relation should be saved in the TextSearchword table.
        /// </summary>
        /// <param name="text">
        /// The text represents a newly created Text object
        /// </param>
        /// <returns>
        /// A boolean that determines whether the indexing was succesful or not.
        /// </returns>
        bool IndexText(Texts text);

        /// <summary>
        /// This method should find all the Texts in the database that contains the given searchword.
        /// For each searchword found, a relation should be saved in the TextSearchword table.
        /// </summary>
        /// <param name="searchword">
        /// The searchword represents a newly created SearchWords object.
        /// </param>
        /// <returns>
        /// A boolean that determines whether the indexing was succesful or not.
        /// </returns>
        bool IndexSearchWord(SearchWords searchword);
    }
}
