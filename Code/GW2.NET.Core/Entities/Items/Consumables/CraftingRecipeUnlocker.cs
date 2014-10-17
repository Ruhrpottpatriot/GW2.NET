// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Entities.Items
{
    using GW2NET.Entities.Recipes;

    /// <summary>Represents a crafting recipe.</summary>
    public class CraftingRecipeUnlocker : Unlocker
    {
        /// <summary>Gets or sets the recipe. This is a navigation property. Use the value of <see cref="RecipeId"/> to obtain a reference.</summary>
        public virtual Recipe Recipe { get; set; }

        /// <summary>Gets or sets the recipe identifier.</summary>
        public virtual int RecipeId { get; set; }
    }
}