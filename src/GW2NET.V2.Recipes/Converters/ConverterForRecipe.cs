// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RecipeDataContract" /> to objects of type <see cref="Recipe" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V2.Recipes
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.Recipes;

    /// <summary>Converts objects of type <see cref="RecipeDataContract"/> to objects of type <see cref="Recipe"/>.</summary>
    internal sealed class ConverterForRecipe : IConverter<RecipeDataContract, Recipe>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, CraftingDisciplines> converterForCraftingDisciplineCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<IngredientDataContract>, ICollection<ItemStack>> converterForItemStackCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, RecipeFlags> converterForRecipeFlagCollection;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<RecipeDataContract, Recipe>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipe"/> class.</summary>
        public ConverterForRecipe()
            : this(GetKnownTypeConverters(), new ConverterForCraftingDisciplineCollection(), new ConverterForRecipeFlagCollection(), new ConverterForCollection<IngredientDataContract, ItemStack>(new ConverterForItemStack()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRecipe"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForCraftingDisciplineCollection">The converter for <see cref="CraftingDisciplines"/>.</param>
        /// <param name="converterForRecipeFlagCollection">The converter for <see cref="RecipeFlags"/>.</param>
        /// <param name="converterForItemStackCollection">The converter for <see cref="T:ICollection{ItemStack}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="typeConverters"/> or <paramref name="converterForCraftingDisciplineCollection"/> or <paramref name="converterForRecipeFlagCollection"/> or <paramref name="converterForItemStackCollection"/> is a null reference.</exception>
        public ConverterForRecipe(IDictionary<string, IConverter<RecipeDataContract, Recipe>> typeConverters, IConverter<ICollection<string>, CraftingDisciplines> converterForCraftingDisciplineCollection, IConverter<ICollection<string>, RecipeFlags> converterForRecipeFlagCollection, IConverter<ICollection<IngredientDataContract>, ICollection<ItemStack>> converterForItemStackCollection)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            if (converterForCraftingDisciplineCollection == null)
            {
                throw new ArgumentNullException("converterForCraftingDisciplineCollection", "Precondition: converterForCraftingDisciplineCollection != null");
            }

            if (converterForRecipeFlagCollection == null)
            {
                throw new ArgumentNullException("converterForRecipeFlagCollection", "Precondition: converterForRecipeFlagCollection != null");
            }

            if (converterForItemStackCollection == null)
            {
                throw new ArgumentNullException("converterForItemStackCollection", "Precondition: converterForItemStackCollection != null");
            }

            this.converterForCraftingDisciplineCollection = converterForCraftingDisciplineCollection;
            this.converterForRecipeFlagCollection = converterForRecipeFlagCollection;
            this.converterForItemStackCollection = converterForItemStackCollection;
            this.typeConverters = typeConverters;
        }

        /// <inheritdoc />
        public Recipe Convert(RecipeDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            Recipe recipe;
            IConverter<RecipeDataContract, Recipe> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                recipe = converter.Convert(value);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + value.Type);
                recipe = new UnknownRecipe();
            }

            recipe.RecipeId = value.Id;
            recipe.ChatLink = value.ChatLink;
            recipe.OutputItemId = value.OutputItemId;
            recipe.OutputItemCount = value.OutputItemCount;
            recipe.MinimumRating = value.MinRating;
            recipe.TimeToCraft = TimeSpan.FromMilliseconds(value.TimeToCraftMs);

            var craftingDisciplines = value.Disciplines;
            if (craftingDisciplines != null)
            {
                recipe.CraftingDisciplines = this.converterForCraftingDisciplineCollection.Convert(craftingDisciplines);
            }

            var flags = value.Flags;
            if (flags != null)
            {
                recipe.Flags = this.converterForRecipeFlagCollection.Convert(flags);
            }

            var ingredients = value.Ingredients;
            if (ingredients != null)
            {
                recipe.Ingredients = this.converterForItemStackCollection.Convert(ingredients);
            }

            return recipe;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<RecipeDataContract, Recipe>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<RecipeDataContract, Recipe>>
            {
                { "Amulet", new ConverterForObject<AmuletRecipe>() },
                { "Axe", new ConverterForObject<AxeRecipe>() },
                { "Backpack", new ConverterForObject<BackpackRecipe>() },
                { "Bag", new ConverterForObject<BagRecipe>() },
                { "Boots", new ConverterForObject<BootsRecipe>() },
                { "Bulk", new ConverterForObject<BulkRecipe>() },
                { "Coat", new ConverterForObject<CoatRecipe>() },
                { "Component", new ConverterForObject<ComponentRecipe>() },
                { "Consumable", new ConverterForObject<ConsumableRecipe>() },
                { "Dagger", new ConverterForObject<DaggerRecipe>() },
                { "Dessert", new ConverterForObject<DessertRecipe>() },
                { "Dye", new ConverterForObject<DyeRecipe>() },
                { "Earring", new ConverterForObject<EarringRecipe>() },
                { "Feast", new ConverterForObject<FeastRecipe>() },
                { "Focus", new ConverterForObject<FocusRecipe>() },
                { "Gloves", new ConverterForObject<GlovesRecipe>() },
                { "Greatsword", new ConverterForObject<GreatSwordRecipe>() },
                { "GuildConsumableWvw", new ConverterForObject<GuildConsumableWvw>() },
                { "Hammer", new ConverterForObject<HammerRecipe>() },
                { "Harpoon", new ConverterForObject<HarpoonRecipe>() },
                { "Helm", new ConverterForObject<HelmRecipe>() },
                { "IngredientCooking", new ConverterForObject<IngredientCookingRecipe>() },
                { "Inscription", new ConverterForObject<InscriptionRecipe>() },
                { "Insignia", new ConverterForObject<InsigniaRecipe>() },
                { "LegendaryComponent", new ConverterForObject<LegendaryComponent>() },
                { "Leggings", new ConverterForObject<LeggingsRecipe>() },
                { "LongBow", new ConverterForObject<LongBowRecipe>() },
                { "Mace", new ConverterForObject<MaceRecipe>() },
                { "Meal", new ConverterForObject<MealRecipe>() },
                { "Pistol", new ConverterForObject<PistolRecipe>() },
                { "Potion", new ConverterForObject<PotionRecipe>() },
                { "RefinementEctoplasm", new ConverterForObject<RefinementEctoplasmRecipe>() },
                { "RefinementObsidian", new ConverterForObject<RefinementObsidianRecipe>() },
                { "Refinement", new ConverterForObject<RefinementRecipe>() },
                { "Rifle", new ConverterForObject<RifleRecipe>() },
                { "Ring", new ConverterForObject<RingRecipe>() },
                { "Scepter", new ConverterForObject<ScepterRecipe>() },
                { "Seasoning", new ConverterForObject<SeasoningRecipe>() },
                { "Shield", new ConverterForObject<ShieldRecipe>() },
                { "ShortBow", new ConverterForObject<ShortBowRecipe>() },
                { "Shoulders", new ConverterForObject<ShouldersRecipe>() },
                { "Snack", new ConverterForObject<SnackRecipe>() },
                { "Soup", new ConverterForObject<SoupRecipe>() },
                { "Speargun", new ConverterForObject<SpearGunRecipe>() },
                { "Staff", new ConverterForObject<StaffRecipe>() },
                { "Sword", new ConverterForObject<SwordRecipe>() },
                { "Torch", new ConverterForObject<TorchRecipe>() },
                { "Trident", new ConverterForObject<TridentRecipe>() },
                { "UpgradeComponent", new ConverterForObject<UpgradeComponentRecipe>() },
                { "Warhorn", new ConverterForObject<WarHornRecipe>() },
            };
        }
    }
}