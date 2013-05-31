// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Recipe type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>
    /// The recipe model.
    /// </summary>
    public struct Recipe
    {
        /// <summary>
        /// The id of the recipe.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipe"/> struct.
        /// </summary>
        /// <param name="id">
        /// The id of the recipe.
        /// </param>
        /// <param name="type">
        /// The type of the recipe.
        /// </param>
        /// <param name="outputItemId">
        /// The output item id.
        /// </param>
        /// <param name="outputItemCount">
        /// The output item count.
        /// </param>
        /// <param name="minRating">
        /// The minimal rating.
        /// </param>
        /// <param name="timeToCraft">
        /// The time to craft in milliseconds.
        /// </param>
        /// <param name="ingredients">
        /// The ingredients.
        /// </param>
        [JsonConstructor]
        public Recipe(int id, RecipeType type, int outputItemId, int outputItemCount, int minRating, int timeToCraft, IEnumerable<Ingredient> ingredients)
            : this()
        {
            this.id = id;
            this.Type = type;
            this.OutputItemId = outputItemId;
            this.OutputItemCount = outputItemCount;
            this.MinRating = minRating;
            this.TimeToCraft = timeToCraft;
            this.Ingredients = ingredients;
        }

        /// <summary>
        /// Gets the recipe id.
        /// </summary>
        [JsonProperty("recipe_id")]
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the recipe type.
        /// </summary>
        [JsonProperty("type")]
        public RecipeType Type
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the output item id.
        /// </summary>
        [JsonProperty("output_item_id")]
        public int OutputItemId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the output item count.
        /// </summary>
        [JsonProperty("output_item_count")]
        public int OutputItemCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the minimal rating.
        /// </summary>
        [JsonProperty("min_rating")]
        public int MinRating
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the time to craft in milliseconds.
        /// </summary>
        [JsonProperty("time_to_craft_ms")]
        public int TimeToCraft
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the ingredients.
        /// </summary>
        [JsonProperty("ingredients")]
        public IEnumerable<Ingredient> Ingredients
        {
            get;
            private set;
        }

        /// <summary>
        /// The ingredients of a recipe.
        /// </summary>
        public struct Ingredient
        {
            /// <summary>
            /// The id of the ingredient.
            /// </summary>
            private readonly int id;

            /// <summary>
            /// Initializes a new instance of the <see cref="Ingredient"/> struct.
            /// </summary>
            /// <param name="id">
            /// The id of the ingredient.
            /// </param>
            /// <param name="count">
            /// The ingredient count.
            /// </param>
            [JsonConstructor]
            public Ingredient(int id, int count)
                : this()
            {
                this.id = id;
                this.Count = count;
            }

            /// <summary>
            /// Gets the id of the ingredient.
            /// </summary>
            [JsonProperty("item_id")]
            public int Id
            {
                get
                {
                    return this.id;
                }
            }

            /// <summary>
            /// Gets the ingredient count.
            /// </summary>
            [JsonProperty("count")]
            public int Count
            {
                get;
                private set;
            }

            /// <summary>
            /// Determines whether two specified instances of <see crdef="Ingredient"/> are equal.
            /// </summary>
            /// <param name="ingredientA">The first object to compare.</param>param>
            /// <param name="ingredientB">The second object to compare. </param>
            /// <returns>true if ingredientA and ingredientB represent the same ingredient; otherwise, false.</returns>
            public static bool operator ==(Ingredient ingredientA, Ingredient ingredientB)
            {
                return ingredientA.Id == ingredientB.Id;
            }

            /// <summary>
            /// Determines whether two specified instances of <see crdef="Ingredient"/> are not equal.
            /// </summary>
            /// <param name="ingredientA">The first object to compare.</param>param>
            /// <param name="ingredientB">The second object to compare. </param>
            /// <returns>true if ingredientA and ingredientB do not represent the same ingredient; otherwise, false.</returns>
            public static bool operator !=(Ingredient ingredientA, Ingredient ingredientB)
            {
                return ingredientA.Id != ingredientB.Id;
            }

            /// <summary>
            /// Indicates whether this instance and a specified object are equal.
            /// </summary>
            /// <returns>
            /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
            /// </returns>
            /// <param name="obj">Another object to compare to. </param><filterpriority>2</filterpriority>
            public override bool Equals(object obj)
            {
                return obj is Ingredient && this == (Ingredient)obj;
            }

            /// <summary>
            /// Indicates whether this instance and the specified <see cref="Ingredient"/> are equal.
            /// </summary>
            /// <returns>
            /// true if <paramref name="ingredient"/> and this instance are the same type and represent the same value; otherwise, false.
            /// </returns>
            /// <param name="ingredient">Another object to compare to. </param>
            public bool Equals(Ingredient ingredient)
            {
                return this.Id == ingredient.Id;
            }

            /// <summary>
            /// Returns the hash code for this instance.
            /// </summary>
            /// <returns>
            /// A 32-bit signed integer that is the hash code for this instance.
            /// </returns>
            public override int GetHashCode()
            {
                return this.id.GetHashCode();
            }
        }
    }
}
