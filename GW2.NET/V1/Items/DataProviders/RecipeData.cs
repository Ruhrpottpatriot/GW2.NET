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

using Microsoft.Win32;

namespace GW2DotNET.V1.Items.DataProviders
{
    /// <summary>
    /// The recipe data provider.
    /// </summary>
    public class RecipeData : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Backing field for the data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>
        /// Backing field for the recipe id cache, lazy initialized.
        /// </summary>
        private readonly Lazy<List<int>> recipeIdListCache;

        /// <summary>
        /// Backing field for the recipe cache, lazy initialized.
        /// </summary>
        private readonly Lazy<List<Recipe>> recipeListCache;

        /// <summary>The recipe list cache file name.</summary>
        private readonly string recipeListCacheFileName;

        /// <summary>The recipe id list cache file name.</summary>
        private readonly string recipeIdListCacheFileName;

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

            this.recipeListCacheFileName = string.Format("{0}\\RecipeListCache{1}.json", this.dataManager.SavePath, this.dataManager.Language);
            this.recipeIdListCacheFileName = string.Format("{0}\\RecipeIdListCache{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            this.recipeIdListCache = !this.BypassCache ? new Lazy<List<int>>(() => this.ReadCacheFromDisk<GameCache<List<int>>>(this.recipeIdListCacheFileName).CacheData) : new Lazy<List<int>>();
            this.recipeListCache = !this.BypassCache ? new Lazy<List<Recipe>>(() => this.ReadCacheFromDisk<GameCache<List<Recipe>>>(this.recipeListCacheFileName).CacheData) : new Lazy<List<Recipe>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the recipe list.</summary>
        public IEnumerable<Recipe> RecipeList
        {
            get
            {
                return this.recipeListCache.Value;
            }
        }

        /// <summary>Gets the recipe id list.</summary>
        public IEnumerable<int> RecipeIdList
        {
            get
            {
                return this.recipeIdListCache.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            GameCache<List<int>> idCacheData = new GameCache<List<int>>
            {
                Build = this.dataManager.Build,
                CacheData = this.recipeIdListCache.Value
            };

            this.WriteDataToDisk(this.recipeIdListCacheFileName, idCacheData);

            GameCache<List<Recipe>> recipeCacheData = new GameCache<List<Recipe>>
            {
                Build = this.dataManager.Build,
                CacheData = this.recipeListCache.Value
            };

            this.WriteDataToDisk(this.recipeListCacheFileName, recipeCacheData);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public override async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary>Calls the GW2 api to get a list of all discovered recipe ids synchronously.</summary>
        /// <returns>An <see cref="IEnumerable{T}"/> containing the Ids of all discovered recipes.</returns>
        public IEnumerable<int> GetRecipeIdList()
        {
            List<int> returnContent = ApiCall.GetContent<Dictionary<string, List<int>>>("recipes.json", null, ApiCall.Categories.Items).Values.First();

            if (!this.BypassCache)
            {
                this.recipeIdListCache.Value.AddRange(returnContent);
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
                this.recipeIdListCache.Value.AddRange(recipeIdDictionary);
            }

            return recipeIdDictionary;
        }

        /// <summary>Calls the GW2 api to get the details of all discovered recipes asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/> containing all recipes and their details.</returns>
        public async Task<IEnumerable<Recipe>> GetRecipeDetailListAsync()
        {
            List<Recipe> recipes = new List<Recipe>();

            foreach (int recipeId in this.recipeIdListCache.Value)
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
                this.recipeListCache.Value.AddRange(recipes);
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
                this.recipeListCache.Value.Add(returnContent);
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
                this.recipeListCache.Value.Add(returnContent);
            }

            return returnContent;
        }
    }
}
