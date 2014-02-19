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
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        public Region()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class using the specified values.
        /// </summary>
        /// <param name="name">The region's name.</param>
        /// <param name="labelCoordinates">The coordinates of the region's label.</param>
        /// <param name="maps">The collection of maps.</param>
        public Region(string name, PointF labelCoordinates, IDictionary<int, Map> maps)
        {
            this.Name = name;
            this.LabelCoordinates = labelCoordinates;
            this.Maps = maps;
        }

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