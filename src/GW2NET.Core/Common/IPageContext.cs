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
    using System;

    /// <summary>Provides contextual information for paginated collections.</summary>
    public interface IPageContext : ISubsetContext
    {
        /// <summary>Gets or sets the page index of the first page.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is greater than <see cref="LastPageIndex"/>.</exception>
        int FirstPageIndex { get; set; }

        /// <summary>Gets or sets the page index of the last page.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than <see cref="FirstPageIndex"/>.</exception>
        int LastPageIndex { get; set; }

        /// <summary>Gets or sets the page index of the next page.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than <see cref="FirstPageIndex"/> or greater than <see cref="LastPageIndex"/>.</exception>
        int? NextPageIndex { get; set; }

        /// <summary>Gets or sets the number of pages.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than 0.</exception>
        int PageCount { get; set; }

        /// <summary>Gets or sets the page index of the current page.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than <see cref="FirstPageIndex"/> or greater than <see cref="LastPageIndex"/>.</exception>
        int PageIndex { get; set; }

        /// <summary>Gets or sets the maximum number of items per page.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than 0.</exception>
        int PageSize { get; set; }

        /// <summary>Gets or sets the page index of the previous page.</summary>
        /// <exception cref="ArgumentOutOfRangeException">The value is less than <see cref="FirstPageIndex"/> or greater than <see cref="LastPageIndex"/>.</exception>
        int? PreviousPageIndex { get; set; }
    }
}