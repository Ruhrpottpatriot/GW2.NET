// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeType.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Enumerates all possible recipe types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Models
{
    /// <summary>
    /// Enumerates all possible recipe types.
    /// </summary>
    public enum RecipeType
    {
        // Weaponsmith
        Axe,
        Dagger,
        Hammer,
        Greatsword,
        Mace,
        Shield,
        Sword,

        // Huntsman
        Harpoon,
        LongBow,
        Pistol,
        Rifle,
        ShortBow,
        Speargun,
        Torch,
        Warhorn,

        //Artificer
        Focus,
        Potion,
        Scepter,
        Staff,
        Trident,

        //Chef
        Dessert,
        Dye,
        Feast,
        IngredientCooking,
        Meal,
        Snack,
        Soup,
        Seasoning,

        // Jeweler
        Amulet,
        Earring,
        Ring,

        // Armorsmith, Leatherworker, Tailor
        Boots,
        Coat,
        Gloves,
        Helm,
        Insignia,
        Leggings,
        Shoulders,
        Bag,

        // Artificer, Huntsman, Weaponsmith
        Inscription,

        // All professions (excluding Chef)
        Component,
        Consumable,
        Refinement,
        UpgradeComponent,

        // ?
        Bulk,
        Armor
    }
}