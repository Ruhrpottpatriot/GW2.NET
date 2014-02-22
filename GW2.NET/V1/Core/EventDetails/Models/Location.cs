// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.Drawing;
using GW2DotNET.V1.Core.EventDetails.Converters;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.EventDetails.Models
{
    /// <summary>
    /// Represents the location of an event on the map.
    /// </summary>
    [JsonConverter(typeof(LocationConverter))]
    public abstract class Location : JsonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        protected Location()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class using the specified values.
        /// </summary>
        /// <param name="type">The location's shape.</param>
        protected Location(LocationShape type)
        {
            this.LocationType = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class using the specified values.
        /// </summary>
        /// <param name="type">The location's shape.</param>
        /// <param name="center">The location's center.</param>
        protected Location(LocationShape type, Point3D center)
        {
            this.LocationType = type;
            this.Center = center;
        }

        /// <summary>
        /// Gets or sets the center coordinates.
        /// </summary>
        [JsonProperty("center", Order = 1)]
        [JsonConverter(typeof(Point3DConverter))]
        public Point3D Center { get; set; }

        /// <summary>
        /// Gets or sets the shape of the location.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public LocationShape LocationType { get; set; }
    }
}