// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Continent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Common;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapsInformation.Continents
{
    using GW2DotNET.V1.Core.Converters;

    /// <summary>
    ///     Represents a continent.
    /// </summary>
    public class Continent : JsonObject
    {
        /// <summary>
        ///     Gets or sets the dimensions of the continent.
        /// </summary>
        [JsonProperty("continent_dims", Order = 2)]
        [JsonConverter(typeof(JsonSizeConverter))]
        public Size ContinentDimensions { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the continent.
        /// </summary>
        [JsonProperty("name", Order = 0)]
        public int ContinentId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the continent.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string ContinentName { get; set; }

        /// <summary>
        ///     Gets or sets a collection of floors available for this continent.
        /// </summary>
        [JsonProperty("floors", Order = 5)]
        public FloorCollection Floors { get; set; }

        /// <summary>
        ///     Gets or sets the maximum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("max_zoom", Order = 4)]
        public int MaximumZoom { get; set; }

        /// <summary>
        ///     Gets or sets the minimum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("min_zoom", Order = 3)]
        public int MinimumZoom { get; set; }
    }
}