// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipmentItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Common
{
    /// <summary>
    /// Represents detailed information about an armor piece.
    /// </summary>
    public abstract class EquipmentItemDetails : ItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentItemDetails"/> class.
        /// </summary>
        protected EquipmentItemDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentItemDetails"/> class.
        /// </summary>
        /// <param name="infusionSlots">The item's infusion slots.</param>
        /// <param name="infixUpgrade">The item's infix upgrade.</param>
        /// <param name="suffixItemId">The item's suffix item ID.</param>
        protected EquipmentItemDetails(IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade, int? suffixItemId)
        {
            this.InfusionSlots = infusionSlots;
            this.InfixUpgrade = infixUpgrade;
            this.SuffixItemId = suffixItemId;
        }

        /// <summary>
        /// Gets or sets the item's infix upgrade.
        /// </summary>
        [JsonProperty("infix_upgrade", Order = 101, NullValueHandling = NullValueHandling.Ignore)]
        public InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>
        /// Gets or sets the item's infusion slots.
        /// </summary>
        [JsonProperty("infusion_slots", Order = 100)]
        public IEnumerable<InfusionSlot> InfusionSlots { get; set; }

        /// <summary>
        /// Gets or sets the item's suffix item's ID.
        /// </summary>
        [JsonProperty("suffix_item_id", Order = 102, NullValueHandling = NullValueHandling.Ignore)]
        public int? SuffixItemId { get; set; }
    }
}