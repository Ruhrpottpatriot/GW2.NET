// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the recipe service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Items;
    using GW2DotNET.Entities.Recipes;
    using GW2DotNET.V1.Recipes.Json;

    /// <summary>Provides the default implementation of the recipe service.</summary>
    public class RecipeService : IRecipeService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipe)
        {
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetRecipeDetails(recipe, culture);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipe, CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new RecipeDetailsRequest { RecipeId = recipe, Culture = language };
            var response = this.serviceClient.Send<RecipeContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            var value = ConvertRecipeContractCollection(response.Content);
            value.Language = (response.Culture ?? language).TwoLetterISOLanguageName;
            return value;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe)
        {
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetRecipeDetailsAsync(recipe, culture, CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetRecipeDetailsAsync(recipe, culture, cancellationToken);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CultureInfo language)
        {
            return this.GetRecipeDetailsAsync(recipe, language, CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CultureInfo language, CancellationToken cancellationToken)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new RecipeDetailsRequest { RecipeId = recipe, Culture = language };
            return this.serviceClient.SendAsync<RecipeContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        var value = ConvertRecipeContractCollection(response.Content);
                        value.Language = (response.Culture ?? language).TwoLetterISOLanguageName;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public ICollection<int> GetRecipes()
        {
            Contract.Ensures(Contract.Result<ICollection<int>>() != null);
            var request = new RecipeRequest();
            var response = this.serviceClient.Send<RecipeCollectionContract>(request);
            if (response.Content == null || response.Content.Recipes == null)
            {
                return new int[0];
            }

            return response.Content.Recipes;
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetRecipesAsync()
        {
            return this.GetRecipesAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public Task<ICollection<int>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            var request = new RecipeRequest();
            return this.serviceClient.SendAsync<RecipeCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Recipes == null)
                        {
                            return new int[0];
                        }

                        return response.Content.Recipes;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ItemStack ConvertIngredientContract(IngredientContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.ItemId != null);
            Contract.Requires(content.Count != null);

            // Create a new item stack object
            var value = new ItemStack();

            // Set the item identifier
            if (content.ItemId != null)
            {
                value.ItemId = int.Parse(content.ItemId);
            }

            // Set the size of the stack
            if (content.Count != null)
            {
                var count = int.Parse(content.Count);
                if (count >= 1 && count <= 255)
                {
                    value.Count = count;
                }
            }

            // Return the item stack object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<ItemStack> ConvertIngredientContractCollection(ICollection<IngredientContract> content)
        {
            Contract.Requires(content != null);
            var values = new List<ItemStack>(content.Count);
            values.AddRange(content.Select(ConvertIngredientContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Recipe ConvertRecipeContractCollection(RecipeContract content)
        {
            Contract.Requires(content != null);

            // Map type discriminators to .NET types
            var value = (Recipe)Activator.CreateInstance(GetRecipeType(content));

            // Map recipe identifier
            if (content.RecipeId != null)
            {
                value.RecipeId = int.Parse(content.RecipeId);
            }

            // Map output item identifier
            if (content.OutputItemId != null)
            {
                value.OutputItemId = int.Parse(content.OutputItemId);
            }

            // Map output item count
            if (content.OutputItemCount != null)
            {
                value.OutputItemCount = int.Parse(content.OutputItemCount);
            }

            // Map minimum rating
            if (content.MinimumRating != null)
            {
                value.MinimumRating = int.Parse(content.MinimumRating);
            }

            // Map time to craft
            if (content.TimeToCraft != null)
            {
                value.TimeToCraft = TimeSpan.FromMilliseconds(double.Parse(content.TimeToCraft));
            }

            // Map crafting disciplines
            if (content.CraftingDisciplines != null)
            {
                value.CraftingDisciplines = MapCraftingDisciplines(content.CraftingDisciplines);
            }

            // Map recipe flags
            if (content.Flags != null)
            {
                value.Flags = MapRecipeFlags(content.Flags);
            }

            // Map ingredients
            if (content.Ingredients != null)
            {
                value.Ingredients = ConvertIngredientContractCollection(content.Ingredients);
            }

            return value;
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetRecipeType(RecipeContract content)
        {
            Contract.Requires(content != null);
            switch (content.Type)
            {
                case "Amulet":
                    return typeof(AmuletRecipe);
                case "Axe":
                    return typeof(AxeRecipe);
                case "Backpack":
                    return typeof(BackpackRecipe);
                case "Bag":
                    return typeof(BagRecipe);
                case "Boots":
                    return typeof(BootsRecipe);
                case "Bulk":
                    return typeof(BulkRecipe);
                case "Coat":
                    return typeof(CoatRecipe);
                case "Component":
                    return typeof(ComponentRecipe);
                case "Consumable":
                    return typeof(ConsumableRecipe);
                case "Dagger":
                    return typeof(DaggerRecipe);
                case "Dessert":
                    return typeof(DessertRecipe);
                case "Dye":
                    return typeof(DyeRecipe);
                case "Earring":
                    return typeof(EarringRecipe);
                case "Feast":
                    return typeof(FeastRecipe);
                case "Focus":
                    return typeof(FocusRecipe);
                case "Gloves":
                    return typeof(GlovesRecipe);
                case "Greatsword":
                    return typeof(GreatSwordRecipe);
                case "Hammer":
                    return typeof(HammerRecipe);
                case "Harpoon":
                    return typeof(HarpoonRecipe);
                case "Helm":
                    return typeof(HelmRecipe);
                case "IngredientCooking":
                    return typeof(IngredientCookingRecipe);
                case "Inscription":
                    return typeof(InscriptionRecipe);
                case "Insignia":
                    return typeof(InsigniaRecipe);
                case "Leggings":
                    return typeof(LeggingsRecipe);
                case "LongBow":
                    return typeof(LongBowRecipe);
                case "Mace":
                    return typeof(MaceRecipe);
                case "Meal":
                    return typeof(MealRecipe);
                case "Pistol":
                    return typeof(PistolRecipe);
                case "Potion":
                    return typeof(PotionRecipe);
                case "RefinementEctoplasm":
                    return typeof(RefinementEctoplasmRecipe);
                case "RefinementObsidian":
                    return typeof(RefinementObsidianRecipe);
                case "Refinement":
                    return typeof(RefinementRecipe);
                case "Rifle":
                    return typeof(RifleRecipe);
                case "Ring":
                    return typeof(RingRecipe);
                case "Scepter":
                    return typeof(ScepterRecipe);
                case "Seasoning":
                    return typeof(SeasoningRecipe);
                case "Shield":
                    return typeof(ShieldRecipe);
                case "ShortBow":
                    return typeof(ShortBowRecipe);
                case "Shoulders":
                    return typeof(ShouldersRecipe);
                case "Snack":
                    return typeof(SnackRecipe);
                case "Soup":
                    return typeof(SoupRecipe);
                case "Speargun":
                    return typeof(SpearGunRecipe);
                case "Staff":
                    return typeof(StaffRecipe);
                case "Sword":
                    return typeof(SwordRecipe);
                case "Torch":
                    return typeof(TorchRecipe);
                case "Trident":
                    return typeof(TridentRecipe);
                case "UpgradeComponent":
                    return typeof(UpgradeComponentRecipe);
                case "Warhorn":
                    return typeof(WarHornRecipe);
                default:
                    return typeof(UnknownRecipe);
            }
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static CraftingDisciplines MapCraftingDiscipline(string content)
        {
            Contract.Requires(content != null);
            return (CraftingDisciplines)Enum.Parse(typeof(CraftingDisciplines), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static CraftingDisciplines MapCraftingDisciplines(IEnumerable<string> content)
        {
            return content.Aggregate(CraftingDisciplines.None, (flags, flag) => flags | MapCraftingDiscipline(flag));
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static RecipeFlags MapRecipeFlag(string content)
        {
            Contract.Requires(content != null);
            return (RecipeFlags)Enum.Parse(typeof(RecipeFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static RecipeFlags MapRecipeFlags(IEnumerable<string> content)
        {
            return content.Aggregate(RecipeFlags.None, (flags, flag) => flags | MapRecipeFlag(flag));
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}