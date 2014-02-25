// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ErrorInformation;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Amulets;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Axes;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Bags;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Boots;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Bulks;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Coats;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Components;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.CookingIngredients;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Daggers;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Desserts;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Dyes;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Earrings;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Feasts;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Focuses;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Gloves;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.GreatSwords;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Hammers;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Harpoons;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Helms;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Inscriptions;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Insignias;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Leggings;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.LongBows;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Maces;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Meals;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Pistols;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Potions;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Refinements;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Rifles;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Rings;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Scepters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Seasonings;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Shields;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.ShortBows;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Shoulders;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Snacks;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Soups;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.SpearGuns;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Staves;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Swords;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Torches;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Tridents;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Unknown;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.UpgradeComponents;
using GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.WarHorns;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemsInformation.Details
{
    /// <summary>
    /// Converts an instance of a class that extends <see cref="Recipe"/> from its <see cref="System.String"/> representation.
    /// </summary>
    public class RecipeConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of known JSON values and their corresponding type.
        /// </summary>
        private static readonly IDictionary<RecipeType, Type> KnownTypes = new Dictionary<RecipeType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="RecipeConverter"/> class.
        /// </summary>
        static RecipeConverter()
        {
            KnownTypes.Add(RecipeType.Unknown, typeof(UnknownRecipe));
            KnownTypes.Add(RecipeType.Axe, typeof(AxeRecipe));
            KnownTypes.Add(RecipeType.Dagger, typeof(DaggerRecipe));
            KnownTypes.Add(RecipeType.Hammer, typeof(HammerRecipe));
            KnownTypes.Add(RecipeType.GreatSword, typeof(GreatSwordRecipe));
            KnownTypes.Add(RecipeType.Mace, typeof(MaceRecipe));
            KnownTypes.Add(RecipeType.Shield, typeof(ShieldRecipe));
            KnownTypes.Add(RecipeType.Sword, typeof(SwordRecipe));
            KnownTypes.Add(RecipeType.Harpoon, typeof(HarpoonRecipe));
            KnownTypes.Add(RecipeType.LongBow, typeof(LongBowRecipe));
            KnownTypes.Add(RecipeType.Pistol, typeof(PistolRecipe));
            KnownTypes.Add(RecipeType.Rifle, typeof(RifleRecipe));
            KnownTypes.Add(RecipeType.ShortBow, typeof(ShortBowRecipe));
            KnownTypes.Add(RecipeType.SpearGun, typeof(SpearGunRecipe));
            KnownTypes.Add(RecipeType.Torch, typeof(TorchRecipe));
            KnownTypes.Add(RecipeType.WarHorn, typeof(WarHornRecipe));
            KnownTypes.Add(RecipeType.Focus, typeof(FocusRecipe));
            KnownTypes.Add(RecipeType.Potion, typeof(PotionRecipe));
            KnownTypes.Add(RecipeType.Scepter, typeof(ScepterRecipe));
            KnownTypes.Add(RecipeType.Staff, typeof(StaffRecipe));
            KnownTypes.Add(RecipeType.Trident, typeof(TridentRecipe));
            KnownTypes.Add(RecipeType.Dessert, typeof(DessertRecipe));
            KnownTypes.Add(RecipeType.Dye, typeof(DyeRecipe));
            KnownTypes.Add(RecipeType.Feast, typeof(FeastRecipe));
            KnownTypes.Add(RecipeType.IngredientCooking, typeof(CookingIngredientRecipe));
            KnownTypes.Add(RecipeType.Meal, typeof(MealRecipe));
            KnownTypes.Add(RecipeType.Snack, typeof(SnackRecipe));
            KnownTypes.Add(RecipeType.Soup, typeof(SoupRecipe));
            KnownTypes.Add(RecipeType.Seasoning, typeof(SeasoningRecipe));
            KnownTypes.Add(RecipeType.Amulet, typeof(AmuletRecipe));
            KnownTypes.Add(RecipeType.Earring, typeof(EarringRecipe));
            KnownTypes.Add(RecipeType.Ring, typeof(RingRecipe));
            KnownTypes.Add(RecipeType.Boots, typeof(BootsRecipe));
            KnownTypes.Add(RecipeType.Coat, typeof(CoatRecipe));
            KnownTypes.Add(RecipeType.Gloves, typeof(GlovesRecipe));
            KnownTypes.Add(RecipeType.Helm, typeof(HelmRecipe));
            KnownTypes.Add(RecipeType.Insignia, typeof(InsigniaRecipe));
            KnownTypes.Add(RecipeType.Leggings, typeof(LeggingsRecipe));
            KnownTypes.Add(RecipeType.Shoulders, typeof(ShouldersRecipe));
            KnownTypes.Add(RecipeType.Bag, typeof(BagRecipe));
            KnownTypes.Add(RecipeType.Inscription, typeof(InscriptionRecipe));
            KnownTypes.Add(RecipeType.Component, typeof(ComponentRecipe));
            KnownTypes.Add(RecipeType.Refinement, typeof(RefinementRecipe));
            KnownTypes.Add(RecipeType.UpgradeComponent, typeof(UpgradeComponentRecipe));
            KnownTypes.Add(RecipeType.Bulk, typeof(BulkRecipe));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return KnownTypes.Values.Contains(objectType);
        }

        /// <summary>
        /// Gets the object type that will be used by the serializer.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        public override Type GetTargetType(Type objectType, JObject content)
        {
            if (content["type"] == null)
            {
                throw new JsonSerializationException(content.ToObject<ErrorResult>().Text);
            }

            var jsonValue = JsonSerializer.Create().Deserialize<RecipeType>(content["type"].CreateReader());

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                return typeof(UnknownRecipe);
            }

            return targetType;
        }
    }
}