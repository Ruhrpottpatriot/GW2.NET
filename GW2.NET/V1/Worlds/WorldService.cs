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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Entities.Worlds;
    using GW2DotNET.V1.Worlds.Contracts;

    /// <summary>Provides the default implementation of the world service.</summary>
    public class WorldService : IWorldNameService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public WorldService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public ICollection<World> GetWorldNames()
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetWorldNames(culture);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public ICollection<World> GetWorldNames(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new WorldNameRequest { Culture = language };
            var response = this.serviceClient.Send<ICollection<WorldNameContract>>(request);
            if (response.Content == null)
            {
                return new List<World>(0);
            }

            return MapWorldNameContracts(response.Content, language);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync()
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetWorldNamesAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<ICollection<World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            var culture = CultureInfo.GetCultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetWorldNamesAsync(culture, cancellationToken);
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
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var worldNamesRequest = new WorldNameRequest { Culture = language };
            return this.serviceClient.SendAsync<ICollection<WorldNameContract>>(worldNamesRequest, cancellationToken).ContinueWith(
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
            Contract.Requires(content != null);
            Contract.Requires(content.Id != null);
            return new World { WorldId = int.Parse(content.Id), Name = content.Name };
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<World> MapWorldNameContracts(ICollection<WorldNameContract> content, CultureInfo culture)
        {
            Contract.Requires(content != null);
            var values = new List<World>(content.Count);
            values.AddRange(content.Select(MapWorldNameContract));
            values.ForEach(world => world.Language = culture.TwoLetterISOLanguageName);
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