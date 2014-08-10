// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackpackContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a backpack.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a backpack.</summary>
    [DataContract]
    public sealed class BackpackContract
    {
        /// <summary>Gets or sets the backpack's infixed upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 1)]
        public InfixUpgradeContract InfixUpgrade { get; set; }

        /// <summary>Gets or sets the backpack's infusion slots.</summary>
        [DataMember(Name = "infusion_slots", Order = 0)]
        public ICollection<InfusionSlotContract> InfusionSlots { get; set; }

        /// <summary>Gets or sets the backpack's secondary suffix item.</summary>
        [DataMember(Name = "secondary_suffix_item_id", Order = 3)]
        public string SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the backpack's suffix item.</summary>
        [DataMember(Name = "suffix_item_id", Order = 2)]
        public string SuffixItemId { get; set; }
    }
}