// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwordRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a sword crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts.RecipeTypes
{
    /// <summary>Represents a sword crafting recipe.</summary>
    public class SwordRecipe : Recipe
    {
        /// <summary>Initializes a new instance of the <see cref="SwordRecipe" /> class.</summary>
        public SwordRecipe()
            : base(RecipeType.Sword)
        {
        }
    }
}