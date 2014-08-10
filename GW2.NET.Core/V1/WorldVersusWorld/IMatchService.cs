// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMatchService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the matches service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld
{
    /// <summary>Provides the interface for the matches service.</summary>
    public interface IMatchService : IMatchDiscoveryService, IMatchDetailsService, IObjectiveNameService
    {
    }
}