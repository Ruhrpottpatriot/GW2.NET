// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Represents detailed information about a consumable item.
    /// </summary>
    /// //TODO : converter for consumable sub-types.
    public class ConsumableDetails : Details
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableDetails"/> class.
        /// </summary>
        public ConsumableDetails()
        {
        }

        /// <summary>
        /// Gets or sets the consumable's type.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public ConsumableType Type { get; set; }

        #region Food sub-type

        /// <summary>
        /// Gets or sets the food's description.
        /// </summary>
        [JsonProperty("description", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the food's duration in milliseconds.
        /// </summary>
        [JsonProperty("duration_ms", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public string Duration { get; set; }
        #endregion

        #region Unlock sub-type

        /// <summary>
        /// Gets or sets the color's ID.
        /// </summary>
        [JsonProperty("color_id", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public string ColorId { get; set; }

        /// <summary>
        /// Gets or sets the recipe's ID.
        /// </summary>
        [JsonProperty("recipe_id", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public string RecipeId { get; set; }

        /// <summary>
        /// Gets or sets the consumable's unlock type.
        /// </summary>
        [JsonProperty("unlock_type", Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public UnlockType UnlockType { get; set; }

        #endregion
    }
}