// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Contracts.Weapons
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;
    using GW2DotNET.V1.Items.Contracts.Weapons;

    /// <summary>Represents a weapon skin.</summary>
    [TypeDiscriminator(Value = "Weapon", BaseType = typeof(Skin))]
    public abstract class WeaponSkin : Skin
    {
        /// <summary>Gets or sets the weapon's damage type.</summary>
        [DataMember(Name = "damage_type")]
        public WeaponDamageType DamageType { get; set; }
    }
}