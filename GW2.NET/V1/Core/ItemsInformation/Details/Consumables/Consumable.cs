// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Consumable.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Consumables
{
    /// <summary>
    /// Represents a consumable item.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class Consumable : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Consumable"/> class.
        /// </summary>
        public Consumable()
            : base(ItemType.Consumable)
        {
        }

        /// <summary>
        /// Gets or sets the consumable item's details.
        /// </summary>
        [JsonProperty("consumable", Order = 100)]
        public ConsumableItemDetails ConsumableItemDetails { get; set; }
    }
}