// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.UpgradeComponents
{
    /// <summary>
    /// Represents detailed information about an upgrade component.
    /// </summary>
    public class UpgradeComponentItemDetails : ItemDetailsBase
    {
        /// <summary>
        /// Gets or sets the upgrade component's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public UpgradeComponentType Type { get; set; }

        /// <summary>
        /// Gets or sets the upgrade component's flags.
        /// </summary>
        [JsonProperty("flags", Order = 1)]
        public UpgradeComponentFlags Flags { get; set; }

        /// <summary>
        /// Gets or sets the upgrade component's infusion upgrades.
        /// </summary>
        [JsonProperty("infusion_upgrade_flags", Order = 2)]
        public InfusionSlotTypes InfusionUpgradeFlags { get; set; }

        /// <summary>
        /// Gets or sets the upgrade component's bonuses.
        /// </summary>
        [JsonProperty("bonuses", Order = 3)]
        public IEnumerable<string> Bonuses { get; set; }

        /// <summary>
        /// Gets or sets the upgrade component's infix upgrade.
        /// </summary>
        [JsonProperty("infix_upgrade", Order = 4)]
        public InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>
        /// Gets or sets the upgrade component's suffix.
        /// </summary>
        [JsonProperty("suffix", Order = 5, NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }
    }
}