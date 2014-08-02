// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginatedCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a subcollection of values.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    /// <summary>Represents a subset of values.</summary>
    /// <typeparam name="T">The type of elements in the subset.</typeparam>
    public sealed class PaginatedCollection<T> : List<T>, IPaginatedCollection
    {
        /// <summary>Initializes a new instance of the <see cref="PaginatedCollection{T}"/> class that is empty and has the default initial capacity.</summary>
        public PaginatedCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PaginatedCollection{T}"/> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public PaginatedCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PaginatedCollection{T}"/> class that is empty and has the specified initial capacity.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public PaginatedCollection(int capacity)
            : base(capacity)
        {
            Contract.Requires(capacity >= 0);
        }

        /// <summary>Gets or sets the 0-based index of this subset.</summary>
        public int CurrentPage { get; set; }

        /// <summary>Gets or sets the maximum number of values in this subset.</summary>
        public int PageSize { get; set; }

        /// <summary>Gets or sets the number of subsets in the collection.</summary>
        public int PageTotal { get; set; }

        /// <summary>Gets or sets the number of values in this subset.</summary>
        public int PageCount { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        public int TotalCount { get; set; }
    }
}