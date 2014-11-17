// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/files.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Files
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Files;

    /// <summary>Represents a repository that retrieves data from the /v1/files.json interface.</summary>
    public class FileRepository : IFileRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<FileDataContract, Asset> converterForAsset;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FileRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForAsset())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="FileRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForAsset">The converter for <see cref="Asset"/>.</param>
        internal FileRepository(IServiceClient serviceClient, IConverter<FileDataContract, Asset> converterForAsset)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForAsset != null);
            this.serviceClient = serviceClient;
            this.converterForAsset = converterForAsset;
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
            var response = this.serviceClient.Send<IDictionary<string, FileDataContract>>(request);
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
                var value = this.converterForAsset.Convert(kvp.Value);
                if (value == null)
                {
                    continue;
                }

                value.FileName = kvp.Key;
                values.Add(value.FileName, value);
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
        Task<IDictionaryRange<string, Asset>> IRepository<string, Asset>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new FileRequest();
            var responseTask = this.serviceClient.SendAsync<IDictionary<string, FileDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<string, Asset>>(this.ConvertAsyncResponse, cancellationToken);
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<string, Asset> ConvertAsyncResponse(Task<IResponse<IDictionary<string, FileDataContract>>> task)
        {
            var response = task.Result;
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
                var value = this.converterForAsset.Convert(kvp.Value);
                if (value == null)
                {
                    continue;
                }

                value.FileName = kvp.Key;
                values.Add(value.FileName, value);
            }

            return values;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForAsset != null);
        }
    }
}