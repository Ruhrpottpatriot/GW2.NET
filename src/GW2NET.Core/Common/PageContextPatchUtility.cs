// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageContextPatchUtility.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The API embeds page context in HTTP Link headers, but we currently do not have a parser for that header.
//   This class calculates the missing page context information for a given page index.
//   This class should eventually be replaced by a class that can parse Link headers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Diagnostics.Contracts;

namespace GW2NET.Common
{
    /// <summary>
    /// The API embeds page context in HTTP Link headers, but we currently do not have a parser for that header.
    /// This class calculates the missing page context information for a given page index.
    /// This class should eventually be replaced by a class that can parse Link headers.
    /// </summary>
    public static class PageContextPatchUtility
    {
        /// <summary>Patches missing page context for the given collection and page index.</summary>
        /// <param name="collection">The collection.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <typeparam name="T">The type of values in the collection.</typeparam>
        public static void Patch<T>(ICollectionPage<T> collection, int pageIndex)
        {
            Contract.Requires(collection != null);
            collection.PageIndex = pageIndex;
            if (collection.PageCount > 0)
            {
                collection.LastPageIndex = collection.PageCount - 1;
                if (collection.PageIndex < collection.LastPageIndex)
                {
                    collection.NextPageIndex = collection.PageIndex + 1;
                }

                if (collection.PageIndex > collection.FirstPageIndex)
                {
                    collection.PreviousPageIndex = collection.PageIndex - 1;
                }
            }
        }
    }
}