// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a consumable crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.ItemsInformation.Details.Recipes.Consumable
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a consumable crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class ConsumableRecipe : Recipe
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConsumableRecipe" /> class.
        /// </summary>
        public ConsumableRecipe()
            : base(RecipeType.Consumable)
        {
        }
    }
}