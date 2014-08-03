// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the map names service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Entities.Maps;
    using GW2DotNET.V1.Maps.Contracts;

    /// <summary>Provides the default implementation of the map names service.</summary>
    public class MapNameService : IMapNameService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapNameService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapNameService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames()
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
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
            var response = this.serviceClient.Send(request, new JsonSerializer<ICollection<MapNameContract>>());
            if (response.Content == null)
            {
                return new Dictionary<int, Map>(0);
            }

            return MapMapNameContracts(response.Content, language);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync()
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetMapNamesAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<ICollection<MapNameContract>>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapMapNameContracts(response.Content, language);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Map MapMapNameContract(MapNameContract content)
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
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Map> MapMapNameContracts(ICollection<MapNameContract> content, CultureInfo culture)
        {
            Contract.Requires(content != null);
            Contract.Requires(culture != null);
            Contract.Ensures(Contract.Result<IDictionary<int, Map>>() != null);
            var values = new Dictionary<int, Map>(content.Count);
            foreach (var value in content.Select(MapMapNameContract))
            {
                Contract.Assume(value != null);
                value.Language = culture.TwoLetterISOLanguageName;
                values.Add(value.MapId, value);
            }

            return values;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}