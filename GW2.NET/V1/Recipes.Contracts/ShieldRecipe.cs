// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShieldRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a shield crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Contracts
{
    using GW2DotNET.Common;

    /// <summary>Represents a shield crafting recipe.</summary>
    [TypeDiscriminator(Value = "Shield", BaseType = typeof(Recipe))]
    public class ShieldRecipe : Recipe
    {
    }
}