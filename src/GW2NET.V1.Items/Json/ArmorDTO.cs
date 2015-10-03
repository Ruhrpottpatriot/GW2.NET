// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ArmorDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    public sealed class ArmorDTO
    {
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        [DataMember(Name = "weight_class", Order = 1)]
        public string WeightClass { get; set; }

        [DataMember(Name = "defense", Order = 2)]
        public string Defense { get; set; }

        [DataMember(Name = "infusion_slots", Order = 3)]
        public ICollection<InfusionSlotDTO> InfusionSlots { get; set; }

        [DataMember(Name = "infix_upgrade", Order = 4)]
        public InfixUpgradeDTO InfixUpgrade { get; set; }

        [DataMember(Name = "suffix_item_id", Order = 5)]
        public string SuffixItemId { get; set; }

        [DataMember(Name = "secondary_suffix_item_id", Order = 6)]
        public string SecondarySuffixItemId { get; set; }
    }
}