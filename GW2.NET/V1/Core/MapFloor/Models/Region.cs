// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Region.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Drawing;
using GW2DotNET.V1.Core.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.MapFloor.Models
{
    /// <summary>
    /// Represents a region on the map.
    /// </summary>
    public class Region : JsonObject
    {
        /// <summary>
        /// Gets or sets the coordinates of the region label.
        /// </summary>
        [JsonProperty("label_coord", Order = 1)]
        [JsonConverter(typeof(PointFConverter))]
        public PointF LabelCoordinates { get; set; }

        /// <summary>
        /// Gets or sets a collection of maps.
        /// </summary>
        [JsonProperty("maps", Order = 2)]
        public IDictionary<int, Map> Maps { get; set; }

        /// <summary>
        /// Gets or sets the region's name.
        /// </summary>
        [JsonProperty("name", Order = 0)]
        public string Name { get; set; }
    }
}