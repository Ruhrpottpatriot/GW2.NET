// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCraftingRecipeUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="CraftingRecipeUnlocker" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="CraftingRecipeUnlocker"/>.</summary>
    internal sealed class ConverterForCraftingRecipeUnlocker : IConverter<ConsumableDataContract, CraftingRecipeUnlocker>
    {
        /// <summary>Converts the given object of type <see cref="ConsumableDataContract"/> to an object of type <see cref="CraftingRecipeUnlocker"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CraftingRecipeUnlocker Convert(ConsumableDataContract value)
        {
            Contract.Assume(value != null);
            var craftingRecipeUnlocker = new CraftingRecipeUnlocker();
            int recipeId;
            if (int.TryParse(value.RecipeId, out recipeId))
            {
                craftingRecipeUnlocker.RecipeId = recipeId;
            }

            return craftingRecipeUnlocker;
        }
    }
}