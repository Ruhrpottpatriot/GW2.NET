// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/world_names.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Common;
    using GW2NET.V1.Worlds.Json;
    using GW2NET.Worlds;

    /// <summary>Represents a repository that retrieves data from the /v1/world_names.json interface.</summary>
    public class WorldRepository : IWorldRepository
    {
        private readonly IConverter<ICollection<WorldDTO>, ICollection<World>> worldCollectionConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="worldCollectionConverter">The converter for <see cref="World"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceClient"/> is <c>null</c>.</exception>
        public WorldRepository(IServiceClient serviceClient, IConverter<ICollection<WorldDTO>, ICollection<World>> worldCollectionConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (worldCollectionConverter == null)
            {
                throw new ArgumentNullException("worldCollectionConverter");
            }

            this.serviceClient = serviceClient;
            this.worldCollectionConverter = worldCollectionConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        World IRepository<int, World>.Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll()
        {
            IWorldRepository self = this;
            var request = new WorldNameRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<WorldDTO>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var worlds = new DictionaryRange<int, World>(response.Content.Count)
            {
                SubtotalCount = response.Content.Count,
                TotalCount = response.Content.Count
            };

            foreach (var world in this.worldCollectionConverter.Convert(response.Content, null))
            {
                world.Culture = request.Culture;
                worlds.Add(world.WorldId, world);
            }

            return worlds;
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync()
        {
            IWorldRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldNameRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<WorldDTO>>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var worlds = new DictionaryRange<int, World>(response.Content.Count)
            {
                SubtotalCount = response.Content.Count,
                TotalCount = response.Content.Count
            };

            foreach (var world in this.worldCollectionConverter.Convert(response.Content, response))
            {
                world.Culture = request.Culture;
                worlds.Add(world.WorldId, world);
            }

            return worlds;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}