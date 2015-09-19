// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeUnlockerConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDTO" /> to objects of type <see cref="CraftingRecipeUnlocker" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class CraftingRecipeUnlockerConverter
    {
        partial void Merge(CraftingRecipeUnlocker entity, ItemDTO dto, object state)
        {
            var consumableDto = dto.Consumable;
            if (consumableDto == null)
            {
                return;
            }

            int recipeId;
            if (int.TryParse(consumableDto.RecipeId, out recipeId))
            {
                entity.RecipeId = recipeId;
            }
        }
    }
}