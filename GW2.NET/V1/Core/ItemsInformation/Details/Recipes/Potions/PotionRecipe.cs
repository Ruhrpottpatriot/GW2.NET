// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PotionRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Potions
{
    /// <summary>
    ///     Represents detailed information about a potion crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class PotionRecipe : Recipe
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PotionRecipe" /> class.
        /// </summary>
        public PotionRecipe()
            : base(RecipeType.Potion)
        {
        }
    }
}