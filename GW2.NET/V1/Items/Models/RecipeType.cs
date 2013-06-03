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
        //// Weaponsmith
        
        /// <summary>
        /// The recipe crafts an axe.
        /// </summary>
        Axe,

        /// <summary>
        /// The recipe crafts a dagger.
        /// </summary>
        Dagger,

        /// <summary>
        /// The recipe crafts a hammer.
        /// </summary>
        Hammer,

        /// <summary>
        /// The recipe crafts a greatsword.
        /// </summary>
        Greatsword,

        /// <summary>
        /// The recipe crafts a mace.
        /// </summary>
        Mace,

        /// <summary>
        /// The recipe crafts a shield.
        /// </summary>
        Shield,

        /// <summary>
        /// The recipe crafts a sword.
        /// </summary>
        Sword,

        //// Huntsman

        /// <summary>
        /// The recipe crafts a harpoon.
        /// </summary>
        Harpoon,

        /// <summary>
        /// The recipe crafts a long bow.
        /// </summary>
        LongBow,

        /// <summary>
        /// The recipe crafts a pistol.
        /// </summary>
        Pistol,

        /// <summary>
        /// The recipe crafts a rifle.
        /// </summary>
        Rifle,

        /// <summary>
        /// The recipe crafts a short bow.
        /// </summary>
        ShortBow,

        /// <summary>
        /// The recipe crafts a speargun.
        /// </summary>
        Speargun,

        /// <summary>
        /// The recipe crafts a torch.
        /// </summary>
        Torch,

        /// <summary>
        /// The recipe crafts a warhorn.
        /// </summary>
        Warhorn,

        //// Artificer

        /// <summary>
        /// The recipe crafts a focus.
        /// </summary>
        Focus,

        /// <summary>
        /// The recipe crafts a potion.
        /// </summary>
        Potion,

        /// <summary>
        /// The recipe crafts a scepter.
        /// </summary>
        Scepter,

        /// <summary>
        /// The recipe crafts a staff.
        /// </summary>
        Staff,

        /// <summary>
        /// The recipe crafts a trident.
        /// </summary>
        Trident,

        //// Chef

        /// <summary>
        /// The recipe crafts a dessert.
        /// </summary>
        Dessert,

        /// <summary>
        /// The recipe crafts a dye.
        /// </summary>
        Dye,

        /// <summary>
        /// The recipe crafts a feast.
        /// </summary>
        Feast,

        /// <summary>
        /// The recipe crafts a cooking ingredient.
        /// </summary>
        IngredientCooking,

        /// <summary>
        /// The recipe crafts a meal.
        /// </summary>
        Meal,

        /// <summary>
        /// The recipe crafts a snack.
        /// </summary>
        Snack,

        /// <summary>
        /// The recipe crafts a soup.
        /// </summary>
        Soup,

        /// <summary>
        /// The recipe crafts a seasoning.
        /// </summary>
        Seasoning,
      
        //// Jeweler

        /// <summary>
        /// The recipe crafts an amulet.
        /// </summary>
        Amulet,

        /// <summary>
        /// The recipe crafts an earring.
        /// </summary>
        Earring,

        /// <summary>
        /// The recipe crafts a ring.
        /// </summary>
        Ring,

        //// Armorsmith, Leatherworker, Tailor

        /// <summary>
        /// The recipe crafts a pair of boots.
        /// </summary>
        Boots,

        /// <summary>
        /// The recipe crafts a coat.
        /// </summary>
        Coat,

        /// <summary>
        /// The recipe crafts a glove.
        /// </summary>
        Gloves,

        /// <summary>
        /// The recipe crafts a helm.
        /// </summary>
        Helm,

        /// <summary>
        /// The recipe crafts an insignia.
        /// </summary>
        Insignia,

        /// <summary>
        /// The recipe crafts a leggings.
        /// </summary>
        Leggings,

        /// <summary>
        /// The recipe crafts a shoulder.
        /// </summary>
        Shoulders,

        /// <summary>
        /// The recipe crafts a bag.
        /// </summary>
        Bag,

        //// Artificer, Huntsman, Weaponsmith

        /// <summary>
        /// The recipe crafts an inscription.
        /// </summary>
        Inscription,

        //// All professions (excluding Chef)

        /// <summary>
        /// The recipe crafts a component.
        /// </summary>
        Component,

        /// <summary>
        /// The recipe crafts a consumable.
        /// </summary>
        Consumable,

        /// <summary>
        /// The recipe crafts a refinement.
        /// </summary>
        Refinement,

        /// <summary>
        /// The recipe crafts an upgrade component.
        /// </summary>
        UpgradeComponent,

        //// Unspecified

        /// <summary>
        /// The recipe crafts a bulk.
        /// </summary>
        Bulk
    }
}