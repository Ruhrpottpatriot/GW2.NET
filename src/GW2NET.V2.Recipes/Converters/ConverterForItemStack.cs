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
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="IngredientDataContract"/> to objects of type <see cref="ItemStack"/>.</summary>
    internal sealed class ConverterForItemStack : IConverter<IngredientDataContract, ItemStack>
    {
        /// <inheritdoc />
        public ItemStack Convert(IngredientDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new ItemStack
            {
                ItemId = value.ItemId,
                Count = value.Count
            };
        }
    }
}