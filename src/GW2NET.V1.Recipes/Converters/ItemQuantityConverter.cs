// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemQuantityConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IngredientDTO" /> to objects of type <see cref="ItemQuantity" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Recipes.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Recipes.Json;

    /// <summary>Converts objects of type <see cref="IngredientDTO"/> to objects of type <see cref="ItemQuantity"/>.</summary>
    public sealed class ItemQuantityConverter : IConverter<IngredientDTO, ItemQuantity>
    {
        /// <inheritdoc />
        public ItemQuantity Convert(IngredientDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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