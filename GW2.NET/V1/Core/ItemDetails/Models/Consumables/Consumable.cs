// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Consumable.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Represents a consumable item.
    /// </summary>
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
        /// Initializes a new instance of the <see cref="Consumable"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The consumable item's ID.</param>
        /// <param name="name">The consumable item's name.</param>
        /// <param name="description">The consumable item's description.</param>
        /// <param name="type">The consumable item's type.</param>
        /// <param name="level">The consumable item's level.</param>
        /// <param name="rarity">The consumable item's rarity.</param>
        /// <param name="vendorValue">The consumable item's vendor value.</param>
        /// <param name="iconFileId">The consumable item's icon ID.</param>
        /// <param name="iconFileSignature">The consumable item's icon signature.</param>
        /// <param name="gameTypes">The consumable item's game types.</param>
        /// <param name="flags">The consumable item's additional flags.</param>
        /// <param name="restrictions">The consumable item's restrictions.</param>
        /// <param name="consumableDetails">The consumable item's details.</param>
        public Consumable(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, ConsumableDetails consumableDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.ConsumableDetails = consumableDetails;
        }

        /// <summary>
        /// Gets or sets the consumable item's details.
        /// </summary>
        [JsonProperty("consumable", Order = 100)]
        public ConsumableDetails ConsumableDetails { get; set; }
    }
}