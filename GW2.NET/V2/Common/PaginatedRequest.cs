// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginatedRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a paginated bulk resource details request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Common
{
    /// <summary>Represents a paginated bulk resource details request.</summary>
    public class PaginatedRequest : IPaginatedRequest
    {
        /// <summary>Gets or sets the page number.</summary>
        public int Page { get; set; }

        /// <summary>Gets or sets the number of entries per page.</summary>
        public int PageSize { get; set; }

        /// <summary>Gets or sets the resource path.</summary>
        public string Resource { get; set; }
    }
}