// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HarpoonRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a harpoon crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.RecipesDetails.Types.RecipeTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a harpoon crafting recipe.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class HarpoonRecipe : Recipe
    {
        /// <summary>Initializes a new instance of the <see cref="HarpoonRecipe" /> class.</summary>
        public HarpoonRecipe()
            : base(RecipeType.Harpoon)
        {
        }
    }
}