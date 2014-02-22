// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemsInformation.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Common
{
    /// <summary>
    /// Represents detailed information about an in-game item.
    /// </summary>
    [JsonConverter(typeof(ItemConverter))]
    public abstract class Item : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class using the specified values.
        /// </summary>
        /// <param name="type">The item's type.</param>
        protected Item(ItemType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the item's ID.
        /// </summary>
        [JsonProperty("item_id", Order = 0)]
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the item's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item's description.
        /// </summary>
        [JsonProperty("description", Order = 2)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the item's type.
        /// </summary>
        [JsonProperty("type", Order = 3)]
        public ItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the item's level.
        /// </summary>
        [JsonProperty("level", Order = 4)]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the item's rarity.
        /// </summary>
        [JsonProperty("rarity", Order = 5)]
        public ItemRarity Rarity { get; set; }

        /// <summary>
        /// Gets or sets the item's vendor value.
        /// </summary>
        [JsonProperty("vendor_value", Order = 6)]
        public int VendorValue { get; set; }

        /// <summary>
        /// Gets or sets the item's icon ID for use with the render service.
        /// </summary>
        [JsonProperty("icon_file_id", Order = 7)]
        public int IconFileId { get; set; }

        /// <summary>
        /// Gets or sets the item's icon signature for use with the render service.
        /// </summary>
        [JsonProperty("icon_file_signature", Order = 8)]
        public string IconFileSignature { get; set; }

        /// <summary>
        /// Gets or sets the item's game types.
        /// </summary>
        [JsonProperty("game_types", Order = 9)]
        public GameTypes GameTypes { get; set; }

        /// <summary>
        /// Gets or sets the item's additional flags.
        /// </summary>
        [JsonProperty("flags", Order = 10)]
        public ItemFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the item's restrictions.
        /// </summary>
        [JsonProperty("restrictions", Order = 11)]
        public ItemRestrictions Restrictions { get; set; }
    }
}