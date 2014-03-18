// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends  from its
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Recipes.Details
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Core.Common.Converters;
    using GW2DotNET.V1.Core.Recipes.Details.RecipeTypes;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="Recipe" /> from its <see cref="System.String" />
    /// representation.</summary>
    public class RecipeConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<RecipeType, Type> KnownTypes = new Dictionary<RecipeType, Type>();

        /// <summary>Initializes static members of the <see cref="RecipeConverter" /> class.</summary>
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

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return KnownTypes.Values.Contains(objectType);
        }

        /// <summary>Gets the object type that will be used by the serializer.</summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        public override Type GetTargetType(Type objectType, JObject content)
        {
            var jsonToken = content["type"];

            if (jsonToken == null)
            {
                return typeof(UnknownRecipe);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                RecipeType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<RecipeType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownRecipe);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownRecipe);
            }
            finally
            {
                content.Remove("type");
            }
        }
    }
}