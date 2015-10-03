// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/quaggans interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common.Converters;

namespace GW2NET.V2.Quaggans
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Quaggans;

    /// <summary>Represents a repository that retrieves data from the /v2/quaggans interface.</summary>
    public class QuagganRepository : IQuagganRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<QuagganDataContract>>, IDictionaryRange<string, Quaggan>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<QuagganDataContract>>, ICollectionPage<Quaggan>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<QuagganDataContract>, Quaggan> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="QuagganRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public QuagganRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<string>>(), new ConverterForQuaggan())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="QuagganRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForIdentifiers">The converter for <see cref="T:ICollection{string}"/>.</param>
        /// <param name="converterForQuaggan">The converter for <see cref="Quaggan"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForIdentifiers"/> or <paramref name="converterForQuaggan"/> is a null reference.</exception>
        internal QuagganRepository(IServiceClient serviceClient, IConverter<ICollection<string>, ICollection<string>> converterForIdentifiers, IConverter<QuagganDataContract, Quaggan> converterForQuaggan)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForIdentifiers == null)
            {
                throw new ArgumentNullException("converterForIdentifiers", "Precondition: converterForIdentifiers != null");
            }

            if (converterForQuaggan == null)
            {
                throw new ArgumentNullException("converterForQuaggan", "Precondition: converterForQuaggan != null");
            }

            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForResponse<ICollection<string>, ICollection<string>>(converterForIdentifiers);
            this.converterForResponse = new ConverterForResponse<QuagganDataContract, Quaggan>(converterForQuaggan);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<QuagganDataContract, string, Quaggan>(converterForQuaggan, quaggan => quaggan.Id);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<QuagganDataContract, Quaggan>(converterForQuaggan);
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new QuagganDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<string>(0);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            IQuagganRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<string>(0);
        }

        /// <inheritdoc />
        Quaggan IRepository<string, Quaggan>.Find(string identifier)
        {
            var request = new QuagganDetailsRequest
            {
                Identifier = identifier
            };
            var response = this.serviceClient.Send<QuagganDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll()
        {
            var request = new QuagganBulkRequest();
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<string, Quaggan>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll(ICollection<string> identifiers)
        {
            var request = new QuagganBulkRequest
            {
                Identifiers = identifiers.ToList()
            };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<string, Quaggan>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync()
        {
            IQuagganRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest();
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<string, Quaggan>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(ICollection<string> identifiers)
        {
            IQuagganRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest
            {
                Identifiers = identifiers.ToList()
            };
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<string, Quaggan>(0);
        }

        /// <inheritdoc />
        Task<Quaggan> IRepository<string, Quaggan>.FindAsync(string identifier)
        {
            IQuagganRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Quaggan> IRepository<string, Quaggan>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new QuagganDetailsRequest
            {
                Identifier = identifier
            };
            var response = await this.serviceClient.SendAsync<QuagganDataContract>(request, cancellationToken).ConfigureAwait(false);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex
            };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex, int pageSize)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex)
        {
            IQuagganRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex
            };
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, int pageSize)
        {
            IQuagganRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken).ConfigureAwait(false);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }
    }
}