// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the files service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Files
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Files;
    using GW2NET.V1.Files.Json;

    /// <summary>Provides the default implementation of the files service.</summary>
    public class FileService : IFileService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FileService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public IDictionary<string, Asset> GetFiles()
        {
            var request = new FileRequest();
            var response = this.serviceClient.Send<IDictionary<string, FileContract>>(request);
            if (response.Content == null)
            {
                return new Dictionary<string, Asset>(0);
            }

            return ConvertFileContractCollection(response.Content);
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Asset>> GetFilesAsync()
        {
            return this.GetFilesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IDictionary<string, Asset>> GetFilesAsync(CancellationToken cancellationToken)
        {
            var request = new FileRequest();
            return this.serviceClient.SendAsync<IDictionary<string, FileContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new Dictionary<string, Asset>(0);
                        }

                        return ConvertFileContractCollection(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Asset ConvertFileContract(KeyValuePair<string, FileContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Ensures(Contract.Result<Asset>() != null);

            // Create a new file object
            var value = new Asset();

            // Set the file name
            value.FileName = content.Key;

            // Set the file identifier
            value.FileId = content.Value.FileId;

            // Set the file signature
            value.FileSignature = content.Value.Signature;

            // Return the file object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<string, Asset> ConvertFileContractCollection(IDictionary<string, FileContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<string, Asset>>() != null);

            var values = new Dictionary<string, Asset>(content.Count);
            foreach (var value in content.Select(ConvertFileContract))
            {
                Contract.Assume(value != null);
                values.Add(value.FileName, value);
            }

            return values;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}