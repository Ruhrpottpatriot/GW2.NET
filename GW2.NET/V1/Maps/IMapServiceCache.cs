// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMapServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a maps service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.Maps.Types;

    /// <summary>Provides the interface for a maps service cache.</summary>
    public interface IMapServiceCache : IMapService
    {
        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Map GetMap(int mapId, bool allowCache);

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Map GetMap(int mapId, CultureInfo language, bool allowCache);

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<Map> GetMapAsync(int mapId, bool allowCache);

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<Map> GetMapAsync(int mapId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<Map> GetMapAsync(int mapId, CultureInfo language, bool allowCache);

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<Map> GetMapAsync(int mapId, CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        IEnumerable<Map> GetMaps(bool allowCache);

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        IEnumerable<Map> GetMaps(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<IEnumerable<Map>> GetMapsAsync(bool allowCache);

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<IEnumerable<Map>> GetMapsAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of maps and their localized details.</summary>
        /// <param name="maps">A collection of maps and their localized details.</param>
        /// <param name="language">The language.</param>
        void SetMaps(IEnumerable<Map> maps, CultureInfo language);

        /// <summary>Sets a collection of maps and their localized details.</summary>
        /// <param name="maps">A collection of maps and their localized details.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetMaps(IEnumerable<Map> maps, CultureInfo language, CacheItemParameters parameters);
    }
}