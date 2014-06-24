// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmallBundleSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a small bundle skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Weapons
{
    using GW2DotNET.Common;

    /// <summary>Represents a small bundle skin.</summary>
    [TypeDiscriminator(Value = "SmallBundle", BaseType = typeof(WeaponSkin))]
    public class SmallBundleSkin : WeaponSkin
    {
    }
}