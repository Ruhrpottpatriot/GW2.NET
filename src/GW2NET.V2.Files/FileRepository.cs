// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Files;
    using GW2NET.V2.Files.Json;

    /// <summary>Represents a repository that retrieves data from the /v2/files interface.</summary>
    public sealed class FileRepository : IFileRepository
    {
        private readonly IServiceClient serviceClient;

        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersResponseConverter;

        private readonly IConverter<IResponse<FileDTO>, Asset> responseConverter;

        private readonly IConverter<IResponse<ICollection<FileDTO>>, ICollectionPage<Asset>> pageResponseConverter;

        private readonly IConverter<IResponse<ICollection<FileDTO>>, IDictionaryRange<string, Asset>> bulkResponseConverter;

        /// <summary>Initializes a new instance of the <see cref="FileRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="identifiersResponseConverter"></param>
        /// <param name="responseConverter"></param>
        /// <param name="bulkResponseConverter"></param>
        /// <param name="pageResponseConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FileRepository(
            IServiceClient serviceClient,
            IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersResponseConverter,
            IConverter<IResponse<FileDTO>, Asset> responseConverter,
            IConverter<IResponse<ICollection<FileDTO>>, IDictionaryRange<string, Asset>> bulkResponseConverter,
            IConverter<IResponse<ICollection<FileDTO>>, ICollectionPage<Asset>> pageResponseConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (identifiersResponseConverter == null)
            {
                throw new ArgumentNullException("identifiersResponseConverter");
            }

            if (responseConverter == null)
            {
                throw new ArgumentNullException("responseConverter");
            }

            if (bulkResponseConverter == null)
            {
                throw new ArgumentNullException("bulkResponseConverter");
            }

            if (pageResponseConverter == null)
            {
                throw new ArgumentNullException("pageResponseConverter");
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
            var request = new FileDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            return ((IFileRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new FileDiscoveryRequest();
            var response = await this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ConfigureAwait(false);
            return this.identifiersResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        ICollectionPage<Asset> IPaginator<Asset>.FindPage(int pageIndex)
        {
            var request = new FilePageRequest { Page = pageIndex };
            var response = this.serviceClient.Send<ICollection<FileDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        ICollectionPage<Asset> IPaginator<Asset>.FindPage(int pageIndex, int pageSize)
        {
            var request = new FilePageRequest { Page = pageIndex, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<FileDTO>>(request);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex)
        {
            return ((IFileRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new FilePageRequest { Page = pageIndex };
            var response = await this.serviceClient.SendAsync<ICollection<FileDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IFileRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new FilePageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = await this.serviceClient.SendAsync<ICollection<FileDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.pageResponseConverter.Convert(response, pageIndex);
        }

        /// <inheritdoc />
        Asset IRepository<string, Asset>.Find(string identifier)
        {
            var request = new FileDetailRequest { Identifier = identifier };
            var response = this.serviceClient.Send<FileDTO>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Asset> IRepository<string, Asset>.FindAll()
        {
            var request = new FileBulkRequest();
            var response = this.serviceClient.Send<ICollection<FileDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Asset> IRepository<string, Asset>.FindAll(ICollection<string> identifiers)
        {
            var request = new FileBulkRequest { Identifiers = identifiers };
            var response = this.serviceClient.Send<ICollection<FileDTO>>(request);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync()
        {
            return ((IFileRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new FileBulkRequest();
            var response = await this.serviceClient.SendAsync<ICollection<FileDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(ICollection<string> identifiers)
        {
            return ((IFileRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new FileBulkRequest { Identifiers = identifiers };
            var response = await this.serviceClient.SendAsync<ICollection<FileDTO>>(request, cancellationToken).ConfigureAwait(false);
            return this.bulkResponseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        Task<Asset> IRepository<string, Asset>.FindAsync(string identifier)
        {
            return ((IFileRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Asset> IRepository<string, Asset>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new FileDetailRequest { Identifier = identifier };
            var response = await this.serviceClient.SendAsync<FileDTO>(request, cancellationToken).ConfigureAwait(false);
            return this.responseConverter.Convert(response, null);
        }
    }
}