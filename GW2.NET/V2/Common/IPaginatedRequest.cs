// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaginatedRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for paginated resource details requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Common
{
    using GW2DotNET.Common;

    /// <summary>Provides the interface for paginated resource details requests.</summary>
    public interface IPaginatedRequest : IRequest
    {
        /// <summary>Gets or sets the page number.</summary>
        int? Page { get; set; }

        /// <summary>Gets or sets the number of entries per page.</summary>
        int? PageSize { get; set; }
    }
}