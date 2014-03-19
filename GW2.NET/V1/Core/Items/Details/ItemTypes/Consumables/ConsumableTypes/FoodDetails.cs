// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodDetails.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an edible item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Items.Details.ItemTypes.Consumables.ConsumableTypes
{
    using System;

    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about an edible item.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class FoodDetails : ConsumableDetails
    {
        /// <summary>Initializes a new instance of the <see cref="FoodDetails" /> class.</summary>
        public FoodDetails()
            : base(ConsumableType.Food)
        {
        }

        /// <summary>Gets or sets the food's effect description.</summary>
        [JsonProperty("description", Order = 101, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>Gets or sets the food's effect duration.</summary>
        [JsonProperty("duration_ms", Order = 100, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(JsonTimespanConverter))]
        public TimeSpan? Duration { get; set; }
    }
}