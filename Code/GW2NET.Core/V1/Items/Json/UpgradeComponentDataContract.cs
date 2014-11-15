// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the UpgradeComponentDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    internal sealed class UpgradeComponentDataContract
    {
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        [DataMember(Name = "flags", Order = 1)]
        internal ICollection<string> Flags { get; set; }

        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        internal ICollection<string> InfusionUpgradeFlags { get; set; }

        [DataMember(Name = "bonuses", Order = 3)]
        internal ICollection<string> Bonuses { get; set; }

        [DataMember(Name = "infix_upgrade", Order = 4)]
        internal InfixUpgradeDataContract InfixUpgrade { get; set; }

        [DataMember(Name = "suffix", Order = 5)]
        internal string Suffix { get; set; }
    }
}