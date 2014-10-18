// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ArmorContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class ArmorContract
    {
        [DataMember(Name = "defense", Order = 2)]
        internal string Defense { get; set; }

        [DataMember(Name = "infix_upgrade", Order = 4)]
        internal InfixUpgradeContract InfixUpgrade { get; set; }

        [DataMember(Name = "infusion_slots", Order = 3)]
        internal ICollection<InfusionSlotContract> InfusionSlots { get; set; }

        [DataMember(Name = "secondary_suffix_item_id", Order = 6)]
        internal string SecondarySuffixItemId { get; set; }

        [DataMember(Name = "suffix_item_id", Order = 5)]
        internal string SuffixItemId { get; set; }

        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        [DataMember(Name = "weight_class", Order = 1)]
        internal string WeightClass { get; set; }
    }
}