// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using GW2NET.Recipes;

    /// <summary>Represents a crafting recipe.</summary>
    public class CraftingRecipeUnlocker : Unlocker
    {
        private static readonly int[] EmptyExtraRecipeIds = new int[0];

        private int[] extraRecipeIds = EmptyExtraRecipeIds;

        /// <summary>Gets or sets the recipe. This is a navigation property. Use the value of <see cref="RecipeId"/> to obtain a reference.</summary>
        public virtual Recipe Recipe { get; set; }

        /// <summary>Gets or sets the identifier of the recipe that is unlocked by the current item.</summary>
        public virtual int RecipeId { get; set; }

        /// <summary>Gets or sets the identifiers of additional recipes that are unlocked by the current item.</summary>
        public virtual int[] ExtraRecipeIds
        {
            get
            {
                return extraRecipeIds;
            }
            set
            {
                extraRecipeIds = value ?? EmptyExtraRecipeIds;
            }
        }
    }
}