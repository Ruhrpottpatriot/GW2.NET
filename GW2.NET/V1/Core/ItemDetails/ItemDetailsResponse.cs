// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Converters;
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
    public class ItemDetailsResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets the item details.
        /// </summary>
        public Item ItemDetails { get; set; }
    }
}