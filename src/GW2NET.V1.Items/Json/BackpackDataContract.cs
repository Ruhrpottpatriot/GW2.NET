// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackpackDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the BackpackDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Items.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    internal sealed class BackpackDataContract
    {
        [DataMember(Name = "infusion_slots", Order = 0)]
        internal ICollection<InfusionSlotDataContract> InfusionSlots { get; set; }

        [DataMember(Name = "infix_upgrade", Order = 1)]
        internal InfixUpgradeDataContract InfixUpgrade { get; set; }

        [DataMember(Name = "suffix_item_id", Order = 2)]
        internal string SuffixItemId { get; set; }

        [DataMember(Name = "secondary_suffix_item_id", Order = 3)]
        internal string SecondarySuffixItemId { get; set; }
    }
}