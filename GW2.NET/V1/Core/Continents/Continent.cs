// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Continent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using JsonSizeConverter = GW2DotNET.V1.Core.Converters.SizeConverter;

namespace GW2DotNET.V1.Core.Continents
{
    /// <summary>
    /// Represents a continent.
    /// </summary>
    public class Continent
    {
        /// <summary>
        /// Gets or sets the name of the continent.
        /// </summary>
        [JsonProperty("name")]
        public string ContinentName { get; set; }

        /// <summary>
        /// Gets or sets the dimensions of the continent.
        /// </summary>
        [JsonProperty("continent_dims")]
        [JsonConverter(typeof(JsonSizeConverter))]
        public Size ContinentDimensions { get; set; }

        /// <summary>
        /// Gets or sets the minimum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("min_zoom")]
        public int MinimumZoom { get; set; }

        /// <summary>
        /// Gets or sets the maximum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("max_zoom")]
        public int MaximumZoom { get; set; }

        /// <summary>
        /// Gets or sets a list of floors available for this continent.
        /// </summary>
        [JsonProperty("floors")]
        public IEnumerable<int> Floors { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
