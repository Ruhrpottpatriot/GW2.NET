// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemStack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IngredientDataContract" /> to objects of type <see cref="ItemStack" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Recipes.Json;

    /// <summary>Converts objects of type <see cref="IngredientDataContract"/> to objects of type <see cref="ItemStack"/>.</summary>
    internal sealed class ConverterForItemStack : IConverter<IngredientDataContract, ItemStack>
    {
        /// <summary>Converts the given object of type <see cref="IngredientDataContract"/> to an object of type <see cref="ItemStack"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ItemStack Convert(IngredientDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var itemStack = new ItemStack();
            int itemId;
            if (int.TryParse(value.ItemId, out itemId))
            {
                itemStack.ItemId = itemId;
            }

            int count;
            if (int.TryParse(value.Count, out count) && count > 0)
            {
                itemStack.Count = count;
            }

            return itemStack;
        }
    }
}