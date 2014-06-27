// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarHornSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a war horn skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Contracts.Weapons
{
    using GW2DotNET.Common;

    /// <summary>Represents a war horn skin.</summary>
    [TypeDiscriminator(Value = "Warhorn", BaseType = typeof(WeaponSkin))]
    public class WarHornSkin : WeaponSkin
    {
    }
}