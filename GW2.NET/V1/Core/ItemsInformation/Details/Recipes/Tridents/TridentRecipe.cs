// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TridentRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a trident crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Tridents
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a trident crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class TridentRecipe : Recipe
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TridentRecipe" /> class.
        /// </summary>
        public TridentRecipe()
            : base(RecipeType.Trident)
        {
        }
    }
}