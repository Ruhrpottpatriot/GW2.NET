// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the TrinketContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class TrinketContract
    {
        [DataMember(Name = "infix_upgrade", Order = 2)]
        internal InfixUpgradeContract InfixUpgrade { get; set; }

        [DataMember(Name = "infusion_slots", Order = 1)]
        internal ICollection<InfusionSlotContract> InfusionSlots { get; set; }

        [DataMember(Name = "secondary_suffix_item_id", Order = 4)]
        internal string SecondarySuffixItemId { get; set; }

        [DataMember(Name = "suffix_item_id", Order = 3)]
        internal string SuffixItemId { get; set; }

        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }
    }
}