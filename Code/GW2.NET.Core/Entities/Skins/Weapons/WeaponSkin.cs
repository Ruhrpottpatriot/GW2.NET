// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a weapon skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Skins
{
    using GW2NET.Entities.Items;

    /// <summary>Represents a weapon skin.</summary>
    public abstract class WeaponSkin : Skin
    {
        /// <summary>Gets or sets the weapon's damage type.</summary>
        public virtual WeaponDamageType DamageType { get; set; }
    }
}