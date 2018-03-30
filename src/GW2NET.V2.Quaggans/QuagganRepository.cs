// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/quaggans interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Quaggans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Quaggans;
    using GW2NET.V2.Quaggans.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/quaggans interface.</summary>
    public class QuagganRepository : IQuagganRepository
    {
        private readonly IConverter<IResponse<ICollection<QuagganDTO>>, IDictionaryRange<string, Quaggan>>
            bulkResponseConverter;

        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersResponseConverter;

        private readonly IConverter<IResponse<ICollection<QuagganDTO>>, ICollectionPage<Quaggan>> pageResponseConverter;

        private readonly IConverter<IResponse<QuagganDTO>, Quaggan> responseConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="QuagganRepository" /> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public QuagganRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersResponseConverter,
            IConverter<IResponse<QuagganDTO>, Quaggan> responseConverter,
            IConverter<IResponse<ICollection<QuagganDTO>>, IDictionaryRange<string, Quaggan>> bulkResponseConverter,
            IConverter<IResponse<ICollection<QuagganDTO>>, ICollectionPage<Quaggan>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            if (identifiersResponseConverter == null)
            {
                throw new ArgumentNullException(nameof(identifiersResponseConverter));
            }

            if (responseConverter == null)
            {
                throw new ArgumentNullException(nameof(responseConverter));
            }

            if (bulkResponseConverter == null)
            {
                throw new ArgumentNullException(nameof(bulkResponseConverter));
            }

            if (pageResponseConverter == null)
            {
                throw new ArgumentNullException(nameof(pageResponseConverter));
            }

            this.serviceClient = serviceClient;
            this.identifiersResponseConverter = identifiersResponseConverter;
            this.responseConverter = responseConverter;
            this.bulkResponseConverter = bulkResponseConverter;
            this.pageResponseConverter = pageResponseConverter;
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new QuagganDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.identifiersResponseConverter.Convert(response, null);
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
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Quaggan IRepository<string, Quaggan>.Find(string identifier)
        {
            var request = new QuagganDetailsRequest { Identifier = identifier };
            var response = this.serviceClient.Send<QuagganDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll()
        {
            var request = new QuagganBulkRequest();
            var response = this.serviceClient.Send<ICollection<QuagganDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll(ICollection<string> identifiers)
        {
            var request = new QuagganBulkRequest { Identifiers = identifiers.ToList() };
            var response = this.serviceClient.Send<ICollection<QuagganDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
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
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(
            ICollection<string> identifiers)
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
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
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
            var response = await this.serviceClient.SendAsync<QuagganDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex)
        {
            var request = new QuagganPageRequest { Page = pageIndex };
            var response = this.serviceClient.Send<ICollection<QuagganDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex, int pageSize)
        {
            var request = new QuagganPageRequest { Page = pageIndex, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<QuagganDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
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
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
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
            var response = await this.serviceClient.SendAsync<ICollection<QuagganDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }
    }
}