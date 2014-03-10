// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortBowRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a short bow crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.ShortBows
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a short bow crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class ShortBowRecipe : Recipe
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ShortBowRecipe" /> class.
        /// </summary>
        public ShortBowRecipe()
            : base(RecipeType.ShortBow)
        {
        }
    }
}