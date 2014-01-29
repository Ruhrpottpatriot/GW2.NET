// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RecipeData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;

namespace GW2DotNET.V1.Items.DataProviders
{
    /// <summary>
    /// The recipe data provider.
    /// </summary>
    public class RecipeData
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Backing field for the data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>
        /// Backing field for the recipe id cache, lazy initialized.
        /// </summary>
        private readonly Lazy<List<int>> recipeIdCache;

        /// <summary>
        /// Backing field for the recipe cache, lazy initialized.
        /// </summary>
        private readonly Lazy<List<Recipe>> recipeCache;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="RecipeData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public RecipeData(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RecipeData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        /// <param name="bypassCaching">A value indicating whether to bypass caching.</param>
        public RecipeData(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCaching;
            this.recipeIdCache = new Lazy<List<int>>();
            this.recipeCache = new Lazy<List<Recipe>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets a value indicating whether to bypass cache.</summary>
        public bool BypassCache { get; set; }

        /// <summary>Gets the recipe list.</summary>
        public IEnumerable<Recipe> RecipeList
        {
            get
            {
                return this.recipeCache.Value;
            }
        }

        /// <summary>Gets the recipe id list.</summary>
        public IEnumerable<int> RecipeIdList
        {
            get
            {
                return this.recipeIdCache.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public void WriteCacheToDisk()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        /// <summary>Calls the GW2 api to get a list of all discovered recipe ids synchronously.</summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the Ids of all discovered recipes.</returns>
        public IEnumerable<int> GetRecipeIdList()
        {
            List<int> returnContent = ApiCall.GetContent<Dictionary<string, List<int>>>("recipes.json", null, ApiCall.Categories.Items).Values.First();

            if (!this.BypassCache)
            {
                this.recipeIdCache.Value.AddRange(returnContent);
            }

            return returnContent;
        }

        /// <summary>Calls the GW2 api to get a list of all discovered recipe ids asynchronously.</summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the Ids of all discovered recipes.</returns>
        public async Task<IEnumerable<int>> GetRecipeIdListAsync()
        {
            Dictionary<string, List<int>> returnContent = await ApiCall.GetContentAsync<Dictionary<string, List<int>>>("recipes.json", null, ApiCall.Categories.Items);

            var recipeIdDictionary = returnContent.Values.First();

            if (!this.BypassCache)
            {
                this.recipeIdCache.Value.AddRange(recipeIdDictionary);
            }

            return recipeIdDictionary;
        }

        /// <summary>Calls the GW2 api to get the details of all discovered recipes asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/> containing all recipes and their details.</returns>
        public async Task<IEnumerable<Recipe>> GetRecipeDetailListAsync()
        {
            List<Recipe> recipes = new List<Recipe>();

            foreach (int recipeId in this.recipeIdCache.Value)
            {
                List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("recipe_id", recipeId),
                    new KeyValuePair<string, object>("lang", this.dataManager.Language)
                };

                Recipe returnContent = await ApiCall.GetContentAsync<Recipe>("recipe_details.json", args, ApiCall.Categories.Items);

                recipes.Add(returnContent);
            }

            if (!this.BypassCache)
            {
                this.recipeCache.Value.AddRange(recipes);
            }

            return recipes;
        }

        /// <summary>Calls the GW2 api to get the details of the specified recipe asynchronously.</summary>
        /// <param name="recipeId">The id of the recipe.</param>
        /// <returns>The <see cref="Recipe"/> with the specified id.</returns>
        public async Task<Recipe> GetRecipeDetailAsync(int recipeId)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("recipe_id", recipeId),
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            Recipe returnContent = await ApiCall.GetContentAsync<Recipe>("recipe_details.json", args, ApiCall.Categories.Items);

            if (!this.BypassCache)
            {
                this.recipeCache.Value.Add(returnContent);
            }

            return returnContent;
        }

        /// <summary>Calls the GW2 api to get the details of the specified recipe synchronously.</summary>
        /// <param name="recipeId">The id of the recipe.</param>
        /// <returns>The <see cref="Recipe"/> with the specified id.</returns>
        public Recipe GetRecipeDetail(int recipeId)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("recipe_id", recipeId)
            };

            Recipe returnContent = ApiCall.GetContent<Recipe>("recipe_details.json", args, ApiCall.Categories.Items);

            if (!this.BypassCache)
            {
                this.recipeCache.Value.Add(returnContent);
            }

            return returnContent;
        }
    }
}
