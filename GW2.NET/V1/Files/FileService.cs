// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the files service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Files
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Files;
    using GW2DotNET.V1.Files.Contracts;

    /// <summary>Provides the default implementation of the files service.</summary>
    public class FileService : IFileService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FileService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public IDictionary<string, Asset> GetFiles()
        {
            var request = new FileRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<IDictionary<string, FileContract>>());
            return MapFileContracts(response.Content);
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<IDictionary<string, FileContract>>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapFileContracts(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Asset MapFileContract(KeyValuePair<string, FileContract> content)
        {
            return new Asset { FileName = content.Key, FileId = content.Value.FileId, FileSignature = content.Value.Signature };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<string, Asset> MapFileContracts(IDictionary<string, FileContract> content)
        {
            var values = new Dictionary<string, Asset>(content.Count);
            foreach (var value in content.Select(MapFileContract))
            {
                values.Add(value.FileName, value);
            }

            return values;
        }
    }
}