// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the skins service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Skins.Contracts;

    /// <summary>Provides the default implementation of the skins service.</summary>
    public class SkinService : ISkinService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinService" /> class.</summary>
        public SkinService()
            : this(new ServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SkinService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public SkinService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public IEnumerable<int> GetSkins()
        {
            var serviceRequest = new SkinRequest();
            var result = this.serviceClient.Send<SkinCollectionResult>(serviceRequest);

            return result.Skins;
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetSkinsAsync()
        {
            return this.GetSkinsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        public Task<IEnumerable<int>> GetSkinsAsync(CancellationToken cancellationToken)
        {
            var serviceRequest = new SkinRequest();
            var t1 = this.serviceClient.SendAsync<SkinCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<int>>(task => task.Result.Skins, cancellationToken);

            return t2;
        }
    }
}