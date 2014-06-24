// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoatRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a coat crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts.RecipeTypes
{
    /// <summary>Represents a coat crafting recipe.</summary>
    public class CoatRecipe : Recipe
    {
        /// <summary>Initializes a new instance of the <see cref="CoatRecipe" /> class.</summary>
        public CoatRecipe()
            : base(RecipeType.Coat)
        {
        }
    }
}