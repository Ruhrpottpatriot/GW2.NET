// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GW2DotNET.V1.Core.ItemDetails
{
    /// <summary>
    /// Represents a request for details regarding a specific item.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details"/> for more information.
    /// </remarks>
    public class ItemDetailsRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDetailsRequest"/> class using the specified item ID.
        /// </summary>
        /// <param name="itemId">The item's ID.</param>
        public ItemDetailsRequest(int itemId)
            : base(new Uri(Resources.ItemDetails + "?item_id={item_id}", UriKind.Relative))
        {
            this.AddUrlSegment("item_id", itemId.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDetailsRequest"/> class using the specified item ID and the specified language.
        /// </summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="language">The output language. Supported values are enumerated in <see cref="SupportedLanguages"/>.</param>
        public ItemDetailsRequest(int itemId, CultureInfo language)
            : base(new Uri(Resources.ItemDetails + "?item_id={item_id}&lang={language}", UriKind.Relative))
        {
            this.AddUrlSegment("item_id", itemId.ToString());
            this.AddUrlSegment("lang", language.TwoLetterISOLanguageName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="ItemDetailsResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="ItemDetailsResponse"/>.</returns>
        public IApiResponse<ItemDetailsResponse> GetResponse(IApiClient handler)
        {
            return base.GetResponse<ItemDetailsResponse>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="ItemDetailsResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="ItemDetailsResponse"/>.</returns>
        public Task<IApiResponse<ItemDetailsResponse>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<ItemDetailsResponse>(handler);
        }
    }
}
