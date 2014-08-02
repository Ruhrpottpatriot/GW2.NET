// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an upgrade component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents an upgrade component.</summary>
    [DataContract]
    public sealed class UpgradeComponentContract
    {
        /// <summary>Gets or sets the upgrade component's bonuses.</summary>
        [DataMember(Name = "bonuses", Order = 3)]
        public ICollection<string> Bonuses { get; set; }

        /// <summary>Gets or sets the upgrade component's flags.</summary>
        [DataMember(Name = "flags", Order = 1)]
        public ICollection<string> Flags { get; set; }

        /// <summary>Gets or sets the upgrade component's infixed upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 4)]
        public InfixUpgradeContract InfixUpgrade { get; set; }

        /// <summary>Gets or sets the upgrade component's infusion upgrades.</summary>
        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        public ICollection<string> InfusionUpgradeFlags { get; set; }

        /// <summary>Gets or sets the upgrade component's suffix.</summary>
        [DataMember(Name = "suffix", Order = 5)]
        public string Suffix { get; set; }

        /// <summary>Gets or sets the upgrade component type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}