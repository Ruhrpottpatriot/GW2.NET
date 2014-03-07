// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRecipeTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemRecipeTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Threading.Tasks;

using GW2DotNET.V1;
using GW2DotNET.V1.Core.ItemsInformation.Details;
using NUnit.Framework;

namespace GW2DotNET_Tests
{
    /// <summary>
    /// The item recipe tests.
    /// </summary>
    [TestFixture]
    public class ItemRecipeTests
    {
        /// <summary>
        /// The item manager.
        /// </summary>
        private IDataManager dataManager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.dataManager = new DataManager(GW2DotNET.V1.Infrastructure.Language.En);
        }

        /// <summary>
        /// Gets a recipe by id.
        /// </summary>
        [Test]
        public void GetRecipe()
        {
            Trace.WriteLine("Getting a single recipe from the server.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            Stopwatch stopwatch = Stopwatch.StartNew();

            Recipe recipe = this.dataManager.RecipeData.GetRecipeDetails(805);

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.IsNotNull(recipe.OutputItemId);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0} (Crafts: {1})", recipe.RecipeId, recipe.OutputItemId));
        }

        /// <summary>
        /// Gets a recipe by id asynchronously.
        /// </summary>
        [Test]
        public async void GetRecipeAsync()
        {
            Trace.WriteLine("Getting a single recipe from the server asynchronously.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            var stopwatch = Stopwatch.StartNew();

            Task<Recipe> task = this.dataManager.RecipeData.GetRecipeDetailsAsync(805);
            task.Wait();

            Recipe recipe = await task;

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.Greater(recipe.OutputItemId, 0);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0} (Crafts: {1})", recipe.RecipeId, recipe.OutputItemId));
        }

        /// <summary>
        /// Gets a single item from the server.
        /// </summary>
        [Test]
        public void GetItem()
        {
            var stopwatch = Stopwatch.StartNew();

            var item = this.dataManager.ItemData.GetItemDetail(23481);

            stopwatch.Stop();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", item.ItemId));
        }

        /// <summary>
        /// Gets a single item from the server asynchronously.
        /// </summary>
        [Test]
        public async void GetItemAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            Task<Item> task = this.dataManager.ItemData.GetItemDetailAsync(23481);
            task.Wait();

            var item = await task;

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(item.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", item.ItemId));
        }
    }
}
