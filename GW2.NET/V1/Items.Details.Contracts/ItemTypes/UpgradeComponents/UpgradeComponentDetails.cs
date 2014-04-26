// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about an upgrade component.</summary>
    [JsonConverter(typeof(UpgradeComponentDetailsConverter))]
    public abstract class UpgradeComponentDetails : ItemDetails
    {
        /// <summary>Infrastructure. Stores type information.</summary>
        private readonly UpgradeComponentType type;

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponentDetails"/> class.</summary>
        /// <param name="upgradeComponentType">The upgrade component's type.</param>
        protected UpgradeComponentDetails(UpgradeComponentType upgradeComponentType)
        {
            this.type = upgradeComponentType;
        }

        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        [DataMember(Name = "bonuses", Order = 3)]
        public UpgradeBonusCollection Bonuses { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        [DataMember(Name = "flags", Order = 1)]
        public UpgradeComponentFlags Flags { get; set; }

        /// <summary>Gets or sets the upgrade component's infix upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 4)]
        public InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        public InfusionSlotTypes InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        [DataMember(Name = "suffix", Order = 5)]
        public string Suffix { get; set; }

        /// <summary>Gets the upgrade component's type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public UpgradeComponentType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}