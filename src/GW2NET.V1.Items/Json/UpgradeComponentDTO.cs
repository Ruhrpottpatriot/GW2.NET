// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the UpgradeComponentDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    public sealed class UpgradeComponentDTO
    {
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "flags", Order = 1)]
        public ICollection<string> Flags { get; set; }

        [DataMember(Name = "infusion_upgrade_flags", Order = 2)]
        public ICollection<string> InfusionUpgradeFlags { get; set; }

        [DataMember(Name = "bonuses", Order = 3)]
        public ICollection<string> Bonuses { get; set; }

        [DataMember(Name = "infix_upgrade", Order = 4)]
        public InfixUpgradeDTO InfixUpgrade { get; set; }

        [DataMember(Name = "suffix", Order = 5)]
        public string Suffix { get; set; }
    }
}