// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFloorRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for floor requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using GW2DotNET.Common;

    /// <summary>Provides the interface for floor requests.</summary>
    public interface IFloorRequest : IRequest
    {
        /// <summary>Gets or sets the continent identifier.</summary>
        int? ContinentId { get; set; }

        /// <summary>Gets or sets the floor number.</summary>
        int? Floor { get; set; }
    }
}