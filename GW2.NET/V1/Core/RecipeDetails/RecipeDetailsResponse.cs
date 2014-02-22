// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeDetailsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.RecipeDetails.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.RecipeDetails
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="RecipeDetailsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details"/> for more information.
    /// </remarks>
    public class RecipeDetailsResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets the crafting disciplines that can use the recipe.
        /// </summary>
        [JsonProperty("disciplines", Order = 6)]
        public Disciplines Disciplines { get; set; }

        /// <summary>
        /// Gets or sets the recipe's unlock type(s).
        /// </summary>
        [JsonProperty("flags", Order = 7)]
        public UnlockTypes Flags { get; set; }

        /// <summary>
        /// Gets or sets a list of the required ingredients.
        /// </summary>
        [JsonProperty("ingredients", Order = 8)]
        public IEnumerable<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Gets or sets the recipe's minimum rating.
        /// </summary>
        [JsonProperty("min_rating", Order = 4)]
        public int MinimumRating { get; set; }

        /// <summary>
        /// Gets or sets the amount of items produced.
        /// </summary>
        [JsonProperty("output_item_count", Order = 3)]
        public int OutputItemCount { get; set; }

        /// <summary>
        /// Gets or sets the output item's ID.
        /// </summary>
        [JsonProperty("output_item_id", Order = 2)]
        public int OutputItemId { get; set; }

        /// <summary>
        /// Gets or sets the recipe's ID.
        /// </summary>
        [JsonProperty("recipe_id", Order = 0)]
        public int RecipeId { get; set; }

        /// <summary>
        /// Gets or sets the time it takes to craft the recipe.
        /// </summary>
        [JsonProperty("time_to_craft_ms", Order = 5)]
        [JsonConverter(typeof(MillisecondsTimespanConverter))]
        public TimeSpan TimeToCraft { get; set; }

        /// <summary>
        /// Gets or sets the type of the output item.
        /// </summary>
        [JsonProperty("type", Order = 1)]
        public RecipeType Type { get; set; }
    }
}