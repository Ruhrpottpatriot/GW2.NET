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

using GW2DotNET.V1.Items;

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
        private ItemManager manager;

        /// <summary>
        /// Runs before each test run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.manager = new ItemManager();
        }

        /// <summary>
        /// Gets an item by id.
        /// </summary>
        [Test]
        public void GetItem()
        {
            var stopwatch = Stopwatch.StartNew();

            var recipe = this.manager.Recipes[805];

            stopwatch.Stop();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Recipe Details: {0}", recipe.Id);
        }

        /// <summary>
        /// Gets all items from the server.
        /// !!WARNING!! This method will run about 15 minutes.
        /// Run at your own risk.
        /// </summary>
        [Test]
        public void GetItems()
        {
            var stopwatch = Stopwatch.StartNew();

            var recipes = this.manager.Recipes.ToList();

            Debug.WriteLine("Elapsed Time: {0}", stopwatch.ElapsedMilliseconds);

            Debug.WriteLine("Total number of recipes: {0}", recipes.Count);
        }
    }
}
