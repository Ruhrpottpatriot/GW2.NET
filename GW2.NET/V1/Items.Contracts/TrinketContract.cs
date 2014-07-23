// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a trinket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a trinket.</summary>
    public sealed class TrinketContract : ServiceContract
    {
        /// <summary>Gets or sets the trinket's infixed upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 2)]
        public InfixUpgradeContract InfixUpgrade { get; set; }

        /// <summary>Gets or sets the trinket's infusion slots.</summary>
        [DataMember(Name = "infusion_slots", Order = 1)]
        public ICollection<InfusionSlotContract> InfusionSlots { get; set; }

        /// <summary>Gets or sets the trinket's secondary suffix item.</summary>
        [DataMember(Name = "secondary_suffix_item_id", Order = 4)]
        public string SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the trinket's suffix item.</summary>
        [DataMember(Name = "suffix_item_id", Order = 3)]
        public string SuffixItemId { get; set; }

        /// <summary>Gets or sets the trinket type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}