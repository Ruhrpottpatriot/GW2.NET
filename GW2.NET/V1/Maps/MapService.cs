// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the maps service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Maps.Types;

    /// <summary>Provides the default implementation of the maps service.</summary>
    public class MapService : ServiceBase, IMapService
    {
        /// <summary>Initializes a new instance of the <see cref="MapService"/> class.</summary>
        public MapService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int mapId)
        {
            return this.GetMap(mapId, ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int mapId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new MapsRequest { MapId = mapId, Language = language };
            var result = this.Request<MapCollectionResult>(serviceRequest).Maps.Values;

            foreach (var map in result)
            {
                // patch missing language information
                map.Language = language;
            }

            return result.SingleOrDefault();
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId)
        {
            return this.GetMapAsync(mapId, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CancellationToken cancellationToken)
        {
            return this.GetMapAsync(mapId, ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            return this.GetMapAsync(mapId, language, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int mapId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new MapsRequest { MapId = mapId, Language = language };
            var t1 = this.RequestAsync<MapCollectionResult>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        foreach (var map in task.Result.Maps.Values)
                        {
                            // patch missing language information
                            map.Language = language;
                        }

                        return task.Result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith(task => task.Result.Maps.Values.SingleOrDefault(), cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps()
        {
            return this.GetMaps(ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a collection of maps and their details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IEnumerable<Map> GetMaps(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new MapsRequest { Language = language };
            var result = this.Request<MapCollectionResult>(serviceRequest).Maps.Values;

            foreach (var map in result)
            {
                // patch missing language information
                map.Language = language;
            }

            return result;
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync()
        {
            return this.GetMapsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            return this.GetMapsAsync(ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language)
        {
            return this.GetMapsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Map>> GetMapsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new MapsRequest { Language = language };
            var t1 = this.RequestAsync<MapCollectionResult>(serviceRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        foreach (var map in task.Result.Maps.Values)
                        {
                            // patch missing language information
                            map.Language = language;
                        }

                        return task.Result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Map>>(task => task.Result.Maps.Values, cancellationToken);

            return t2;
        }
    }
}