// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the world service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Worlds;
    using GW2NET.V1.Worlds.Json;

    /// <summary>Provides the default implementation of the world service.</summary>
    public class WorldService : IWorldService
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
        public IDictionary<int, World> GetWorldNames()
        {
            var culture = new CultureInfo("en");
            return this.GetWorldNames(culture);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public IDictionary<int, World> GetWorldNames(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new WorldNameRequest { Culture = language };
            var response = this.serviceClient.Send<ICollection<WorldNameDataContract>>(request);

            // Ensure that there is response content
            if (response.Content == null)
            {
                return new Dictionary<int, World>(0);
            }

            var values = ConvertWorldNameContractCollection(response.Content);
            var locale = response.Culture ?? language;
            foreach (var value in values.Values)
            {
                value.Culture = locale;
            }

            return values;
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync()
        {
            var culture = new CultureInfo("en");
            return this.GetWorldNamesAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetWorldNamesAsync(culture, cancellationToken);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language)
        {
            return this.GetWorldNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, World>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var worldNamesRequest = new WorldNameRequest { Culture = language };
            return this.serviceClient.SendAsync<ICollection<WorldNameDataContract>>(worldNamesRequest, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;

                        // Ensure that there is response content
                        if (response.Content == null)
                        {
                            return new Dictionary<int, World>(0);
                        }

                        var values = ConvertWorldNameContractCollection(response.Content);
                        var locale = response.Culture ?? language;
                        foreach (var value in values.Values)
                        {
                            value.Culture = locale;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static World ConvertWorldNameContract(WorldNameDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Id != null);
            Contract.Ensures(Contract.Result<World>() != null);

            // Create a new world object
            var value = new World();

            // Set the world identifier
            int id;
            if (int.TryParse(content.Id, out id))
            {
                value.WorldId = id;
            }

            // Set the name of the world
            if (content.Name != null)
            {
                value.Name = content.Name;
            }

            // Return the world object
            return value;
        }

        /// <summary>Infrastructure. Maps contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, World> ConvertWorldNameContractCollection(ICollection<WorldNameDataContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<int, World>>() != null);

            // Create a new collection of world objects
            var values = new Dictionary<int, World>(content.Count);

            // Set the world names
            foreach (var value in content.Select(ConvertWorldNameContract))
            {
                values[value.WorldId] = value;
            }

            // Return the collection
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