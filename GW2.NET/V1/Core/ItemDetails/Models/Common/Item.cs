// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Common
{
    /// <summary>
    /// Represents detailed information about an in-game item.
    /// </summary>
    [JsonConverter(typeof(ItemConverter))]
    public class Item
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
        /// Initializes a new instance of the <see cref="Item"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The item's ID.</param>
        /// <param name="name">The item's name.</param>
        /// <param name="description">The item's description.</param>
        /// <param name="type">The item's type.</param>
        /// <param name="level">The item's level.</param>
        /// <param name="rarity">The item's rarity.</param>
        /// <param name="vendorValue">The item's vendor value.</param>
        /// <param name="iconFileId">The item's icon ID.</param>
        /// <param name="iconFileSignature">The item's icon signature.</param>
        /// <param name="gameTypes">The item's game types.</param>
        /// <param name="flags">The item's additional flags.</param>
        /// <param name="restrictions">The item's restrictions.</param>
        protected Item(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions)
        {
            this.ItemId = itemId;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Level = level;
            this.Rarity = rarity;
            this.VendorValue = vendorValue;
            this.IconFileId = iconFileId;
            this.IconFileSignature = iconFileSignature;
            this.GameTypes = gameTypes;
            this.Flags = flags;
            this.Restrictions = restrictions;
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