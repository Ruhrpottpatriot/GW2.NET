// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RecipeDataContract" /> to objects of type <see cref="Recipe" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

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
        public ConverterForRecipe(IDictionary<string, IConverter<RecipeDataContract, Recipe>> typeConverters, IConverter<ICollection<string>, CraftingDisciplines> converterForCraftingDisciplineCollection, IConverter<ICollection<string>, RecipeFlags> converterForRecipeFlagCollection, IConverter<ICollection<IngredientDataContract>, ICollection<ItemStack>> converterForItemStackCollection)
        {
            Contract.Requires(converterForCraftingDisciplineCollection != null);
            Contract.Requires(converterForRecipeFlagCollection != null);
            Contract.Requires(converterForItemStackCollection != null);
            this.converterForCraftingDisciplineCollection = converterForCraftingDisciplineCollection;
            this.converterForRecipeFlagCollection = converterForRecipeFlagCollection;
            this.converterForItemStackCollection = converterForItemStackCollection;
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="RecipeDataContract"/> to an object of type <see cref="Recipe"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Recipe Convert(RecipeDataContract value)
        {
            Contract.Assume(value != null);
            Recipe recipe;
            IConverter<RecipeDataContract, Recipe> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                recipe = converter.Convert(value);
            }
            else
            {
                recipe = new UnknownRecipe();
            }

            recipe.RecipeId = value.Id;
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
                { "Hammer", new ConverterForObject<HammerRecipe>() }, 
                { "Harpoon", new ConverterForObject<HarpoonRecipe>() }, 
                { "Helm", new ConverterForObject<HelmRecipe>() }, 
                { "IngredientCooking", new ConverterForObject<IngredientCookingRecipe>() }, 
                { "Inscription", new ConverterForObject<InscriptionRecipe>() }, 
                { "Insignia", new ConverterForObject<InsigniaRecipe>() }, 
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.converterForCraftingDisciplineCollection != null);
            Contract.Invariant(this.converterForRecipeFlagCollection != null);
            Contract.Invariant(this.converterForItemStackCollection != null);
        }
    }
}