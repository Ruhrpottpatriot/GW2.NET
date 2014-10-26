﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the maps service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;
    using GW2NET.V1.Continents.Json;
    using GW2NET.V1.Maps.Json;

    /// <summary>Provides the default implementation of the maps service.</summary>
    public class MapService : IMapService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapService(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            Contract.EndContractBlock();

            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public IDictionary<int, Continent> GetContinents()
        {
            var request = new ContinentDetailsRequest();
            var response = this.serviceClient.Send<ContinentCollectionDataContract>(request);
            if (response.Content == null || response.Content.Continents == null)
            {
                return new Dictionary<int, Continent>(0);
            }

            return ConvertContinentCollectionContract(response.Content);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync()
        {
            return this.GetContinentsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of continents and their details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of continents.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/continents">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Continent>> GetContinentsAsync(CancellationToken cancellationToken)
        {
            var request = new ContinentDetailsRequest();
            return this.serviceClient.SendAsync<ContinentCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Continents == null)
                        {
                            return new Dictionary<int, Continent>(0);
                        }

                        return ConvertContinentCollectionContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map)
        {
            var culture = new CultureInfo("en");
            return this.GetMap(map, culture);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Map GetMap(int map, CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapDetailsRequest { MapId = map, Culture = language };
            var response = this.serviceClient.Send<MapCollectionDataContract>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return null;
            }

            var value = ConvertMapCollectionContract(response.Content).Values.SingleOrDefault();
            if (value != null)
            {
                value.Locale = response.Culture ?? language;
            }

            return value;
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map)
        {
            var culture = new CultureInfo("en");
            return this.GetMapAsync(map, culture, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetMapAsync(map, culture, cancellationToken);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CultureInfo language)
        {
            return this.GetMapAsync(map, language, CancellationToken.None);
        }

        /// <summary>Gets a map and its localized details.</summary>
        /// <param name="map">The map identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A map and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<Map> GetMapAsync(int map, CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapDetailsRequest { MapId = map, Culture = language };
            return this.serviceClient.SendAsync<MapCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Maps == null)
                        {
                            return null;
                        }

                        var value = ConvertMapCollectionContract(response.Content).Values.SingleOrDefault();
                        if (value != null)
                        {
                            value.Locale = response.Culture ?? language;
                        }

                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames()
        {
            var culture = new CultureInfo("en");
            return this.GetMapNames(culture);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapNameRequest { Culture = language };
            var response = this.serviceClient.Send<ICollection<MapNameDataContract>>(request);
            if (response.Content == null)
            {
                return new Dictionary<int, Map>(0);
            }

            var values = ConvertMapNameContractCollection(response.Content);
            var locale = response.Culture ?? language;
            foreach (var value in values.Values)
            {
                value.Locale = locale;
            }

            return values;
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync()
        {
            var culture = new CultureInfo("en");
            return this.GetMapNamesAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetMapNamesAsync(culture, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language)
        {
            return this.GetMapNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapNameRequest { Culture = language };
            return this.serviceClient.SendAsync<ICollection<MapNameDataContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response == null)
                        {
                            return new Dictionary<int, Map>(0);
                        }

                        var values = ConvertMapNameContractCollection(response.Content);
                        var locale = response.Culture ?? language;
                        foreach (var value in values.Values)
                        {
                            value.Locale = locale;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps()
        {
            var culture = new CultureInfo("en");
            return this.GetMaps(culture);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMaps(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapDetailsRequest { Culture = language };
            var response = this.serviceClient.Send<MapCollectionDataContract>(request);
            if (response.Content == null || response.Content.Maps == null)
            {
                return new Dictionary<int, Map>(0);
            }

            var values = ConvertMapCollectionContract(response.Content);
            var locale = response.Culture ?? language;
            foreach (var value in values.Values)
            {
                value.Locale = locale;
            }

            return values;
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync()
        {
            var culture = new CultureInfo("en");
            return this.GetMapsAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetMapsAsync(culture, cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CultureInfo language)
        {
            return this.GetMapsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/maps">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new MapDetailsRequest { Culture = language };
            return this.serviceClient.SendAsync<MapCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Maps == null)
                        {
                            return new Dictionary<int, Map>(0);
                        }

                        var values = ConvertMapCollectionContract(response.Content);
                        var locale = response.Culture ?? language;
                        foreach (var value in values.Values)
                        {
                            value.Locale = locale;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Continent> ConvertContinentCollectionContract(ContinentCollectionDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Continents != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Continent>>() != null);
            var values = new Dictionary<int, Continent>(content.Continents.Count);
            foreach (var value in content.Continents.Select(ConvertContinentContract).Where(value => value != null))
            {
                Contract.Assume(value != null);
                values.Add(value.ContinentId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Continent ConvertContinentContract(KeyValuePair<string, ContinentDataContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Requires(content.Value.ContinentDimensions != null);
            Contract.Requires(content.Value.ContinentDimensions.Length == 2);
            return new Continent
                {
                    ContinentId = int.Parse(content.Key), 
                    Name = content.Value.Name, 
                    ContinentDimensions = MapSize2DContract(content.Value.ContinentDimensions), 
                    MinimumZoom = content.Value.MinimumZoom, 
                    MaximumZoom = content.Value.MaximumZoom, 
                    FloorIds = content.Value.Floors
                };
        }


        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Map> ConvertMapCollectionContract(MapCollectionDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Maps != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            var values = new Dictionary<int, Map>(content.Maps.Count);
            foreach (var value in content.Maps.Select(ConvertMapContract))
            {
                Contract.Assume(value != null);
                values.Add(value.MapId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Map ConvertMapContract(KeyValuePair<string, MapDataContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Ensures(Contract.Result<Map>() != null);

            // Create a new map object
            var value = new Map();

            // Set the map identifier
            if (content.Key != null)
            {
                value.MapId = int.Parse(content.Key);
            }

            // Set the name of the map
            if (content.Value.MapName != null)
            {
                value.MapName = content.Value.MapName;
            }

            // Set the minimum level
            value.MinimumLevel = content.Value.MinimumLevel;

            // Set the maximum level
            value.MaximumLevel = content.Value.MaximumLevel;

            // Set the default floor
            value.DefaultFloor = content.Value.DefaultFloor;

            // Set the available floors
            if (content.Value.Floors != null)
            {
                value.Floors = content.Value.Floors;
            }

            // Set the region identifier
            value.RegionId = content.Value.RegionId;

            // Set the name of the region
            if (content.Value.RegionName != null)
            {
                value.RegionName = content.Value.RegionName;
            }

            // Set the continent identifier
            value.ContinentId = content.Value.ContinentId;

            // Set the name of the continent
            if (content.Value.ContinentName != null)
            {
                value.ContinentName = content.Value.ContinentName;
            }

            // Set the dimensions of the map
            if (content.Value.MapRectangle != null && content.Value.MapRectangle.Length == 2 && content.Value.MapRectangle[0] != null
                && content.Value.MapRectangle[0].Length == 2 && content.Value.MapRectangle[1] != null && content.Value.MapRectangle[1].Length == 2)
            {
                value.MapRectangle = ConvertRectangleContract(content.Value.MapRectangle);
            }

            // Set the dimensions of the continent
            if (content.Value.ContinentRectangle != null && content.Value.ContinentRectangle.Length == 2 && content.Value.ContinentRectangle[0] != null
                && content.Value.ContinentRectangle[0].Length == 2 && content.Value.ContinentRectangle[1] != null
                && content.Value.ContinentRectangle[1].Length == 2)
            {
                value.ContinentRectangle = ConvertRectangleContract(content.Value.ContinentRectangle);
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Map ConvertMapNameContract(MapNameDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<Map>() != null);

            // Create a new map object
            var value = new Map();

            // Set the map identifier
            if (content.Id != null)
            {
                value.MapId = int.Parse(content.Id);
            }

            // Set the name of the map
            if (content.Name != null)
            {
                value.MapName = content.Name;
            }

            // Return the map object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Map> ConvertMapNameContractCollection(ICollection<MapNameDataContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            var values = new Dictionary<int, Map>(content.Count);
            foreach (var value in content.Select(ConvertMapNameContract))
            {
                Contract.Assume(value != null);
                values.Add(value.MapId, value);
            }

            return values;
        }
        
        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Rectangle ConvertRectangleContract(double[][] content)
        {
            Contract.Requires(content != null && content.Length == 2);
            Contract.Requires(content[0] != null && content[0].Length == 2);
            Contract.Requires(content[1] != null && content[1].Length == 2);
            var nw = ConvertVector2D(content[0]);
            var se = ConvertVector2D(content[1]);
            return new Rectangle(nw, se);
        }
        
        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Vector2D ConvertVector2D(double[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 2);
            return new Vector2D(content[0], content[1]);
        }
        
        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Size2D MapSize2DContract(double[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 2);
            return new Size2D(content[0], content[1]);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}