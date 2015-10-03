// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WeaponDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    public sealed class WeaponDTO
    {
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "damage_type", Order = 1)]
        public string DamageType { get; set; }

        [DataMember(Name = "min_power", Order = 2)]
        public string MinimumPower { get; set; }

        [DataMember(Name = "max_power", Order = 3)]
        public string MaximumPower { get; set; }

        [DataMember(Name = "defense", Order = 4)]
        public string Defense { get; set; }

        [DataMember(Name = "infusion_slots", Order = 5)]
        public ICollection<InfusionSlotDTO> InfusionSlots { get; set; }

        [DataMember(Name = "infix_upgrade", Order = 6)]
        public InfixUpgradeDTO InfixUpgrade { get; set; }

        [DataMember(Name = "suffix_item_id", Order = 7)]
        public string SuffixItemId { get; set; }

        [DataMember(Name = "secondary_suffix_item_id", Order = 8)]
        public string SecondarySuffixItemId { get; set; }
    }
}