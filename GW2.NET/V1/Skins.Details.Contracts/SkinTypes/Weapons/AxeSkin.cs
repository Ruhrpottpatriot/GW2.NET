// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AxeSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an axe skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Weapons
{
    using GW2DotNET.Common;

    /// <summary>Represents an axe skin.</summary>
    [TypeDiscriminator(Value = "Axe", BaseType = typeof(WeaponSkin))]
    public class AxeSkin : WeaponSkin
    {
    }
}