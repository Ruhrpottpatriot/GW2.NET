// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IContinentServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a continents service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.Continents.Contracts;

    /// <summary>Provides the interface for a continents service cache.</summary>
    public interface IContinentServiceCache : IContinentService
    {
        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        IEnumerable<Continent> GetContinents(bool allowCache);

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        Task<IEnumerable<Continent>> GetContinentsAsync(bool allowCache);

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        Task<IEnumerable<Continent>> GetContinentsAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of continents.</summary>
        /// <param name="continents">A collection of continents.</param>
        void SetContinents(IEnumerable<Continent> continents);

        /// <summary>Sets a collection of continents.</summary>
        /// <param name="continents">A collection of continents.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetContinents(IEnumerable<Continent> continents, CacheItemParameters parameters);
    }
}