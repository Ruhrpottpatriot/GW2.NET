// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlot.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the InfusionSlot type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models.Items
{
    /// <summary>
    /// The infusion slot.
    /// </summary>
    public struct InfusionSlot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfusionSlot"/> struct.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="flags">
        /// The flags.
        /// </param>
        [JsonConstructor]
        public InfusionSlot(string item, IEnumerable<UpgradeFlag> flags)
            : this()
        {
            this.Flags = flags;
            this.Item = item;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        [JsonProperty("item")]
        public string Item { get; private set; }

        /// <summary>
        /// Gets the item flags.
        /// </summary>
        [JsonProperty("flags")]
        public IEnumerable<UpgradeFlag> Flags { get; private set; }
    }
}