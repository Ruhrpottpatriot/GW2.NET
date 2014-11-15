// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/world_names.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Entities.Worlds;
    using GW2NET.V1.Worlds.Converters;
    using GW2NET.V1.Worlds.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/world_names.json interface.</summary>
    public class WorldRepository : IRepository<int, World>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<WorldDataContract>, ICollection<World>> converterForWorldCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public WorldRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForCollection<WorldDataContract, World>(new ConverterForWorld()))
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForWorldCollection">The converter for <see cref="World"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceClient"/> is <c>null</c>.</exception>
        internal WorldRepository(IServiceClient serviceClient, IConverter<ICollection<WorldDataContract>, ICollection<World>> converterForWorldCollection)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForWorldCollection != null);
            this.serviceClient = serviceClient;
            this.converterForWorldCollection = converterForWorldCollection;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

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
            var request = new WorldNameRequest
            {
                Culture = this.Culture
            };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            var dataContracts = response.Content;
            if (dataContracts == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var worlds = new DictionaryRange<int, World>(dataContracts.Count)
            {
                SubtotalCount = dataContracts.Count, 
                TotalCount = dataContracts.Count
            };

            foreach (var world in this.converterForWorldCollection.Convert(dataContracts))
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
            return ((IRepository<int, World>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new WorldNameRequest
            {
                Culture = this.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, request.Culture), cancellationToken);
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, World> ConvertAsyncResponse(Task<IResponse<ICollection<WorldDataContract>>> task, CultureInfo culture)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, World>>() != null);
            var response = task.Result;
            var dataContracts = response.Content;
            if (dataContracts == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            var worlds = new DictionaryRange<int, World>(dataContracts.Count)
            {
                SubtotalCount = dataContracts.Count, 
                TotalCount = dataContracts.Count
            };

            foreach (var world in this.converterForWorldCollection.Convert(dataContracts))
            {
                world.Culture = culture;
                worlds.Add(world.WorldId, world);
            }

            return worlds;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForWorldCollection != null);
        }
    }
}