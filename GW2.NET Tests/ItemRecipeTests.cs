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
        /// Gets an item by id.
        /// </summary>
        [Test]
        public void GetRecipe()
        {
            Debug.WriteLine("Geting a single recipe from the server.");
            Debug.WriteLine(string.Empty);

            Debug.WriteLine("Starting stopwatch");
            var stopwatch = Stopwatch.StartNew();

            var recipe = this.manager.Recipes[805];

            Debug.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Recipe Details: {0} (Crafts: {1})", recipe.Id, recipe.OutputItemId);
        }

        /// <summary>
        /// Gets all items from the server.
        /// !!WARNING!! This method will run about 15 minutes.
        /// Run at your own risk.
        /// </summary>
        [Test]
        public void GetRecipes()
        {
            Debug.WriteLine("Geting all recipes from the server.");
            Debug.WriteLine(string.Empty);

            Debug.WriteLine("Starting stopwatch");
            var stopwatch = Stopwatch.StartNew();

            var recipes = this.manager.Recipes.ToList();

            Debug.WriteLine("Stopping stopwatch");
            stopwatch.Stop();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Total number of recipes: {0}", recipes.Count);
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

            var item = this.manager.Items.ToList();

            stopwatch.Stop();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Recipe Details: {0}", item.Count);
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

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Recipe Details: {0}", item.Id);
        }
    }
}
