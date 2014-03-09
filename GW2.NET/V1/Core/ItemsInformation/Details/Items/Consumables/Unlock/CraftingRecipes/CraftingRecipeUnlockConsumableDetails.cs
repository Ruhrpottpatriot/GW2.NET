// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeUnlockConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Unlock.CraftingRecipes
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about a crafting recipe.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class CraftingRecipeUnlockConsumableDetails : UnlockConsumableDetails
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="CraftingRecipeUnlockConsumableDetails" /> class.
        /// </summary>
        public CraftingRecipeUnlockConsumableDetails()
            : base(UnlockType.CraftingRecipe)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the crafting recipe's ID.
        /// </summary>
        [JsonProperty("recipe_id", Order = 102)]
        public int RecipeId { get; set; }

        #endregion
    }
}