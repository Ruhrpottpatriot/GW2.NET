// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPageContext.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides contextual information for paginated collections.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Diagnostics.Contracts;

    using GW2NET.V2.Common;

    /// <summary>Provides contextual information for paginated collections.</summary>
    [ContractClass(typeof(ContractClassForIPageContext))]
    public interface IPageContext : ISubsetContext
    {
        /// <summary>Gets or sets the page index of the first page.</summary>
        int FirstPageIndex { get; set; }

        /// <summary>Gets or sets the page index of the last page.</summary>
        int LastPageIndex { get; set; }

        /// <summary>Gets or sets the page index of the next page.</summary>
        int? NextPageIndex { get; set; }

        /// <summary>Gets or sets the number of pages.</summary>
        int PageCount { get; set; }

        /// <summary>Gets or sets the page index of the current page.</summary>
        int PageIndex { get; set; }

        /// <summary>Gets or sets the maximum number of items per page.</summary>
        int PageSize { get; set; }

        /// <summary>Gets or sets the page index of the previous page.</summary>
        int? PreviousPageIndex { get; set; }
    }
}