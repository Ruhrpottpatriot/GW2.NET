// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemQuantity.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IngredientDataContract" /> to objects of type <see cref="ItemQuantity" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="IngredientDataContract"/> to objects of type <see cref="ItemQuantity"/>.</summary>
    internal sealed class ConverterForItemQuantity : IConverter<IngredientDataContract, ItemQuantity>
    {
        /// <inheritdoc />
        public ItemQuantity Convert(IngredientDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var itemQuantity = new ItemQuantity
            {
                ItemId = value.ItemId
            };

            if (value.Count >= 1)
            {
                itemQuantity.Count = value.Count;
            }

            return itemQuantity;
        }
    }
}