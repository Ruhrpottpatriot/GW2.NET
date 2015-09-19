// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/worlds interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Worlds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V2.Worlds.Json;
    using GW2NET.Worlds;

    /// <summary>Represents a repository that retrieves data from the /v2/worlds interface.</summary>
    public class WorldRepository : IWorldRepository
    {
        
        private readonly IConverter<IResponse<ICollection<WorldDTO>>, IDictionaryRange<int, World>> bulkResponseConverter;

        
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter;

        
        private readonly IConverter<IResponse<ICollection<WorldDTO>>, ICollectionPage<World>> pageResponseConverter;

        
        private readonly IConverter<IResponse<WorldDTO>, World> responseConverter;

        
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public WorldRepository(IServiceClient serviceClient, IConverter<IResponse<ICollection<int>>, ICollection<int>> identifiersResponseConverter, IConverter<IResponse<WorldDTO>, World> responseConverter, IConverter<IResponse<ICollection<WorldDTO>>, IDictionaryRange<int, World>> bulkResponseConverter, IConverter<IResponse<ICollection<WorldDTO>>, ICollectionPage<World>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = identifiersResponseConverter;
            this.responseConverter = responseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
            this.pageResponseConverter = pageResponseConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new WorldDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            var values = this.identifiersResponseConverter.Convert(response, null);
            return values ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IWorldRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new WorldDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<int>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        World IRepository<int, World>.Find(int identifier)
        {
            IWorldRepository self = this;
            var request = new WorldDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), 
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<WorldDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll()
        {
            IWorldRepository self = this;
            var request = new WorldBulkRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<WorldDTO>>(request);
            var values = this.bulkResponseConverter.Convert(response, null);
            return values ?? new DictionaryRange<int, World>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll(ICollection<int> identifiers)
        {
            IWorldRepository self = this;
            var request = new WorldBulkRequest
            {
                Culture = self.Culture, 
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList()
            };
            var response = this.serviceClient.Send<ICollection<WorldDTO>>(request);
            var values = this.bulkResponseConverter.Convert(response, null);
            return values ?? new DictionaryRange<int, World>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync()
        {
            IWorldRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldBulkRequest
            {
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<WorldDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, World>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers)
        {
            IWorldRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(), 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<WorldDTO>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<int, World>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier)
        {
            IWorldRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo), 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<WorldDTO>(request, cancellationToken);
            return responseTask.ContinueWith<World>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex)
        {
            IWorldRepository self = this;
            var request = new WorldPageRequest
            {
                Page = pageIndex, 
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<WorldDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<World>(0);
        }

        /// <inheritdoc />
        ICollectionPage<World> IPaginator<World>.FindPage(int pageIndex, int pageSize)
        {
            IWorldRepository self = this;
            var request = new WorldPageRequest
            {
                Page = pageIndex, 
                PageSize = pageSize, 
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<WorldDTO>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<World>(0);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex)
        {
            IWorldRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldPageRequest
            {
                Page = pageIndex, 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<WorldDTO>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize)
        {
            IWorldRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldPageRequest
            {
                Page = pageIndex, 
                PageSize = pageSize, 
                Culture = self.Culture
            };
            return this.serviceClient.SendAsync<ICollection<WorldDTO>>(request, cancellationToken).ContinueWith<ICollectionPage<World>>(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<int, World> ConvertAsyncResponse(Task<IResponse<ICollection<WorldDTO>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.bulkResponseConverter.Convert(task.Result, null);
            if (values == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<World> ConvertAsyncResponse(Task<IResponse<ICollection<WorldDTO>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.pageResponseConverter.Convert(task.Result, pageIndex);
            return values ?? new CollectionPage<World>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<int> ConvertAsyncResponse(Task<IResponse<ICollection<int>>> task)
        {
            Debug.Assert(task != null, "task != null");
            var ids = this.identifiersResponseConverter.Convert(task.Result, null);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private World ConvertAsyncResponse(Task<IResponse<WorldDTO>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result, null);
        }
    }
}