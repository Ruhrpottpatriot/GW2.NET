// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RefinementObsidianRecipe.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an obsidian refinement crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Contracts.RecipeTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about an obsidian refinement crafting recipe.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class RefinementObsidianRecipe : Recipe
    {
        /// <summary>Initializes a new instance of the <see cref="RefinementObsidianRecipe" /> class.</summary>
        public RefinementObsidianRecipe()
            : base(RecipeType.RefinementObsidian)
        {
        }
    }
}