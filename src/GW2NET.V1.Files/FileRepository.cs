// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/files.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Files
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using GW2NET.Common;
    using GW2NET.Files;
    using GW2NET.V1.Files.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/files.json interface.</summary>
    public class FileRepository : IFileRepository
    {
        private readonly IConverter<FileDTO, Asset> assetConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="assetConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FileRepository(IServiceClient serviceClient, IConverter<FileDTO, Asset> assetConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (assetConverter == null)
            {
                throw new ArgumentNullException("assetConverter");
            }

            this.serviceClient = serviceClient;
            this.assetConverter = assetConverter;
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Asset IRepository<string, Asset>.Find(string identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<string, Asset> IRepository<string, Asset>.FindAll()
        {
            var request = new FileRequest();
            var response = this.serviceClient.Send<IDictionary<string, FileDTO>>(request);
            var content = response.Content;
            if (content == null)
            {
                return new DictionaryRange<string, Asset>(0);
            }

            var values = new DictionaryRange<string, Asset>(content.Count)
            {
                SubtotalCount = content.Count,
                TotalCount = content.Count
            };
            foreach (var kvp in content)
            {
                var value = this.assetConverter.Convert(kvp.Value, null);
                if (value == null)
                {
                    continue;
                }

                value.Identifier = kvp.Key;
                values.Add(value.Identifier, value);
            }

            return values;
        }

        /// <inheritdoc />
        IDictionaryRange<string, Asset> IRepository<string, Asset>.FindAll(ICollection<string> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync()
        {
            IFileRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new FileRequest();
            var response = await this.serviceClient.SendAsync<IDictionary<string, FileDTO>>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return new DictionaryRange<string, Asset>(0);
            }

            var values = new DictionaryRange<string, Asset>(response.Content.Count)
            {
                SubtotalCount = response.Content.Count,
                TotalCount = response.Content.Count
            };

            foreach (var kvp in response.Content)
            {
                var value = this.assetConverter.Convert(kvp.Value, null);
                if (value == null)
                {
                    continue;
                }

                value.Identifier = kvp.Key;
                values.Add(value.Identifier, value);
            }

            return values;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(ICollection<string> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Asset> IRepository<string, Asset>.FindAsync(string identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Asset> IRepository<string, Asset>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Asset> IPaginator<Asset>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Asset> IPaginator<Asset>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}