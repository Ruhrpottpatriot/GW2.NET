// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations
{
    using GW2DotNET.V1.Core.Converters;
    using GW2DotNET.V1.Core.Drawing;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents the location of an event on the map.
    /// </summary>
    [JsonConverter(typeof(LocationConverter))]
    public abstract class Location : JsonObject
    {
        /// <summary>Initializes a new instance of the <see cref="Location"/> class.</summary>
        /// <param name="locationType">The location's type.</param>
        protected Location(LocationType locationType)
        {
            this.Type = locationType;
        }

        /// <summary>
        ///     Gets or sets the center coordinates.
        /// </summary>
        [JsonProperty("center", Order = 1)]
        [JsonConverter(typeof(JsonPoint3DConverter))]
        public Point3D Center { get; set; }

        /// <summary>
        ///     Gets the shape of the location.
        /// </summary>
        [JsonProperty("type", Order = 0)]
        public LocationType Type { get; private set; }
    }
}