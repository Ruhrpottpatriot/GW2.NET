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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Maps;
    using GW2DotNET.Utilities;
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
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames()
        {
            return this.GetMapNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IDictionary<int, Map> GetMapNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapNameRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<ICollection<MapNameContract>>());
            return MapMapNameContracts(response.Content, language);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync()
        {
            return this.GetMapNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, Map>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetMapNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
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
            Preconditions.EnsureNotNull(paramName: "language", value: language);
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
            return new Map { MapId = int.Parse(content.Id), MapName = content.Name };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, Map> MapMapNameContracts(ICollection<MapNameContract> content, CultureInfo culture)
        {
            var values = new Dictionary<int, Map>(content.Count);
            foreach (var value in content.Select(MapMapNameContract))
            {
                value.Language = culture.TwoLetterISOLanguageName;
                values.Add(value.MapId, value);
            }

            return values;
        }
    }
}