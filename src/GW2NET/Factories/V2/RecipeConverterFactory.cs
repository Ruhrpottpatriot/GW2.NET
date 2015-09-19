namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Recipes;
    using GW2NET.V2.Recipes.Converters;
    using GW2NET.V2.Recipes.Json;

    public class RecipeConverterFactory : ITypeConverterFactory<RecipeDTO, Recipe>
    {
        public IConverter<RecipeDTO, Recipe> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Amulet":
                    return new AmuletRecipeConverter();
                case "Axe":
                    return new AxeRecipeConverter();
                case "Backpack":
                    return new BackpackRecipeConverter();
                case "Bag":
                    return new BagRecipeConverter();
                case "Boots":
                    return new BootsRecipeConverter();
                case "Bulk":
                    return new BulkRecipeConverter();
                case "Coat":
                    return new CoatRecipeConverter();
                case "Component":
                    return new ComponentRecipeConverter();
                case "Consumable":
                    return new ConsumableRecipeConverter();
                case "Dagger":
                    return new DaggerRecipeConverter();
                case "Dessert":
                    return new DessertRecipeConverter();
                case "Dye":
                    return new DyeRecipeConverter();
                case "Earring":
                    return new EarringRecipeConverter();
                case "Feast":
                    return new FeastRecipeConverter();
                case "Focus":
                    return new FocusRecipeConverter();
                case "Gloves":
                    return new GlovesRecipeConverter();
                case "Greatsword":
                    return new GreatSwordRecipeConverter();
                case "Hammer":
                    return new HammerRecipeConverter();
                case "Harpoon":
                    return new HarpoonRecipeConverter();
                case "Helm":
                    return new HelmRecipeConverter();
                case "IngredientCooking":
                    return new IngredientCookingRecipeConverter();
                case "Inscription":
                    return new InscriptionRecipeConverter();
                case "Insignia":
                    return new InsigniaRecipeConverter();
                case "Leggings":
                    return new LeggingsRecipeConverter();
                case "LongBow":
                    return new LongBowRecipeConverter();
                case "Mace":
                    return new MaceRecipeConverter();
                case "Meal":
                    return new MealRecipeConverter();
                case "Pistol":
                    return new PistolRecipeConverter();
                case "Potion":
                    return new PotionRecipeConverter();
                case "RefinementEctoplasm":
                    return new RefinementEctoplasmRecipeConverter();
                case "RefinementObsidian":
                    return new RefinementObsidianRecipeConverter();
                case "Refinement":
                    return new RefinementRecipeConverter();
                case "Rifle":
                    return new RifleRecipeConverter();
                case "Ring":
                    return new RingRecipeConverter();
                case "Scepter":
                    return new ScepterRecipeConverter();
                case "Seasoning":
                    return new SeasoningRecipeConverter();
                case "Shield":
                    return new ShieldRecipeConverter();
                case "ShortBow":
                    return new ShortBowRecipeConverter();
                case "Shoulders":
                    return new ShouldersRecipeConverter();
                case "Snack":
                    return new SnackRecipeConverter();
                case "Soup":
                    return new SoupRecipeConverter();
                case "Speargun":
                    return new SpearGunRecipeConverter();
                case "Staff":
                    return new StaffRecipeConverter();
                case "Sword":
                    return new SwordRecipeConverter();
                case "Torch":
                    return new TorchRecipeConverter();
                case "Trident":
                    return new TridentRecipeConverter();
                case "UpgradeComponent":
                    return new UpgradeComponentRecipeConverter();
                case "Warhorn":
                    return new WarHornRecipeConverter();
                default:
                    return new UnknownRecipeConverter();
            }
        }
    }
}