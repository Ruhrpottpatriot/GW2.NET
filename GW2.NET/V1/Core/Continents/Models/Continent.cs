// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Continent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using JsonSizeConverter = GW2DotNET.V1.Core.Converters.SizeConverter;

namespace GW2DotNET.V1.Core.Continents.Models
{
    /// <summary>
    /// Represents a continent.
    /// </summary>
    public class Continent
    {
        /// <summary>
        /// Gets or sets the dimensions of the continent.
        /// </summary>
        [JsonProperty("continent_dims", Order = 1)]
        [JsonConverter(typeof(JsonSizeConverter))]
        public Size ContinentDimensions { get; set; }

        /// <summary>
        /// Gets or sets the name of the continent.
        /// </summary>
        [JsonProperty("name", Order = 0)]
        public string ContinentName { get; set; }

        /// <summary>
        /// Gets or sets a list of floors available for this continent.
        /// </summary>
        [JsonProperty("floors", Order = 4)]
        public IEnumerable<int> Floors { get; set; }

        /// <summary>
        /// Gets or sets the maximum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("max_zoom", Order = 3)]
        public int MaximumZoom { get; set; }

        /// <summary>
        /// Gets or sets the minimum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("min_zoom", Order = 2)]
        public int MinimumZoom { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}