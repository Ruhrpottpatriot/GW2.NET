// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TwoHandedToyWeaponSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a two-handed toy skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Weapons.WeaponTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents a two-handed toy skin.</summary>
    [TypeDiscriminator(Value = "TwoHandedToy", BaseType = typeof(WeaponSkin))]
    public class TwoHandedToyWeaponSkin : WeaponSkin
    {
    }
}