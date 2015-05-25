// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemStack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IngredientDataContract" /> to objects of type <see cref="ItemStack" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="IngredientDataContract"/> to objects of type <see cref="ItemStack"/>.</summary>
    internal sealed class ConverterForItemStack : IConverter<IngredientDataContract, ItemStack>
    {
        /// <summary>Converts the given object of type <see cref="IngredientDataContract"/> to an object of type <see cref="ItemStack"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ItemStack Convert(IngredientDataContract value)
        {
            Contract.Assume(value != null);
            return new ItemStack
            {
                ItemId = value.ItemId, 
                Count = value.Count
            };
        }
    }
}