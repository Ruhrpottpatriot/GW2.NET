// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CookingIngredientRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a consumable cooking ingredient recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Recipes.Details.Types.RecipeTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a consumable cooking ingredient recipe.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class CookingIngredientRecipe : Recipe
    {
        /// <summary>Initializes a new instance of the <see cref="CookingIngredientRecipe" /> class.</summary>
        public CookingIngredientRecipe()
            : base(RecipeType.IngredientCooking)
        {
        }
    }
}