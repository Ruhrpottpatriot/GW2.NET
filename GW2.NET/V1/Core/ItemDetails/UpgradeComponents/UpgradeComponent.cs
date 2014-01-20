// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.UpgradeComponents
{
    /// <summary>
    /// Represents an upgrade component.
    /// </summary>
    public class UpgradeComponent : Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpgradeComponent"/> class.
        /// </summary>
        public UpgradeComponent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpgradeComponent"/> class using the specified values.
        /// </summary>
        /// <param name="itemId">The upgrade component's ID.</param>
        /// <param name="name">The upgrade component's name.</param>
        /// <param name="description">The upgrade component's description.</param>
        /// <param name="type">The upgrade component's type.</param>
        /// <param name="level">The upgrade component's level.</param>
        /// <param name="rarity">The upgrade component's rarity.</param>
        /// <param name="vendorValue">The upgrade component's vendor value.</param>
        /// <param name="iconFileId">The upgrade component's icon ID.</param>
        /// <param name="iconFileSignature">The upgrade component's icon signature.</param>
        /// <param name="gameTypes">The upgrade component's game types.</param>
        /// <param name="flags">The upgrade component's additional flags.</param>
        /// <param name="restrictions">The upgrade component's restrictions.</param>
        /// <param name="upgradeComponentDetails">The upgrade component's details.</param>
        public UpgradeComponent(int itemId, string name, string description, ItemType type, int level, ItemRarity rarity, int vendorValue, int iconFileId, string iconFileSignature, GameTypes gameTypes, ItemFlags flags, ItemRestrictions restrictions, UpgradeComponentDetails upgradeComponentDetails)
            : base(itemId, name, description, type, level, rarity, vendorValue, iconFileId, iconFileSignature, gameTypes, flags, restrictions)
        {
            this.UpgradeComponentDetails = upgradeComponentDetails;
        }

        /// <summary>
        /// Gets or sets the upgrade component's details.
        /// </summary>
        [JsonProperty("upgrade_component", Order = 100)]
        public UpgradeComponentDetails UpgradeComponentDetails { get; set; }
    }
}