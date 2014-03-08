// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ItemsInformation.Catalogs;

namespace GW2DotNET.V1.RestSharp.Requests
{
    /// <summary>
    ///     Represents a request for a list of all discovered items.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/items" /> for more information.
    /// </remarks>
    public class ItemsRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemsRequest" /> class.
        /// </summary>
        public ItemsRequest()
            : base(Resources.Items)
        {
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<ItemsResult> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<ItemsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ItemsResult>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<ItemsResult>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<ItemsResult>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<ItemsResult>(serviceClient, cancellationToken);
        }
    }
}