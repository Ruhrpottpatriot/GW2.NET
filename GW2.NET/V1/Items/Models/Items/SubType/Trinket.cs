// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Trinket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// The trinket.
    /// </summary>
    [Serializable]
    public class Trinket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Trinket"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="suffixId">
        /// The suffix id.
        /// </param>
        /// <param name="infusionSlots">
        /// The infusion slots.
        /// </param>
        /// <param name="infixUpgrade">
        /// The infix upgrade.
        /// </param>
        [JsonConstructor]
        public Trinket(TrinketType type, int suffixId, IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade)

        {
            this.InfixUpgrade = infixUpgrade;
            this.InfusionSlots = infusionSlots;
            this.SuffixId = suffixId;
            this.Type = type;
        }

        /// <summary>
        /// Enumerates the trinket types.
        /// </summary>
        public enum TrinketType
        {
            /// <summary>
            /// The trinket is a ring.
            /// </summary>
            Ring,

            /// <summary>
            /// The trinket is an accessory.
            /// </summary>
            Accessory,

            /// <summary>
            /// The trinket is an amulet.
            /// </summary>
            Amulet,
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty("type")]
        public TrinketType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the suffix id.
        /// </summary>
        [JsonProperty("suffix_item_id")]
        public int SuffixId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the infusion slots.
        /// </summary>
        [JsonProperty("infusion_slots")]
        public IEnumerable<InfusionSlot> InfusionSlots
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the infix upgrade.
        /// </summary>
        [JsonProperty("infix_upgrade")]
        public InfixUpgrade InfixUpgrade
        {
            get;
            private set;
        }
    }
}
