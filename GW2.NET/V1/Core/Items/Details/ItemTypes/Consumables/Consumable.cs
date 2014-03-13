// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Consumable.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a consumable item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Consumables
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a consumable item.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class Consumable : Item
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Consumable" /> class.
        /// </summary>
        public Consumable()
            : base(ItemType.Consumable)
        {
        }

        /// <summary>
        ///     Gets or sets the consumable item's details.
        /// </summary>
        [JsonProperty("consumable", Order = 100)]
        public ConsumableDetails ConsumableItemDetails { get; set; }
    }
}