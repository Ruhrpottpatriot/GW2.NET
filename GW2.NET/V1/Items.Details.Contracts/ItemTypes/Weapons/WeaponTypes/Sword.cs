// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sword.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a sword.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons.WeaponTypes
{
    /// <summary>Represents detailed information about a sword.</summary>
    public class Sword : Weapon
    {
        /// <summary>Initializes a new instance of the <see cref="Sword" /> class.</summary>
        public Sword()
            : base(WeaponType.Sword)
        {
        }
    }
}