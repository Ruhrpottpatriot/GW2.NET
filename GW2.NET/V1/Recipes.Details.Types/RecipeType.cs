// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates all possible recipe types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Types
{
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Enumerates all possible recipe types.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecipeType
    {
        /// <summary>The 'Unknown' recipe type.</summary>
        [EnumMember(Value = "Unknown")]
        Unknown, 

        /// <summary>The 'Axe' recipe type.</summary>
        [EnumMember(Value = "Axe")]
        Axe, 

        /// <summary>The 'Dagger' recipe type.</summary>
        [EnumMember(Value = "Dagger")]
        Dagger, 

        /// <summary>The 'Hammer' recipe type.</summary>
        [EnumMember(Value = "Hammer")]
        Hammer, 

        /// <summary>The 'Great sword' recipe type.</summary>
        [EnumMember(Value = "Greatsword")]
        GreatSword, 

        /// <summary>The 'Mace' recipe type.</summary>
        [EnumMember(Value = "Mace")]
        Mace, 

        /// <summary>The 'Shield' recipe type.</summary>
        [EnumMember(Value = "Shield")]
        Shield, 

        /// <summary>The 'Sword' recipe type.</summary>
        [EnumMember(Value = "Sword")]
        Sword, 

        /// <summary>The 'Harpoon' recipe type.</summary>
        [EnumMember(Value = "Harpoon")]
        Harpoon, 

        /// <summary>The 'Long Bow' recipe type.</summary>
        [EnumMember(Value = "LongBow")]
        LongBow, 

        /// <summary>The 'Pistol' recipe type.</summary>
        [EnumMember(Value = "Pistol")]
        Pistol, 

        /// <summary>The 'Rifle' recipe type.</summary>
        [EnumMember(Value = "Rifle")]
        Rifle, 

        /// <summary>The 'Short Bow' recipe type.</summary>
        [EnumMember(Value = "ShortBow")]
        ShortBow, 

        /// <summary>The 'Spear gun' recipe type.</summary>
        [EnumMember(Value = "Speargun")]
        SpearGun, 

        /// <summary>The 'Torch' recipe type.</summary>
        [EnumMember(Value = "Torch")]
        Torch, 

        /// <summary>The 'War horn' recipe type.</summary>
        [EnumMember(Value = "Warhorn")]
        WarHorn, 

        /// <summary>The 'Focus' recipe type.</summary>
        [EnumMember(Value = "Focus")]
        Focus, 

        /// <summary>The 'Potion' recipe type.</summary>
        [EnumMember(Value = "Potion")]
        Potion, 

        /// <summary>The 'Scepter' recipe type.</summary>
        [EnumMember(Value = "Scepter")]
        Scepter, 

        /// <summary>The 'Staff' recipe type.</summary>
        [EnumMember(Value = "Staff")]
        Staff, 

        /// <summary>The 'Trident' recipe type.</summary>
        [EnumMember(Value = "Trident")]
        Trident, 

        /// <summary>The 'Dessert' recipe type.</summary>
        [EnumMember(Value = "Dessert")]
        Dessert, 

        /// <summary>The 'Dye' recipe type.</summary>
        [EnumMember(Value = "Dye")]
        Dye, 

        /// <summary>The 'Feast' recipe type.</summary>
        [EnumMember(Value = "Feast")]
        Feast, 

        /// <summary>The 'Ingredient Cooking' recipe type.</summary>
        [EnumMember(Value = "IngredientCooking")]
        IngredientCooking, 

        /// <summary>The 'Meal' recipe type.</summary>
        [EnumMember(Value = "Meal")]
        Meal, 

        /// <summary>The 'Snack' recipe type.</summary>
        [EnumMember(Value = "Snack")]
        Snack, 

        /// <summary>The 'Soup' recipe type.</summary>
        [EnumMember(Value = "Soup")]
        Soup, 

        /// <summary>The 'Seasoning' recipe type.</summary>
        [EnumMember(Value = "Seasoning")]
        Seasoning, 

        /// <summary>The 'Amulet' recipe type.</summary>
        [EnumMember(Value = "Amulet")]
        Amulet, 

        /// <summary>The 'Earring' recipe type.</summary>
        [EnumMember(Value = "Earring")]
        Earring, 

        /// <summary>The 'Ring' recipe type.</summary>
        [EnumMember(Value = "Ring")]
        Ring, 

        /// <summary>The 'Boots' recipe type.</summary>
        [EnumMember(Value = "Boots")]
        Boots, 

        /// <summary>The 'Coat' recipe type.</summary>
        [EnumMember(Value = "Coat")]
        Coat, 

        /// <summary>The 'Gloves' recipe type.</summary>
        [EnumMember(Value = "Gloves")]
        Gloves, 

        /// <summary>The 'Helm' recipe type.</summary>
        [EnumMember(Value = "Helm")]
        Helm, 

        /// <summary>The 'Insignia' recipe type.</summary>
        [EnumMember(Value = "Insignia")]
        Insignia, 

        /// <summary>The 'Leggings' recipe type.</summary>
        [EnumMember(Value = "Leggings")]
        Leggings, 

        /// <summary>The 'Shoulders' recipe type.</summary>
        [EnumMember(Value = "Shoulders")]
        Shoulders, 

        /// <summary>The 'Bag' recipe type.</summary>
        [EnumMember(Value = "Bag")]
        Bag, 

        /// <summary>The 'Inscription' recipe type.</summary>
        [EnumMember(Value = "Inscription")]
        Inscription, 

        /// <summary>The 'Component' recipe type.</summary>
        [EnumMember(Value = "Component")]
        Component, 

        /// <summary>The 'Consumable' recipe type.</summary>
        [EnumMember(Value = "Consumable")]
        Consumable, 

        /// <summary>The 'Refinement' recipe type.</summary>
        [EnumMember(Value = "Refinement")]
        Refinement, 

        /// <summary>The 'Upgrade Component' recipe type.</summary>
        [EnumMember(Value = "UpgradeComponent")]
        UpgradeComponent, 

        /// <summary>The 'Bulk' recipe type.</summary>
        [EnumMember(Value = "Bulk")]
        Bulk
    }
}