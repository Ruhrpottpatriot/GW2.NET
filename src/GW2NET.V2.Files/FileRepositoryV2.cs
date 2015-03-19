// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepositoryV2.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the FileRepositoryV2 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Files
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Files;

    /// <summary>Represents a repository that retrieves data from the /v2/files interface.</summary>
    public sealed class FileRepositoryV2 : IFileRepositoryV2
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> identifiersConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<FileDataContract>, AssetV2> responseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<FileDataContract>>, ICollectionPage<AssetV2>> pageResponseConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<FileDataContract>>, IDictionaryRange<string, AssetV2>> bulkResponseConverter;

        /// <summary>Initializes a new instance of the <see cref="FileRepositoryV2"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FileRepositoryV2(IServiceClient serviceClient)
            : this(serviceClient, new FileDataContractConverter())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="FileRepositoryV2"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="contractToAssetConverter">The contract to asset converter.</param>
        internal FileRepositoryV2(IServiceClient serviceClient, IConverter<FileDataContract, AssetV2> contractToAssetConverter)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(contractToAssetConverter != null);

            this.serviceClient = serviceClient;

            this.identifiersConverter = new ConverterForCollectionResponse<string, string>(new ConverterAdapter<string>());
            this.responseConverter = new ConverterForResponse<FileDataContract, AssetV2>(contractToAssetConverter);
            this.bulkResponseConverter = new ConverterForDictionaryRangeResponse<FileDataContract, string, AssetV2>(contractToAssetConverter, value => value.FileId);
            this.pageResponseConverter = new ConverterForCollectionPageResponse<FileDataContract, AssetV2>(contractToAssetConverter);
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new FileDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.identifiersConverter.Convert(response) ?? new List<string>(0);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            return ((IFileRepositoryV2)this).DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new FileDiscoveryRequest();
            var response = this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken);
            return response.ContinueWith<ICollection<string>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<AssetV2> IPaginator<AssetV2>.FindPage(int pageIndex)
        {
            var request = new FilePageRequest { Page = pageIndex };
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response);

            if (values == null)
            {
                return new CollectionPage<AssetV2>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        ICollectionPage<AssetV2> IPaginator<AssetV2>.FindPage(int pageIndex, int pageSize)
        {
            var request = new FilePageRequest { Page = pageIndex, PageSize = pageSize };
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            var values = this.pageResponseConverter.Convert(response);

            if (values == null)
            {
                return new CollectionPage<AssetV2>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<AssetV2>> IPaginator<AssetV2>.FindPageAsync(int pageIndex)
        {
            return ((IFileRepositoryV2)this).FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AssetV2>> IPaginator<AssetV2>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new FilePageRequest { Page = pageIndex };
            var response = this.serviceClient.SendAsync<ICollection<FileDataContract>>(request, cancellationToken);
            return response.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AssetV2>> IPaginator<AssetV2>.FindPageAsync(int pageIndex, int pageSize)
        {
            return ((IFileRepositoryV2)this).FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<AssetV2>> IPaginator<AssetV2>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
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
        AssetV2 IRepository<string, AssetV2>.Find(string identifier)
        {
            var request = new FileDetailRequest { Identifier = identifier };
            var response = this.serviceClient.Send<FileDataContract>(request);
            return this.responseConverter.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<string, AssetV2> IRepository<string, AssetV2>.FindAll()
        {
            var request = new FileBulkRequest();
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            return this.bulkResponseConverter.Convert(response) ?? new DictionaryRange<string, AssetV2>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<string, AssetV2> IRepository<string, AssetV2>.FindAll(ICollection<string> identifiers)
        {
            var request = new FileBulkRequest { Identifiers = identifiers };
            var response = this.serviceClient.Send<ICollection<FileDataContract>>(request);
            return this.bulkResponseConverter.Convert(response) ?? new DictionaryRange<string, AssetV2>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, AssetV2>> IRepository<string, AssetV2>.FindAllAsync()
        {
            return ((IFileRepositoryV2)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, AssetV2>> IRepository<string, AssetV2>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new FileBulkRequest();
            var response = this.serviceClient.SendAsync<ICollection<FileDataContract>>(request, cancellationToken);
            return response.ContinueWith<IDictionaryRange<string, AssetV2>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, AssetV2>> IRepository<string, AssetV2>.FindAllAsync(ICollection<string> identifiers)
        {
            return ((IFileRepositoryV2)this).FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, AssetV2>> IRepository<string, AssetV2>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new FileBulkRequest { Identifiers = identifiers };
            var response = this.serviceClient.SendAsync<ICollection<FileDataContract>>(request, cancellationToken);
            return response.ContinueWith<IDictionaryRange<string, AssetV2>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<AssetV2> IRepository<string, AssetV2>.FindAsync(string identifier)
        {
            return ((IFileRepositoryV2)this).FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<AssetV2> IRepository<string, AssetV2>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new FileDetailRequest { Identifier = identifier };
            var response = this.serviceClient.SendAsync<FileDataContract>(request, cancellationToken);
            return response.ContinueWith<AssetV2>(this.ConvertAsyncResponse, cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private AssetV2 ConvertAsyncResponse(Task<IResponse<FileDataContract>> task)
        {
            Contract.Requires(task != null);
            return this.responseConverter.Convert(task.Result);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private IDictionaryRange<string, AssetV2> ConvertAsyncResponse(Task<IResponse<ICollection<FileDataContract>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<int, AssetV2>>() != null);
            return this.bulkResponseConverter.Convert(task.Result) ?? new DictionaryRange<string, AssetV2>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private ICollectionPage<AssetV2> ConvertAsyncResponse(Task<IResponse<ICollection<FileDataContract>>> task, int pageIndex)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollectionPage<AssetV2>>() != null);
            var values = this.pageResponseConverter.Convert(task.Result);
            if (values == null)
            {
                return new CollectionPage<AssetV2>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not part of the public API.")]
        private ICollection<string> ConvertAsyncResponse(Task<IResponse<ICollection<string>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            return this.identifiersConverter.Convert(task.Result) ?? new List<string>(0);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        // ReSharper disable once UnusedMember.Local
        private void ObjectInvariant()
        {
            Contract.Invariant(this.bulkResponseConverter != null);
            Contract.Invariant(this.identifiersConverter != null);
            Contract.Invariant(this.pageResponseConverter != null);
            Contract.Invariant(this.responseConverter != null);
            Contract.Invariant(this.serviceClient != null);
        }
    }
}