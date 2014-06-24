// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AquaticHelmSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an aquatic head protection skin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins.Details.Contracts.SkinTypes.Armors.ArmorTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents an aquatic head protection skin.</summary>
    [TypeDiscriminator(Value = "HelmAquatic", BaseType = typeof(ArmorSkin))]
    public class AquaticHelmSkin : ArmorSkin
    {
    }
}