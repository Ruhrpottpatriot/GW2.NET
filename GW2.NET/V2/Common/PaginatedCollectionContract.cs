// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginatedCollectionContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The paginated collection contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Common
{
    using System.Diagnostics.Contracts;

    /// <summary>The paginated collection contract.</summary>
    [ContractClassFor(typeof(IPaginatedCollection))]
    internal abstract class PaginatedCollectionContract : IPaginatedCollection
    {
        /// <summary>Gets or sets the 0-based index of this subset.</summary>
        public int CurrentPage { get; set; }

        /// <summary>Gets or sets the number of values in this subset.</summary>
        public int PageCount { get; set; }

        /// <summary>Gets or sets the maximum number of values in this subset.</summary>
        public int PageSize { get; set; }

        /// <summary>Gets or sets the number of subsets in the collection.</summary>
        public int PageTotal { get; set; }

        /// <summary>Gets or sets the number of values in the collection.</summary>
        public int TotalCount { get; set; }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.PageCount >= 0);
            Contract.Invariant(this.TotalCount >= 0);
            Contract.Invariant(this.CurrentPage >= 0);
            Contract.Invariant(this.PageSize >= 0);
            Contract.Invariant(this.PageTotal >= 0);
        }
    }
}