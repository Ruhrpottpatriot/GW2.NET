// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ItemsInformation.Details;

namespace RestSharp.Requests
{
    /// <summary>
    ///     Represents a request for details regarding a specific item.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details" /> for more information.
    /// </remarks>
    public class ItemDetailsRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemDetailsRequest" /> class.
        /// </summary>
        /// <param name="itemId">The item's ID.</param>
        public ItemDetailsRequest(int itemId)
            : base(Resources.ItemDetails)
        {
            this.AddParameter("item_id", itemId);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemDetailsRequest" /> class.
        /// </summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="languageInfo">The output language.</param>
        public ItemDetailsRequest(int itemId, CultureInfo languageInfo)
            : base(Resources.ItemDetails, languageInfo)
        {
            this.AddParameter("item_id", itemId);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Item> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<Item>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Item>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<Item>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Item>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<Item>(serviceClient, cancellationToken);
        }
    }
}