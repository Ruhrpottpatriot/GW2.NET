// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the world service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Worlds
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Worlds.Contracts;
    using GW2DotNET.Worlds;

    /// <summary>Provides the default implementation of the world service.</summary>
    public class WorldService : IWorldNameService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public WorldService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public ICollection<World> GetWorldNames()
        {
            return this.GetWorldNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public ICollection<World> GetWorldNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new WorldNameRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<ICollection<WorldNameContract>>());
            return MapWorldNameContracts(response.Content, language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync()
        {
            return this.GetWorldNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetWorldNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.GetWorldNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var worldNamesRequest = new WorldNameRequest { Culture = language };
            return this.serviceClient.SendAsync(worldNamesRequest, new JsonSerializer<ICollection<WorldNameContract>>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapWorldNameContracts(response.Content, language);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static World MapWorldNameContract(WorldNameContract content)
        {
            return new World { WorldId = int.Parse(content.Id), Name = content.Name };
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<World> MapWorldNameContracts(ICollection<WorldNameContract> content, CultureInfo culture)
        {
            var values = new List<World>(content.Count);
            values.AddRange(content.Select(MapWorldNameContract));
            values.ForEach(world => world.Language = culture.TwoLetterISOLanguageName);
            return values;
        }
    }
}