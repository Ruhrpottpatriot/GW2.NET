// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RecipeData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    /// The recipe data provider.
    /// </summary>
    public class RecipeData : IEnumerable<Recipe>
    {
        /// <summary>
        /// The recipe id cache.
        /// </summary>
        private IEnumerable<int> recipeIdCache;

        /// <summary>
        /// The recipes.
        /// </summary>
        private IEnumerable<Recipe> recipes;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeData"/> class.
        /// </summary>
        internal RecipeData()
        {
        }

        /// <summary>
        /// Gets the cache of all discovered recipe ids.
        /// </summary>
        private IEnumerable<int> RecipeIdCache
        {
            get
            {
                return this.recipeIdCache ?? (this.recipeIdCache = ApiCall.GetContent<Dictionary<string, IEnumerable<int>>>("recipes.json", null, ApiCall.Categories.Items).Values.First());
            }
        }

        /// <summary>
        /// Gets all the recipes from the server.
        /// </summary>
        private IEnumerable<Recipe> Recipes
        {
            get
            {
                return this.recipes ?? (this.recipes = this.RecipeIdCache.Select(singleRecipeId => new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("recipe_id", singleRecipeId)
                }).Select(arguments => ApiCall.GetContent<Recipe>("recipe_details.json", arguments, ApiCall.Categories.Items)));
            }
        }

        /// <summary>
        /// Gets a single recipe from the server.
        /// </summary>
        /// <param name="recipeId">
        /// The recipe id.
        /// </param>
        /// <returns>
        /// The <see cref="Recipe"/>.
        /// </returns>
        public Recipe this[int recipeId]
        {
            get
            {
                var arguments = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("recipe_id", recipeId)
                };

                return ApiCall.GetContent<Recipe>("recipe_details.json", arguments, ApiCall.Categories.Items);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<Recipe> GetEnumerator()
        {
            return this.Recipes.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Recipes.GetEnumerator();
        }
    }
}
