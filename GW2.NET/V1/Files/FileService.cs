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
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Files.Contracts;

    /// <summary>Provides the default implementation of the files service.</summary>
    public class FileService : IFileService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FileService" /> class.</summary>
        public FileService()
            : this(new ServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FileService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public FileService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public IEnumerable<Asset> GetFiles()
        {
            var serviceRequest = new FileRequest();
            var result = this.serviceClient.Send<AssetCollection>(serviceRequest);

            return result.Values;
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Asset>> GetFilesAsync()
        {
            return this.GetFilesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        public Task<IEnumerable<Asset>> GetFilesAsync(CancellationToken cancellationToken)
        {
            var serviceRequest = new FileRequest();
            var t1 = this.serviceClient.SendAsync<AssetCollection>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<Asset>>(task => task.Result.Values, cancellationToken);

            return t2;
        }
    }
}