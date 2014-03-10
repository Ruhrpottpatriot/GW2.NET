// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details
{
    using System;

    using GW2DotNET.V1.Core.Converters;
    using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a crafting recipe.
    /// </summary>
    [JsonConverter(typeof(RecipeConverter))]
    public abstract class Recipe : JsonObject
    {
        /// <summary>Initializes a new instance of the <see cref="Recipe"/> class.</summary>
        /// <param name="recipeType">The recipe's type.</param>
        protected Recipe(RecipeType recipeType)
        {
            this.Type = recipeType;
        }

        /// <summary>
        ///     Gets or sets the crafting disciplines that can use the recipe.
        /// </summary>
        [JsonProperty("disciplines", Order = 6)]
        public CraftingDisciplines CraftingDisciplines { get; set; }

        /// <summary>
        ///     Gets or sets the recipe's unlock type(s).
        /// </summary>
        [JsonProperty("flags", Order = 7)]
        public RecipeUnlockTypes Flags { get; set; }

        /// <summary>
        ///     Gets or sets a collection of the required ingredients.
        /// </summary>
        [JsonProperty("ingredients", Order = 8)]
        public CraftingIngredientCollection Ingredients { get; set; }

        /// <summary>
        ///     Gets or sets the recipe's minimum rating.
        /// </summary>
        [JsonProperty("min_rating", Order = 4)]
        public int MinimumRating { get; set; }

        /// <summary>
        ///     Gets or sets the amount of items produced.
        /// </summary>
        [JsonProperty("output_item_count", Order = 3)]
        public int OutputItemCount { get; set; }

        /// <summary>
        ///     Gets or sets the output item's ID.
        /// </summary>
        [JsonProperty("output_item_id", Order = 2)]
        public int OutputItemId { get; set; }

        /// <summary>
        ///     Gets or sets the recipe's ID.
        /// </summary>
        [JsonProperty("recipe_id", Order = 0)]
        public int RecipeId { get; set; }

        /// <summary>
        ///     Gets or sets the time it takes to craft the recipe.
        /// </summary>
        [JsonProperty("time_to_craft_ms", Order = 5)]
        [JsonConverter(typeof(JsonTimespanConverter))]
        public TimeSpan TimeToCraft { get; set; }

        /// <summary>
        ///     Gets or sets the type of the output item.
        /// </summary>
        [JsonProperty("type", Order = 1)]
        public RecipeType Type { get; set; }
    }
}