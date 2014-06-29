// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldNameService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the world names service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Worlds
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Worlds.Contracts;

    /// <summary>Provides the default implementation of the world names service.</summary>
    public class WorldNameService : IWorldNameService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldNameService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public WorldNameService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<World> GetWorldNames()
        {
            return this.GetWorldNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IEnumerable<World> GetWorldNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new WorldNameRequest { Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<WorldCollection>());

            // Patch missing language information
            foreach (var worldName in result)
            {
                worldName.Language = language.TwoLetterISOLanguageName;
            }

            return result;
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync()
        {
            return this.GetWorldNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetWorldNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.GetWorldNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var worldNamesRequest = new WorldNameRequest { Culture = language };
            var t1 = this.serviceClient.SendAsync(worldNamesRequest, new JsonSerializer<WorldCollection>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing language information
                        foreach (var worldName in result)
                        {
                            worldName.Language = language.TwoLetterISOLanguageName;
                        }

                        return result;
                    }, 
                cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<World>>(task => task.Result, cancellationToken);

            return t2;
        }
    }
}