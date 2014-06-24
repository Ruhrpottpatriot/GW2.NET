// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaceSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a mace skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Weapons
{
    using GW2DotNET.Common;

    /// <summary>Represents a mace skin.</summary>
    [TypeDiscriminator(Value = "Mace", BaseType = typeof(WeaponSkin))]
    public class MaceSkin : WeaponSkin
    {
    }
}