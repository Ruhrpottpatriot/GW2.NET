// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails
{
    /// <summary>
    /// Represents a response that is the result of an <see cref="ItemDetailsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/item_details"/> for more information.
    /// </remarks>
    [JsonConverter(typeof(ItemDetailsResponseConverter))]
    public class ItemDetailsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDetailsResponse"/> class.
        /// </summary>
        public ItemDetailsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemDetailsResponse"/> class using the specified values.
        /// </summary>
        /// <param name="itemDetails">The item details.</param>
        public ItemDetailsResponse(Item itemDetails)
        {
            this.ItemDetails = itemDetails;
        }

        /// <summary>
        /// Gets or sets the item details.
        /// </summary>
        public Item ItemDetails { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}