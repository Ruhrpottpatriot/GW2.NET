// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BootsRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Boots
{
    /// <summary>
    /// Represents detailed information about a boots crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class BootsRecipe : Recipe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BootsRecipe"/> class.
        /// </summary>
        public BootsRecipe()
            : base(RecipeType.Boots)
        {
        }
    }
}