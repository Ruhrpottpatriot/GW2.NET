// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingMaterial.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a crafting material.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.ItemsDetails.Types.ItemTypes.CraftingMaterials
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a crafting material.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class CraftingMaterial : Item
    {
        /// <summary>Initializes a new instance of the <see cref="CraftingMaterial" /> class.</summary>
        public CraftingMaterial()
            : base(ItemType.CraftingMaterial)
        {
        }
    }
}