// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeUnlockConsumableItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Represents detailed information about a crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class CraftingRecipeUnlockConsumableItemDetails : UnlockConsumableItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRecipeUnlockConsumableItemDetails"/> class.
        /// </summary>
        public CraftingRecipeUnlockConsumableItemDetails()
            : base(UnlockType.CraftingRecipe)
        {
        }

        /// <summary>
        /// Gets or sets the crafting recipe's ID.
        /// </summary>
        [JsonProperty("recipe_id", Order = 102)]
        public int RecipeId { get; set; }
    }
}