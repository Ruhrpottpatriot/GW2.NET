// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Recipe type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>The recipe model.</summary>
    public partial class Recipe : IEquatable<Recipe>
    {
        /// <summary>The id of the recipe.</summary>
        private readonly int id;

        /// <summary>Initializes a new instance of the <see cref="Recipe"/> class.</summary>
        /// <param name="id">The id of the recipe.</param>
        /// <param name="type">The type of the recipe.</param>
        /// <param name="outputItemId">The output item id.</param>
        /// <param name="outputItemCount">The output item count.</param>
        /// <param name="minRating">The minimal rating.</param>
        /// <param name="timeToCraft">The time to craft in milliseconds.</param>
        /// <param name="ingredients">The ingredients.</param>
        [JsonConstructor]
        public Recipe(int id, RecipeType type, int outputItemId, int outputItemCount, int minRating, int timeToCraft, IEnumerable<Ingredient> ingredients)
        {
            this.id = id;
            this.Type = type;
            this.OutputItemId = outputItemId;
            this.OutputItemCount = outputItemCount;
            this.MinRating = minRating;
            this.TimeToCraft = timeToCraft;
            this.Ingredients = ingredients;
        }

        /// <summary>Gets the recipe id.</summary>
        [JsonProperty("recipe_id")]
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>Gets the recipe type.</summary>
        [JsonProperty("type")]
        public RecipeType Type { get; private set; }

        /// <summary>Gets the output item id.</summary>
        [JsonProperty("output_item_id")]
        public int OutputItemId { get; private set; }

        /// <summary>Gets the output item count.</summary>
        [JsonProperty("output_item_count")]
        public int OutputItemCount { get; private set; }

        /// <summary>Gets the minimal rating.</summary>
        [JsonProperty("min_rating")]
        public int MinRating { get; private set; }

        /// <summary>Gets the time to craft in milliseconds.</summary>
        [JsonProperty("time_to_craft_ms")]
        public int TimeToCraft { get; private set; }

        /// <summary>Gets the ingredients.</summary>
        [JsonProperty("ingredients")]
        public IEnumerable<Ingredient> Ingredients { get; private set; }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Recipe other)
        {
            if (other == null)
            {
                return false;
            }

            return other.Id == this.Id;
        }
    }
}