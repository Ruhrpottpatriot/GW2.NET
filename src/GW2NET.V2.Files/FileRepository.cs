// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Files;

    /// <summary>Represents a repository that retrieves data from the /v2/files interface.</summary>
    public sealed class FileRepository : IFileRepository
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<FileDataContract>, Asset> responseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<FileDataContract>>, ICollectionPage<Asset>> pageResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<FileDataContract>>, IDictionaryRange<string, Asset>> bulkResponseConverter;

        /// <summary>Initializes a new instance of the <see cref="FileRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FileRepository(IServiceClient serviceClient)
            : this(serviceClient, new AssetConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FileRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="contractToAssetConverter">The contract to asset converter.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="contractToAssetConverter"/> is a null reference.</exception>
        internal FileRepository(IServiceClient serviceClient, IConverter<FileDataContract, Asset> contractToAssetConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (contractToAssetConverter == null)
            {
                throw new ArgumentNullException("contractToAssetConverter", "Precondition: contractToAssetConverter != null");
            }

            this.serviceClient = serviceClient;

            this.identifiersConverter = new ConverterForCollectionResponse<string, string>(new ConverterAdapter<string>());
            this.responseConverter = new ConverterForResponse<FileDataContract, Asset>(contractToAssetConverter);
            this.bulkResponseConverter = new ConverterForDictionaryRangeResponse<FileDataContract, string, Asset>(contractToAssetConverter, value => value.Identifier);
            this.pageResponseConverter = new ConverterForCollectionPageResponse<FileDataContract, Asset>(contractToAssetConverter);
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new FileDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.identifiersConverter.Convert(response, null) ?? new List<string>(0);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            return ((IFileRepository)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new FileDiscoveryRequest();
            var response = this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken);
            return response.ContinueWith<ICollection<string>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Asset> IPaginator<Asset>.FindPage(int pageIndex)
        {
            var request = new FilePageRequest { Page = pageIndex };
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Asset>(0);
        }

        /// <inheritdoc />
        ICollectionPage<Asset> IPaginator<Asset>.FindPage(int pageIndex, int pageSize)
        {
            var request = new FilePageRequest { Page = pageIndex, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response, pageIndex);
            return values ?? new CollectionPage<Asset>(0);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex)
        {
            return ((IFileRepository)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new FilePageRequest { Page = pageIndex };
            var response = this.serviceClient.SendAsync<ICollection<FileDataContract>>(request, cancellationToken);
            return response.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IFileRepository)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Asset>> IPaginator<Asset>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new FilePageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = this.serviceClient.SendAsync<ICollection<FileDataContract>>(request, cancellationToken);
            return response.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);        
        }

        /// <inheritdoc />
        Asset IRepository<string, Asset>.Find(string identifier)
        {
            var request = new FileDetailRequest { Identifier = identifier };
            var response = this.serviceClient.Send<FileDataContract>(request);
            return this.responseConverter.Convert(response, null);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Asset> IRepository<string, Asset>.FindAll()
        {
            var request = new FileBulkRequest();
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            return this.bulkResponseConverter.Convert(response, null) ?? new DictionaryRange<string, Asset>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Asset> IRepository<string, Asset>.FindAll(ICollection<string> identifiers)
        {
            var request = new FileBulkRequest { Identifiers = identifiers };
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            return this.bulkResponseConverter.Convert(response, null) ?? new DictionaryRange<string, Asset>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync()
        {
            return ((IFileRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new FileBulkRequest();
            var response = this.serviceClient.SendAsync<ICollection<FileDataContract>>(request, cancellationToken);
            return response.ContinueWith<IDictionaryRange<string, Asset>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(ICollection<string> identifiers)
        {
            return ((IFileRepository)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new FileBulkRequest { Identifiers = identifiers };
            var response = this.serviceClient.SendAsync<ICollection<FileDataContract>>(request, cancellationToken);
            return response.ContinueWith<IDictionaryRange<string, Asset>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<Asset> IRepository<string, Asset>.FindAsync(string identifier)
        {
            return ((IFileRepository)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Asset> IRepository<string, Asset>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new FileDetailRequest { Identifier = identifier };
            var response = this.serviceClient.SendAsync<FileDataContract>(request, cancellationToken);
            return response.ContinueWith<Asset>(this.ConvertAsyncResponse, cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private Asset ConvertAsyncResponse(Task<IResponse<FileDataContract>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.responseConverter.Convert(task.Result, null);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private IDictionaryRange<string, Asset> ConvertAsyncResponse(Task<IResponse<ICollection<FileDataContract>>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.bulkResponseConverter.Convert(task.Result, null) ?? new DictionaryRange<string, Asset>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private ICollectionPage<Asset> ConvertAsyncResponse(Task<IResponse<ICollection<FileDataContract>>> task, int pageIndex)
        {
            Debug.Assert(task != null, "task != null");
            var values = this.pageResponseConverter.Convert(task.Result, pageIndex);
            return values ?? new CollectionPage<Asset>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private ICollection<string> ConvertAsyncResponse(Task<IResponse<ICollection<string>>> task)
        {
            Debug.Assert(task != null, "task != null");
            return this.identifiersConverter.Convert(task.Result, null) ?? new List<string>(0);
        }
    }
}