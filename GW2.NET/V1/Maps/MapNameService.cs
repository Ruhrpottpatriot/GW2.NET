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
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
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
        public IEnumerable<MapName> GetMapNames()
        {
            return this.GetMapNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public IEnumerable<MapName> GetMapNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapNameRequest { Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<MapNameCollection>());

            // Patch missing language information
            foreach (var mapName in result)
            {
                mapName.Language = language.TwoLetterISOLanguageName;
            }

            return result;
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync()
        {
            return this.GetMapNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetMapNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync(CultureInfo language)
        {
            return this.GetMapNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of maps and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of maps and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/map_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<MapName>> GetMapNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new MapNameRequest { Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<MapNameCollection>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing language information
                        foreach (var mapName in result)
                        {
                            mapName.Language = language.TwoLetterISOLanguageName;
                        }

                        return result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<MapName>>(task => task.Result, cancellationToken);

            return t2;
        }
    }
}