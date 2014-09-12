// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PageRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for paginated resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>Provides the base class for paginated resource details requests.</summary>
    public abstract class PageRequest : IPageRequest
    {
        /// <summary>Gets or sets the page number.</summary>
        public virtual int Page { get; set; }

        /// <summary>Gets or sets the number of entries per page.</summary>
        public virtual int? PageSize { get; set; }

        /// <summary>Gets the resource path.</summary>
        public abstract string Resource { get; }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public virtual IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get the 'page' parameter
            yield return new KeyValuePair<string, string>("page", this.Page.ToString(NumberFormatInfo.InvariantInfo));

            // Get the 'page_size' parameter
            var pageSize = this.PageSize;
            if (pageSize.HasValue)
            {
                yield return new KeyValuePair<string, string>("page_size", pageSize.Value.ToString(NumberFormatInfo.InvariantInfo));
            }
        }
    }
}