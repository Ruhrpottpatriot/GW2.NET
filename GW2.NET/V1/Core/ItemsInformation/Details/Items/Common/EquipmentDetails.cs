// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipmentDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Common
{
    /// <summary>
    /// Represents detailed information about a piece of combat equipment.
    /// </summary>
    public abstract class EquipmentDetails : JsonObject
    {
        /// <summary>
        /// Gets or sets the item's infix upgrade.
        /// </summary>
        [JsonProperty(PropertyName = "infix_upgrade", Order = 101, NullValueHandling = NullValueHandling.Ignore)]
        public InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>
        /// Gets or sets the item's infusion slots.
        /// </summary>
        [JsonProperty(PropertyName = "infusion_slots", Order = 100)]
        public InfusionSlotCollection InfusionSlots { get; set; }

        /// <summary>
        /// Gets or sets the item's suffix item's ID.
        /// </summary>
        [JsonProperty(PropertyName = "suffix_item_id", Order = 102)]
        public int? SuffixItemId { get; set; }
    }
}