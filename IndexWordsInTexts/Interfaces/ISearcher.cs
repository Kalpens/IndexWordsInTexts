using System;
using System.Collections.Generic;
using System.Text;

namespace IndexWordsInTexts
{
    interface ISearcher
    {
        /// <summary>
        /// This method should return a list of texts that has a relation to the given searchword.
        /// The relations should be found in the TextSearchword table.
        /// </summary>
        /// <param name="searchword">
        /// The searchword represents input from user.
        /// </param>
        /// <returns>
        /// It should return a list of texts.
        /// if none is found, it should return a empty list.
        /// </returns>
        List<string> SearchTextsWithString(string searchword);

        /// <summary>
        /// This method should return a list of texts that have a relation to one or more of the searhwords.
        /// The list should be sorted based on how many of the searchwords they have a relation to.
        /// </summary>
        /// <param name="searchwords">
        /// The searchwords represents a list of user inputs.
        /// </param>
        /// <returns>
        /// It should return a sorted list of Texts.
        /// If none is found, it should return a empty list.
        /// </returns>
        List<string> SearchTextsWithList(List<string> searchwords);
    }
}
