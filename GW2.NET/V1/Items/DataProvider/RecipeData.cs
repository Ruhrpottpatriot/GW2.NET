// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RecipeData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly Lazy<IEnumerable<int>> recipeIdCache;

        /// <summary>
        /// The recipes.
        /// </summary>
        private readonly Lazy<IEnumerable<Recipe>> recipeCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeData"/> class.
        /// </summary>
        internal RecipeData()
        {
            this.recipeIdCache = new Lazy<IEnumerable<int>>(InitializeRecipeIdCache);

            this.recipeCache = new Lazy<IEnumerable<Recipe>>(InitializeRecipeCache);
        }

        private IEnumerable<int> InitializeRecipeIdCache()
        {
            return ApiCall.GetContent<Dictionary<string, IEnumerable<int>>>("recipes.json", null,
                                                                            ApiCall.Categories.Items)
                          .Values.First();
        }

        private IEnumerable<Recipe> InitializeRecipeCache()
        {
            return this.RecipeIdCache.Select(singleRecipeId => new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("recipe_id", singleRecipeId)
                })
                       .Select(
                           arguments =>
                           ApiCall.GetContent<Recipe>("recipe_details.json", arguments,
                                                      ApiCall.Categories.Items));
        }

        /// <summary>
        /// Gets the cache of all discovered recipe ids.
        /// </summary>
        private IEnumerable<int> RecipeIdCache
        {
            get { return this.recipeIdCache.Value; }
        }

        /// <summary>
        /// Gets all the recipes from the server.
        /// </summary>
        private IEnumerable<Recipe> Recipes
        {
            get { return this.recipeCache.Value; }
        }

        /// <summary>
        /// Gets all recipes asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<Recipe>> GetAllRecipesAsync(CancellationToken cancellationToken)
        {
            Func<IEnumerable<Recipe>> methodCall = () => this.Recipes;

            return Task.Factory.StartNew(methodCall);
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
                return this.Recipes.Single(recipe => recipe.Id == recipeId);
            }
        }

        /// <summary>
        /// Gets one recipe from ID asynchronously.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Recipe> GetRecipeFromIdAsync(int recipeId, CancellationToken cancellationToken)
        {
            Func<Recipe> methodCall = () => this[recipeId];

            return Task.Factory.StartNew(methodCall);
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
