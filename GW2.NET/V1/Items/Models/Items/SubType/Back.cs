// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Back.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Back type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items.SubType
{
    /// <summary>
    /// The item in the back slot.
    /// </summary>
    public struct Back
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Back"/> struct.
        /// </summary>
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
        public Back(int suffixId, IEnumerable<InfusionSlot> infusionSlots, InfixUpgrade infixUpgrade)
            : this()
        {
            this.InfixUpgrade = infixUpgrade;
            this.InfusionSlots = infusionSlots;
            this.SuffixId = suffixId;
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
