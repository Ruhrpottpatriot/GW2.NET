// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Converters;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Represents detailed information about a consumable item.
    /// </summary>
    [JsonConverter(typeof(ConsumableDetailsConverter))]
    public class ConsumableItemDetails : ItemDetailsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableItemDetails"/> class.
        /// </summary>
        public ConsumableItemDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableItemDetails"/> class using the specified values.
        /// </summary>
        /// <param name="type">The consumable's type.</param>
        public ConsumableItemDetails(ConsumableType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the consumable's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ConsumableType Type { get; set; }
    }
}