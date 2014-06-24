// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingMaterial.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a crafting material.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.CraftingMaterials
{
    using GW2DotNET.Common;

    /// <summary>Represents a crafting material.</summary>
    [TypeDiscriminator(Value = "CraftingMaterial", BaseType = typeof(Item))]
    public class CraftingMaterial : Item
    {
    }
}