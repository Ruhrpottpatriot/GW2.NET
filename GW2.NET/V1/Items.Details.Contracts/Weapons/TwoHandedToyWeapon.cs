// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TwoHandedToyWeapon.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a two-handed toy.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Weapons
{
    using GW2DotNET.Common;

    /// <summary>Represents a two-handed toy.</summary>
    [TypeDiscriminator(Value = "TwoHandedToy", BaseType = typeof(Weapon))]
    public class TwoHandedToyWeapon : Weapon
    {
    }
}