// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a weapon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Weapons
{
    using System;

    using GW2DotNET.V1.Core.Items.Details.ItemTypes.Common;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a weapon.</summary>
    [JsonConverter(typeof(WeaponDetailsConverter))]
    public abstract class WeaponDetails : EquipmentDetails, IEquatable<WeaponDetails>
    {
        /// <summary>Infrastructure. Stores type information.</summary>
        private readonly WeaponType type;

        /// <summary>Initializes a new instance of the <see cref="WeaponDetails"/> class.</summary>
        /// <param name="weaponType">The weapon's type.</param>
        protected WeaponDetails(WeaponType weaponType)
        {
            this.type = weaponType;
        }

        /// <summary>Gets or sets the weapon's damage type.</summary>
        [JsonProperty("damage_type", Order = 1)]
        public WeaponDamageType DamageType { get; set; }

        /// <summary>Gets or sets the weapon's defense.</summary>
        [JsonProperty("defense", Order = 4)]
        public int Defense { get; set; }

        /// <summary>Gets or sets the weapon's maximum power.</summary>
        [JsonProperty("max_power", Order = 3)]
        public int MaximumPower { get; set; }

        /// <summary>Gets or sets the weapon's minimum power.</summary>
        [JsonProperty("min_power", Order = 2)]
        public int MinimumPower { get; set; }

        /// <summary>Gets the weapon's type.</summary>
        [JsonProperty("type", Order = 0)]
        public WeaponType Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>Gets or sets the weapon.</summary>
        public Weapon Weapon { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(WeaponDetails left, WeaponDetails right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(WeaponDetails left, WeaponDetails right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(WeaponDetails other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return object.Equals(this.Weapon, other.Weapon);
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((WeaponDetails)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.Weapon != null ? this.Weapon.GetHashCode() : 0;
        }
    }
}