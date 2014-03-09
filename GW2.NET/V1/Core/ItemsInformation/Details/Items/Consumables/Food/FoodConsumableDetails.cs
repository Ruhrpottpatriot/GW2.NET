// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodConsumableDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables.Food
{
    /// <summary>
    ///     Represents detailed information about an edible item.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class FoodConsumableDetails : ConsumableDetails
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FoodConsumableDetails" /> class.
        /// </summary>
        public FoodConsumableDetails()
            : base(ConsumableType.Food)
        {
        }

        /// <summary>
        ///     Gets or sets the food's effect description.
        /// </summary>
        [JsonProperty("description", Order = 101, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the food's effect duration.
        /// </summary>
        [JsonProperty("duration_ms", Order = 100, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonTimespanConverter))]
        public TimeSpan? Duration { get; set; }
    }
}