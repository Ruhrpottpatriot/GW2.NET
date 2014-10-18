// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the UpgradeComponentContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class UpgradeComponentContract
    {
        [DataMember(Name = "bonuses", Order = 3)]
        internal ICollection<string> Bonuses { get; set; }

        [DataMember(Name = "flags", Order = 1)]
        internal ICollection<string> Flags { get; set; }

        [DataMember(Name = "infix_upgrade", Order = 4)]
        internal InfixUpgradeContract InfixUpgrade { get; set; }

        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        internal ICollection<string> InfusionUpgradeFlags { get; set; }

        [DataMember(Name = "suffix", Order = 5)]
        internal string Suffix { get; set; }

        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }
    }
}