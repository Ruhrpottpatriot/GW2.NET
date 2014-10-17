// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>Represents a weapon.</summary>
    [DataContract]
    public sealed class WeaponContract
    {
        /// <summary>Gets or sets the weapon's damage type.</summary>
        [DataMember(Name = "damage_type", Order = 1)]
        public string DamageType { get; set; }

        /// <summary>Gets or sets the weapon's defense rating.</summary>
        [DataMember(Name = "defense", Order = 4)]
        public string Defense { get; set; }

        /// <summary>Gets or sets the weapon's infixed upgrade.</summary>
        [DataMember(Name = "infix_upgrade", Order = 6)]
        public InfixUpgradeContract InfixUpgrade { get; set; }

        /// <summary>Gets or sets the weapon's infusion slots.</summary>
        [DataMember(Name = "infusion_slots", Order = 5)]
        public ICollection<InfusionSlotContract> InfusionSlots { get; set; }

        /// <summary>Gets or sets the weapon's maximum power rating.</summary>
        [DataMember(Name = "max_power", Order = 3)]
        public string MaximumPower { get; set; }

        /// <summary>Gets or sets the weapon's minimum power rating.</summary>
        [DataMember(Name = "min_power", Order = 2)]
        public string MinimumPower { get; set; }

        /// <summary>Gets or sets the weapon's secondary suffix item.</summary>
        [DataMember(Name = "secondary_suffix_item_id", Order = 8)]
        public string SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the weapon's suffix item.</summary>
        [DataMember(Name = "suffix_item_id", Order = 7)]
        public string SuffixItemId { get; set; }

        /// <summary>Gets or sets the weapon type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}