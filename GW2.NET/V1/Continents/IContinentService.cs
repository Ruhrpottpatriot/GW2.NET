// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContinentService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the continents service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Continents.Types;

    /// <summary>Provides the interface for the continents service.</summary>
    public interface IContinentService
    {
        /// <summary>Gets the collection of continents in the game.</summary>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        IEnumerable<Continent> GetContinents();

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        Task<IEnumerable<Continent>> GetContinentsAsync();

        /// <summary>Gets the collection of continents in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken cancellationToken);
    }
}