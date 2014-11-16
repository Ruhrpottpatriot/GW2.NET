// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCraftingMaterial.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="CraftingMaterial" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Common;
    using GW2NET.Items.CraftingMaterials;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="CraftingMaterial"/>.</summary>
    internal sealed class ConverterForCraftingMaterial : IConverter<DetailsDataContract, CraftingMaterial>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="CraftingMaterial"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CraftingMaterial Convert(DetailsDataContract value)
        {
            return new CraftingMaterial();
        }
    }
}