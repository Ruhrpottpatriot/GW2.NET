// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaginatedCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for collections that are a subset of a larger collection, and whose maximum size is equal to that of the other subsets.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Common
{
    /// <summary>Provides the interface for collections that are a subset of a larger collection, and whose maximum size is equal to that of other subsets in the same collection.</summary>
    public interface IPaginatedCollection : ISubcollection
    {
        /// <summary>Gets or sets the maximum number of values in this subset.</summary>
        int PageSize { get; set; }

        /// <summary>Gets or sets the number of subsets in the entire collection.</summary>
        int PageTotal { get; set; }

        /// <summary>Gets or sets the 0-based index of this subset.</summary>
        int CurrentPage { get; set; }
    }
}