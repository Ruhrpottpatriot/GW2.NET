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
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Recipes;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Recipes.Contracts;

    /// <summary>Provides the default implementation of the recipe service.</summary>
    public class RecipeService : IRecipeService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="RecipeService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public RecipeService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipe)
        {
            return this.GetRecipeDetails(recipe, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="language">The language.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Recipe GetRecipeDetails(int recipe, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new RecipeDetailsRequest { RecipeId = recipe, Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<RecipeContract>());
            var value = MapRecipeContracts(response.Content);
            value.Language = language.TwoLetterISOLanguageName;
            return value;
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe)
        {
            return this.GetRecipeDetailsAsync(recipe, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a recipe and its localized details.</summary>
        /// <param name="recipe">The recipe identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A recipe and its localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipe_details">wiki</a> for more information.</remarks>
        public Task<Recipe> GetRecipeDetailsAsync(int recipe, CancellationToken cancellationToken)
        {
            return this.GetRecipeDetailsAsync(recipe, CultureInfo.GetCultureInfo("en"), cancellationToken);
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
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new RecipeDetailsRequest { RecipeId = recipe, Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<RecipeContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        var value = MapRecipeContracts(response.Content);
                        value.Language = language.TwoLetterISOLanguageName;
                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of discovered recipes.</summary>
        /// <returns>A collection of discovered recipes.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/recipes">wiki</a> for more information.</remarks>
        public ICollection<int> GetRecipes()
        {
            var request = new RecipeRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<RecipeCollectionContract>());
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<RecipeCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return response.Content.Recipes;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Maps type discriminators to .NET types.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The corresponding <see cref="System.Type"/>.</returns>
        private static Type GetRecipeType(RecipeContract content)
        {
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
            return (CraftingDisciplines)Enum.Parse(typeof(CraftingDisciplines), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static CraftingDisciplines MapCraftingDisciplines(IEnumerable<string> content)
        {
            return content.Aggregate(CraftingDisciplines.None, (flags, flag) => flags |= MapCraftingDiscipline(flag));
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Ingredient MapIngredientContract(IngredientContract content)
        {
            return new Ingredient { ItemId = int.Parse(content.ItemId), Count = int.Parse(content.Count) };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<Ingredient> MapIngredientContracts(ICollection<IngredientContract> content)
        {
            var values = new List<Ingredient>(content.Count);
            values.AddRange(content.Select(MapIngredientContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Recipe MapRecipeContracts(RecipeContract content)
        {
            // Map type discriminators to .NET types
            var value = (Recipe)Activator.CreateInstance(GetRecipeType(content));

            // Map recipe identifier
            value.RecipeId = int.Parse(content.RecipeId);

            // Map output item identifier
            value.OutputItemId = int.Parse(content.OutputItemId);

            // Map output item count
            value.OutputItemCount = int.Parse(content.OutputItemCount);

            // Map minimum rating
            value.MinimumRating = int.Parse(content.MinimumRating);

            // Map time to craft
            value.TimeToCraft = TimeSpan.FromMilliseconds(double.Parse(content.TimeToCraft));

            // Map crafting disciplines
            value.CraftingDisciplines = MapCraftingDisciplines(content.CraftingDisciplines);

            // Map recipe flags
            value.Flags = MapRecipeFlags(content.Flags);

            // Map ingredients
            value.Ingredients = MapIngredientContracts(content.Ingredients);
            return value;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static RecipeFlags MapRecipeFlag(string content)
        {
            return (RecipeFlags)Enum.Parse(typeof(RecipeFlags), content, true);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static RecipeFlags MapRecipeFlags(IEnumerable<string> content)
        {
            return content.Aggregate(RecipeFlags.None, (flags, flag) => flags |= MapRecipeFlag(flag));
        }
    }
}