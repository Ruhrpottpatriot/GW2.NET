// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemsTests.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ItemsTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.ItemsInformation.Catalogs;
using GW2DotNET.V1.Core.ItemsInformation.Details;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Weapons;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Weapons.LongBows;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes;
using GW2DotNET.V1.RestSharp;
using NUnit.Framework;

namespace GW2DotNET_Tests.CoreTests
{
    [TestFixture]
    public class ItemsTests
    {
        private IServiceClient client;

        [SetUp]
        public void SetUp()
        {
            this.client = ServiceClient.Create(new Version(1, 0));
        }

        [Test]
        public void GetItemsCatalog()
        {
            var request  = new ItemsRequest();
            var response = request.GetResponse(client);

            Assume.That(response.IsSuccessStatusCode);
            Assume.That(response.IsJsonResponse);

            var itemsResult = response.Deserialize();

            Assert.IsNotNull(itemsResult);
            Assert.IsEmpty(itemsResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(ItemsResult).FullName);

            Assert.IsNotNull(itemsResult.Items);
            Assert.IsNotEmpty(itemsResult.Items);
            Assert.IsEmpty(itemsResult.Items.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Items).FullName);

            Trace.WriteLine(string.Format("Number of items: {0}", itemsResult.Items.Count));
        }

        [Test]
        public void GetRecipesCatalog()
        {
            var request  = new RecipesRequest();
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var recipesResult = response.Deserialize();

            Assert.IsNotNull(recipesResult);
            Assert.IsEmpty(recipesResult.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(RecipesResult).FullName);

            Assert.IsNotNull(recipesResult.Recipes);
            Assert.IsEmpty(recipesResult.Recipes.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Recipes).FullName);

            Trace.WriteLine(string.Format("Number of recipes: {0}", recipesResult.Recipes.Count));
        }

        [Test]
        public void GetRecipeDetails()
        {
            int recipeId = 1275;
            var request  = new RecipeDetailsRequest(recipeId);
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var recipeDetails = response.Deserialize();

            Assert.IsNotNull(recipeDetails);
            Assert.IsEmpty(recipeDetails.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Recipe).FullName);

            foreach (var ingredient in recipeDetails.Ingredients)
            {
                Assert.IsEmpty(ingredient.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(CraftingIngredient).FullName);
            }


            Trace.WriteLine(string.Format("Output item ID: {0}", recipeDetails.OutputItemId));
        }

        [Test]
        public void GetItemDetails_Weapon_LongBow()
        {
            int itemId   = 28445; // Strong Bow of Fire

            var request  = new ItemDetailsRequest(itemId);
            var response = request.GetResponse(client);

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(response.IsJsonResponse);

            var item = response.Deserialize();
            Assert.IsNotNull(item);
            Assert.IsEmpty(item.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Item).FullName);

            var weapon = (Weapon)item;
            Assert.AreEqual(item.Type, ItemType.Weapon);
            Assert.IsEmpty(weapon.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(Weapon).FullName);

            var weaponDetails = (LongBowDetails)weapon.WeaponDetails;
            Assert.AreEqual(weaponDetails.Type, WeaponType.LongBow);
            Assert.IsEmpty(weaponDetails.ExtensionData, "The '{0}' class is missing one or more properties.", typeof(LongBowDetails).FullName);
        }
    }
}
