// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwordRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a sword crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Recipes.Details.RecipeTypes
{
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a sword crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class SwordRecipe : Recipe
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SwordRecipe" /> class.
        /// </summary>
        public SwordRecipe()
            : base(RecipeType.Sword)
        {
        }
    }
}