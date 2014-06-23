// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weapon.cs" company="GW2.NET Coding Team">
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

    /// <summary>Represents a weapon.</summary>
    public abstract class Weapon : CombatItem, ISkinnable
    {
        /// <summary>Initializes a new instance of the <see cref="Weapon"/> class.</summary>
        /// <param name="weaponType">The weapon's type.</param>
        protected Weapon(WeaponType weaponType)
            : base(ItemType.Weapon)
        {
            this.WeaponType = weaponType;
        }

        /// <summary>Gets or sets the weapon's damage type.</summary>
        [DataMember(Name = "damage_type")]
        public virtual WeaponDamageType DamageType { get; set; }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public int DefaultSkin { get; set; }

        /// <summary>Gets or sets the weapon's defense.</summary>
        [DataMember(Name = "defense")]
        public virtual int Defense { get; set; }

        /// <summary>Gets or sets the weapon's maximum power.</summary>
        [DataMember(Name = "max_power")]
        public virtual int MaximumPower { get; set; }

        /// <summary>Gets or sets the weapon's minimum power.</summary>
        [DataMember(Name = "min_power")]
        public virtual int MinimumPower { get; set; }

        /// <summary>Gets or sets the weapon's type.</summary>
        [DataMember(Name = "weapon_type")]
        protected WeaponType WeaponType { get; set; }

        /// <summary>Gets the name of the property that provides additional information.</summary>
        /// <returns>The name of the property.</returns>
        protected override string GetTypeKey()
        {
            return "weapon";
        }
    }
}