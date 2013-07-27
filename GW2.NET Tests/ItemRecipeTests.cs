// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRecipeTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemRecipeTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;
using System.Linq;
using System.Threading;
using GW2DotNET.V1;

using NUnit.Framework;

namespace GW2.NET_Tests
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
        private ApiManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new ApiManager(GW2DotNET.V1.Infrastructure.Language.En);
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
            var stopwatch = Stopwatch.StartNew();

            var recipe = this.manager.Recipes[805];

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.Greater(recipe.OutputItemId, 0);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0} (Crafts: {1})", recipe.Id, recipe.OutputItemId));
        }

        /// <summary>
        /// Gets a recipe by id asynchronously.
        /// </summary>
        [Test]
        public void GetRecipeAsync()
        {
            Trace.WriteLine("Getting a single recipe from the server asynchronously.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Recipes.GetRecipeFromIdAsync(805, CancellationToken.None);
            task.Wait();

            var recipe = task.Result;

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.Greater(recipe.OutputItemId, 0);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0} (Crafts: {1})", recipe.Id, recipe.OutputItemId));
        }

        /// <summary>
        /// Gets all recipes from the server.
        /// !!WARNING!! This method will run about 15 minutes.
        /// Run at your own risk.
        /// </summary>
        [Test]
        public void GetRecipes()
        {
            Trace.WriteLine("Geting all recipes from the server.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            var stopwatch = Stopwatch.StartNew();

            var recipes = this.manager.Recipes.ToList();

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.IsNotEmpty(recipes);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total number of recipes: {0}", recipes.Count));
        }

        /// <summary>
        /// Gets all recipes from the server asynchronously.
        /// !!WARNING!! This method will run about 15 minutes.
        /// Run at your own risk.
        /// </summary>
        [Test]
        public void GetRecipesAsync()
        {
            Trace.WriteLine("Geting all recipes from the server asynchronously.");
            Trace.WriteLine(string.Empty);

            Trace.WriteLine("Starting stopwatch");
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Recipes.GetAllRecipesAsync(CancellationToken.None);
            task.Wait();

            var recipes = task.Result.ToList();

            Trace.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Assert.IsNotEmpty(recipes);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Total number of recipes: {0}", recipes.Count));
        }

        /// <summary>
        /// Gets all items from the server.
        /// !!!WARNING!!!: Running this method will take a long time.
        /// If you are running this test make sure to run it in a separate NUnit session.
        /// </summary> 
        [Test]
        public void GetItems()
        {
            var stopwatch = Stopwatch.StartNew();

            var items = this.manager.Items.ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(items);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", items.Count));
        }

        /// <summary>
        /// Gets all items from the server asynchronously.
        /// !!!WARNING!!!: Running this method will take a long time.
        /// If you are running this test make sure to run it in a separate NUnit session.
        /// </summary> 
        [Test]
        public void GetItemsAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Items.GetAllItemsAsync(CancellationToken.None);
            task.Wait();

            var items = task.Result.ToList();

            stopwatch.Stop();

            Assert.IsNotEmpty(items);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", items.Count));
        }

        /// <summary>
        /// Gets a single item from the server.
        /// </summary>
        [Test]
        public void GetItem()
        {
            var stopwatch = Stopwatch.StartNew();

            var item = this.manager.Items[23481];

            stopwatch.Stop();

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", item.Id));
        }

        /// <summary>
        /// Gets a single item from the server asynchronously.
        /// </summary>
        [Test]
        public void GetItemAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            var task = this.manager.Items.GetItemFromIdAsync(23481, CancellationToken.None);
            task.Wait();

            var item = task.Result;

            stopwatch.Stop();

            Assert.IsNotNullOrEmpty(item.Name);

            Trace.WriteLine(string.Format("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds));

            Trace.WriteLine(string.Format("Recipe Details: {0}", item.Id));
        }
    }
}
