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
    using GW2NET.Worlds;

    /// <summary>Represents a repository that retrieves data from the /v2/worlds interface.</summary>
    public class WorldRepository : IWorldRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<WorldDataContract>>, IDictionaryRange<int, World>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<int>>, ICollection<int>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<WorldDataContract>>, ICollectionPage<World>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<WorldDataContract>, World> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public WorldRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForWorld())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WorldRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForWorld">The converter for <see cref="World"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForWorld"/> is a null reference.</exception>
        internal WorldRepository(IServiceClient serviceClient, IConverter<WorldDataContract, World> converterForWorld)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            if (converterForWorld == null)
            {
                throw new ArgumentNullException("converterForWorld", "Precondition failed: converterForWorld != null");
            }

            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForCollectionResponse<int, int>(new ConverterAdapter<int>());
            this.converterForResponse = new ConverterForResponse<WorldDataContract, World>(converterForWorld);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<WorldDataContract, int, World>(converterForWorld, value => value.WorldId);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<WorldDataContract, World>(converterForWorld);
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            var request = new WorldDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<int>>(request);
            var values = this.converterForIdentifiersResponse.Convert(response);
            return values ?? new List<int>(0);
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            IWorldRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new WorldDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<int>>(request, cancellationToken).ConfigureAwait(false);
            var ids = this.converterForIdentifiersResponse.Convert(response);
            if (ids == null)
            {
                return new List<int>(0);
            }

            return ids;
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
            var response = this.serviceClient.Send<WorldDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<int, World> IRepository<int, World>.FindAll()
        {
            IWorldRepository self = this;
            var request = new WorldBulkRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            var values = this.converterForBulkResponse.Convert(response);
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
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            var values = this.converterForBulkResponse.Convert(response);
            return values ?? new DictionaryRange<int, World>(0);
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
            var request = new WorldBulkRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForBulkResponse.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers)
        {
            IWorldRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<int, World>> IRepository<int, World>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldBulkRequest
            {
                Identifiers = identifiers.Select(i => i.ToString(NumberFormatInfo.InvariantInfo)).ToList(),
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForBulkResponse.Convert(response);
            if (values == null)
            {
                return new DictionaryRange<int, World>(0);
            }

            return values;
        }

        /// <inheritdoc />
        Task<World> IRepository<int, World>.FindAsync(int identifier)
        {
            IWorldRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<World> IRepository<int, World>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldDetailsRequest
            {
                Identifier = identifier.ToString(NumberFormatInfo.InvariantInfo),
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<WorldDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForResponse.Convert(response);
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
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<World>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
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
            var response = this.serviceClient.Send<ICollection<WorldDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<World>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex)
        {
            IWorldRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldPageRequest
            {
                Page = pageIndex,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<World>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize)
        {
            IWorldRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<World>> IPaginator<World>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            IWorldRepository self = this;
            var request = new WorldPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<WorldDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<World>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }
    }
}
