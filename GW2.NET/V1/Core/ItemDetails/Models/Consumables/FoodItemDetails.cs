// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodItemDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.ItemDetails.Models.Consumables
{
    /// <summary>
    /// Represents detailed information about an edible item.
    /// </summary>
    [JsonConverter(typeof(DefaultConverter))]
    public class FoodItemDetails : ConsumableItemDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoodItemDetails"/> class.
        /// </summary>
        public FoodItemDetails()
            : base(ConsumableType.Food)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodItemDetails"/> class using the specified values.
        /// </summary>
        /// <param name="description">The food's effect description.</param>
        /// <param name="duration">The food's effect duration.</param>
        public FoodItemDetails(string description, TimeSpan duration)
        {
            this.Description = description;
            this.Duration = duration;
        }

        /// <summary>
        /// Gets or sets the food's effect description.
        /// </summary>
        [JsonProperty("description", Order = 101, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the food's effect duration.
        /// </summary>
        [JsonProperty("duration_ms", Order = 100, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(MillisecondsTimespanConverter))]
        public TimeSpan? Duration { get; set; }
    }
}