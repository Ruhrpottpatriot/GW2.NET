// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the maps service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps
{
    /// <summary>Provides the interface for the maps service.</summary>
    public interface IMapService : IMapNameService, IMapDetailsService, IMapFloorService, IContinentDetailsService
    {
    }
}