// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaffRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a staff crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts.RecipeTypes
{
    using GW2DotNET.Common;

    /// <summary>Represents a staff crafting recipe.</summary>
    [TypeDiscriminator(Value = "Staff", BaseType = typeof(Recipe))]
    public class StaffRecipe : Recipe
    {
    }
}