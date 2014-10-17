// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an armor piece.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents an armor piece.</summary>
    [DataContract]
    public sealed class ArmorContract
    {
        /// <summary>Gets or sets the armor's defense rating.</summary>
        [DataMember(Name = "defense", Order = 2)]
        public string Defense { get; set; }

        /// <summary>Gets or sets the armor's infixed upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 4)]
        public InfixUpgradeContract InfixUpgrade { get; set; }

        /// <summary>Gets or sets the armor's infusion slots.</summary>
        [DataMember(Name = "infusion_slots", Order = 3)]
        public ICollection<InfusionSlotContract> InfusionSlots { get; set; }

        /// <summary>Gets or sets the armor's secondary suffix item.</summary>
        [DataMember(Name = "secondary_suffix_item_id", Order = 6)]
        public string SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the armor's suffix item.</summary>
        [DataMember(Name = "suffix_item_id", Order = 5)]
        public string SuffixItemId { get; set; }

        /// <summary>Gets or sets the armor type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        /// <summary>Gets or sets the armor's weight class.</summary>
        [DataMember(Name = "weight_class", Order = 1)]
        public string WeightClass { get; set; }
    }
}