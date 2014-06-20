// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for map requests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Common
{
    using GW2DotNET.Common;

    /// <summary>Provides the interface for map requests.</summary>
    public interface IMapRequest : IRequest
    {
        /// <summary>Gets or sets the map identifier.</summary>
        int? MapId { get; set; }
    }
}