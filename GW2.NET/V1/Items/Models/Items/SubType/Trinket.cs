// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Trinket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    using Newtonsoft.Json;

    public struct Trinket
    {
        [JsonConstructor]
        public Trinket(TrinketType type, int? suffixId, IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade)
            : this()
        {
            this.InfixUpgrade = infixUpgrade;
            this.InfusionSlots = infusionSlots;
            this.SuffixId = suffixId;
            this.Type = type;
        }

        [JsonProperty("type")]
        public TrinketType Type
        {
            get;
            private set;
        }

        [JsonProperty("suffix_item_id")]
        public int? SuffixId
        {
            get;
            private set;
        }

        [JsonProperty("infusion_slots")]
        public IEnumerable<InfusionSlot> InfusionSlots
        {
            get;
            private set;
        }

        [JsonProperty("infix_upgrade")]
        public InfixUpgrade InfixUpgrade
        {
            get;
            private set;
        }

        public enum TrinketType
        {
            Ring,
            Accessory,
            Amulet,
        }
    }
}
