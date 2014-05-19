// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents a weapon.</summary>
    [JsonConverter(typeof(WeaponConverter))]
    public abstract class Weapon : Item, ISkinnable, IUpgrade, IUpgradable
    {
        /// <summary>Initializes a new instance of the <see cref="Weapon"/> class.</summary>
        /// <param name="weaponType">The weapon's type.</param>
        protected Weapon(WeaponType weaponType)
            : base(ItemType.Weapon, "weapon")
        {
            this.WeaponType = weaponType;
        }

        /// <summary>Gets or sets the weapon's damage type.</summary>
        [DataMember(Name = "damage_type", Order = 101)]
        public virtual WeaponDamageType DamageType { get; set; }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public int DefaultSkin { get; set; }

        /// <summary>Gets or sets the weapon's defense.</summary>
        [DataMember(Name = "defense", Order = 104)]
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the item's infix upgrade.</summary>
        [DataMember(Name = "infix_upgrade")]
        public virtual InfixUpgrade InfixUpgrade { get; set; }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        [DataMember(Name = "infusion_slots")]
        public virtual InfusionSlotCollection InfusionSlots { get; set; }

        /// <summary>Gets or sets the weapon's maximum power.</summary>
        [DataMember(Name = "max_power", Order = 103)]
        public virtual int MaximumPower { get; set; }

        /// <summary>Gets or sets the weapon's minimum power.</summary>
        [DataMember(Name = "min_power", Order = 102)]
        public virtual int MinimumPower { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item's ID.</summary>
        [DataMember(Name = "secondary_suffix_item_id")]
        public virtual int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item's ID.</summary>
        [DataMember(Name = "suffix_item_id")]
        public virtual int? SuffixItemId { get; set; }

        /// <summary>Gets or sets the weapon's type.</summary>
        [DataMember(Name = "weapon_type", Order = 100)]
        protected WeaponType WeaponType { get; set; }
    }
}