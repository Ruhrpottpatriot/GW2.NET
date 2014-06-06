// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GwContextInitializer.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The Guild Wars context initializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Persistence
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Builds;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Items;
    using GW2DotNET.V1.Items.Details;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;
    using GW2DotNET.V1.Recipes;
    using GW2DotNET.V1.Recipes.Details;
    using GW2DotNET.V1.Recipes.Details.Contracts;

    /// <summary>The Guild Wars context initializer.</summary>
    public class GwContextInitializer : DbMigrationsConfiguration<GwContext>
    {
        /// <summary>Initializes a new instance of the <see cref="GwContextInitializer" /> class.</summary>
        public GwContextInitializer()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>Runs after upgrading to the latest migration to allow seed data to be updated.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(GwContext context)
        {
            var cultures = new[]
                               {
                                   CultureInfo.GetCultureInfo("de"), 
                                   CultureInfo.GetCultureInfo("en"), 
                                   CultureInfo.GetCultureInfo("es"), 
                                   CultureInfo.GetCultureInfo("fr")
                               };

            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            foreach (var culture in cultures)
            {
                this.SeedItems(context, culture);
                this.SeedRecipes(context, culture);
            }
        }

        /// <summary>Adds the specified item.</summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Item"/>.</returns>
        private Item Add(Item item, GwContext context)
        {
            var upgradedItem = item as IUpgrade;
            if (upgradedItem != null && upgradedItem.Attributes.Any())
            {
                upgradedItem.Attributes = this.AddOrGetExisting(upgradedItem.Attributes, context);
            }

            return context.Items.Add(item);
        }

        /// <summary>Ensures that all entries in the specified collection exist in the database.</summary>
        /// <param name="itemAttributeCollection">The item attribute collection.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="ItemAttributeCollection"/>.</returns>
        private ItemAttributeCollection AddOrGetExisting(IEnumerable<ItemAttribute> itemAttributeCollection, GwContext context)
        {
            var collection = new ItemAttributeCollection();
            foreach (var attribute in itemAttributeCollection)
            {
                collection.Add(context.ItemAttributes.Find(attribute.Type, attribute.Modifier) ?? context.ItemAttributes.Add(attribute));
            }

            return collection;
        }

        /// <summary>Ensures that the database has an updated index of discovered items.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <param name="language">The language.</param>
        private void SeedItems(GwContext context, CultureInfo language)
        {
            var buildService = new BuildService();

            var itemService = new ItemService();

            var itemDetailService = new ItemDetailsService();

            var build = buildService.GetBuild();

            var allItemIds = itemService.GetItems().Take(300).ToList();

            var knownItems = context.Items.Where(item => item.Language == language.TwoLetterISOLanguageName);

            var unknownItemIds = allItemIds.Except(knownItems.Select(item => item.ItemId)).ToList();

            if (unknownItemIds.Any())
            {
                foreach (var partition in Partitioner.Create(0, unknownItemIds.Count(), 100).GetDynamicPartitions())
                {
                    var tasks = new List<Task<Item>>();

                    for (var index = partition.Item1; index < partition.Item2; index++)
                    {
                        tasks.Add(itemDetailService.GetItemDetailsAsync(unknownItemIds[index], language));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    Task.WaitAll(tasks.ToArray());

                    var items = tasks.Where(t => t.IsCompleted).Select(task => task.Result).ToList();

                    foreach (var item in items)
                    {
                        item.BuildId = build.BuildId;
                        this.Add(item, context);
                    }

                    context.SaveChanges();
                }
            }

            var outdatedItemIds = knownItems.Where(item => item.BuildId < build.BuildId).ToList();

            if (outdatedItemIds.Any())
            {
                foreach (var partition in Partitioner.Create(0, outdatedItemIds.Count(), 100).GetDynamicPartitions())
                {
                    var tasks = new List<Task<Item>>();

                    for (var index = partition.Item1; index < partition.Item2; index++)
                    {
                        tasks.Add(itemDetailService.GetItemDetailsAsync(outdatedItemIds[index].ItemId, language));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    Task.WaitAll(tasks.ToArray());

                    var items = tasks.Where(t => t.IsCompleted).Select(task => task.Result).ToList();

                    foreach (var item in items)
                    {
                        item.BuildId = build.BuildId;
                        this.Update(item, context);
                    }

                    context.SaveChanges();
                }
            }
        }

        /// <summary>Ensures that the database has an updated index of discovered recipes.</summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <param name="language">The language.</param>
        private void SeedRecipes(GwContext context, CultureInfo language)
        {
            var buildService = new BuildService();

            var recipeService = new RecipeService();

            var recipeDetailsService = new RecipeDetailsService();

            var itemDetailsService = new ItemDetailsService();

            var build = buildService.GetBuild();

            var allRecipeIds = recipeService.GetRecipes().Take(300).ToList();

            var knownRecipes = context.Recipes.Where(recipe => recipe.Language == language.TwoLetterISOLanguageName);

            var unknownRecipeIds = allRecipeIds.Except(knownRecipes.Select(recipe => recipe.RecipeId)).ToList();

            if (unknownRecipeIds.Any())
            {
                foreach (var partition in Partitioner.Create(0, unknownRecipeIds.Count(), 100).GetDynamicPartitions())
                {
                    var tasks = new List<Task<Recipe>>();

                    for (var index = partition.Item1; index < partition.Item2; index++)
                    {
                        tasks.Add(recipeDetailsService.GetRecipeDetailsAsync(unknownRecipeIds[index], language));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    Task.WaitAll(tasks.ToArray());

                    var recipes = tasks.Where(t => t.IsCompleted).Select(task => task.Result).ToList();

                    foreach (var recipe in recipes)
                    {
                        recipe.BuildId = build.BuildId;

                        try
                        {
                            recipe.OutputItem = context.Items.Find(recipe.OutputItemId, recipe.Language);
                            if (recipe.OutputItem == null)
                            {
                                recipe.OutputItem = itemDetailsService.GetItemDetails(recipe.OutputItemId, language);
                                recipe.OutputItem.BuildId = build.BuildId;
                                recipe.OutputItem = this.Add(recipe.OutputItem, context);
                            }

                            var ingredients = new IngredientCollection(recipe.Ingredients.Count);
                            foreach (var ingredient in recipe.Ingredients)
                            {
                                ingredients.Add(
                                    context.Ingredients.Find(ingredient.ItemId, ingredient.Language, ingredient.Count) ?? context.Ingredients.Add(ingredient));
                                ingredient.Item = context.Items.Find(ingredient.ItemId, ingredient.Language);
                                if (ingredient.Item == null)
                                {
                                    ingredient.Item = itemDetailsService.GetItemDetails(ingredient.ItemId, language);
                                    ingredient.Item.BuildId = build.BuildId;
                                    ingredient.Item = this.Add(ingredient.Item, context);
                                }
                            }

                            recipe.Ingredients = ingredients;
                            context.Recipes.Add(recipe);
                        }
                        catch (ServiceException)
                        {
                        }
                    }

                    context.SaveChanges();
                }
            }

            var outdatedRecipes = knownRecipes.Where(recipe => recipe.BuildId < build.BuildId).ToList();

            if (outdatedRecipes.Any())
            {
                foreach (var partition in Partitioner.Create(0, outdatedRecipes.Count(), 100).GetDynamicPartitions())
                {
                    var tasks = new List<Task<Recipe>>();

                    for (var index = partition.Item1; index < partition.Item2; index++)
                    {
                        tasks.Add(recipeDetailsService.GetRecipeDetailsAsync(outdatedRecipes[index].RecipeId, language));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    Task.WaitAll(tasks.ToArray());

                    var recipes = tasks.Where(t => t.IsCompleted).Select(task => task.Result).ToList();

                    foreach (var recipe in recipes)
                    {
                        recipe.BuildId = build.BuildId;

                        try
                        {
                            recipe.OutputItem = context.Items.Find(recipe.OutputItemId, recipe.Language);
                            if (recipe.OutputItem == null)
                            {
                                recipe.OutputItem = itemDetailsService.GetItemDetails(recipe.OutputItemId, language);
                                recipe.OutputItem.BuildId = build.BuildId;
                                recipe.OutputItem = this.Add(recipe.OutputItem, context);
                            }

                            var ingredients = new IngredientCollection(recipe.Ingredients.Count);
                            foreach (var ingredient in recipe.Ingredients)
                            {
                                ingredients.Add(context.Ingredients.Find(ingredient.ItemId, ingredient.Count) ?? context.Ingredients.Add(ingredient));
                                ingredient.Item = context.Items.Find(ingredient.ItemId, ingredient.Language);
                                if (ingredient.Item == null)
                                {
                                    ingredient.Item = itemDetailsService.GetItemDetails(ingredient.ItemId, language);
                                    ingredient.Item.BuildId = build.BuildId;
                                    ingredient.Item = this.Add(ingredient.Item, context);
                                }
                            }

                            context.Entry(recipe).Collection(r => r.Ingredients).CurrentValue = ingredients;

                            this.Update(recipe, context);
                        }
                        catch (ServiceException)
                        {
                        }
                    }

                    context.SaveChanges();
                }
            }
        }

        /// <summary>Updates the specified item.</summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Item"/>.</returns>
        private Item Update(Item item, GwContext context)
        {
            var original = context.Items.Find(item.ItemId, item.Language);

            var upgradedItem = item as IUpgrade;
            if (upgradedItem != null && upgradedItem.Attributes.Any())
            {
                upgradedItem.Attributes = this.AddOrGetExisting(upgradedItem.Attributes, context);
            }

            context.Entry(original).CurrentValues.SetValues(item);

            return item;
        }

        /// <summary>Updates the specified recipe.</summary>
        /// <param name="recipe">The recipe.</param>
        /// <param name="context">The context.</param>
        /// <returns>The <see cref="Recipe"/>.</returns>
        private Recipe Update(Recipe recipe, GwContext context)
        {
            var original = context.Recipes.Find(recipe.RecipeId, recipe.Language);

            context.Entry(original).CurrentValues.SetValues(recipe);

            return recipe;
        }
    }
}