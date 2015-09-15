// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemQuantity.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IngredientDataContract" /> to objects of type <see cref="ItemQuantity" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Recipes.Json;

    /// <summary>Converts objects of type <see cref="IngredientDataContract"/> to objects of type <see cref="ItemQuantity"/>.</summary>
    internal sealed class ConverterForItemQuantity : IConverter<IngredientDataContract, ItemQuantity>
    {
        /// <summary>Converts the given object of type <see cref="IngredientDataContract"/> to an object of type <see cref="ItemQuantity"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ItemQuantity Convert(IngredientDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var quantity = new ItemQuantity();
            int itemId;
            if (int.TryParse(value.ItemId, out itemId))
            {
                quantity.ItemId = itemId;
            }

            int count;
            if (int.TryParse(value.Count, out count) && count > 0)
            {
                quantity.Count = count;
            }

            return quantity;
        }
    }
}