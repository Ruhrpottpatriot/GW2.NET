// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionPage.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a subset of values.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Collections.Generic;

    /// <summary>Represents a subset of values.</summary>
    /// <typeparam name="T">The type of elements in the subset.</typeparam>
    public sealed class CollectionPage<T> : List<T>, ICollectionPage<T>
    {
        /// <summary>Initializes a new instance of the <see cref="CollectionPage{T}"/> class that is empty and has the default initial capacity.</summary>
        public CollectionPage()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CollectionPage{T}"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public CollectionPage(IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CollectionPage{T}"/> class that is empty and has the specified initial capacity.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public CollectionPage(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Gets or sets the page index of the first page.</summary>
        public int FirstPageIndex { get; set; }

        /// <summary>Gets or sets the page index of the last page.</summary>
        public int LastPageIndex { get; set; }

        /// <summary>Gets or sets the page index of the next page.</summary>
        public int? NextPageIndex { get; set; }

        /// <summary>Gets or sets the number of pages.</summary>
        public int PageCount { get; set; }

        /// <summary>Gets or sets the page index of the current page.</summary>
        public int PageIndex { get; set; }

        /// <summary>Gets or sets the maximum number of items per page.</summary>
        public int PageSize { get; set; }

        /// <summary>Gets or sets the page index of the previous page.</summary>
        public int? PreviousPageIndex { get; set; }

        /// <summary>Gets or sets the number of values in this subset.</summary>
        public int SubtotalCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        public int TotalCount { get; set; }
    }
}