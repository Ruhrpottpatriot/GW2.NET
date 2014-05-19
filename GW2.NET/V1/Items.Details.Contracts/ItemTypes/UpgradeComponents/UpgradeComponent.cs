// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents an upgrade component.</summary>
    [JsonConverter(typeof(UpgradeComponentConverter))]
    public class UpgradeComponent : Item, IUpgrade
    {
        /// <summary>Initializes a new instance of the <see cref="UpgradeComponent"/> class.</summary>
        /// <param name="upgradeComponentType">The upgrade component's type.</param>
        public UpgradeComponent(UpgradeComponentType upgradeComponentType)
            : base(ItemType.UpgradeComponent, "upgrade_component")
        {
            this.UpgradeComponentType = upgradeComponentType;
        }

        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        [DataMember(Name = "bonuses", Order = 103)]
        public virtual UpgradeBonusCollection Bonuses { get; set; }

        /// <summary>Gets or sets the upgrade component's infix upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 104)]
        public virtual InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        [DataMember(Name = "infusion_upgrade_flags", Order = 102)]
        public virtual InfusionSlotTypes InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        [DataMember(Name = "suffix", Order = 105)]
        public virtual string Suffix { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        [DataMember(Name = "upgrade_component_flags", Order = 101)]
        public virtual UpgradeComponentFlags UpgradeComponentFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's type.</summary>
        [DataMember(Name = "upgrade_component_type", Order = 100)]
        protected UpgradeComponentType UpgradeComponentType { get; set; }
    }
}