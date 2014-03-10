// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CylinderLocation.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a cylindrical location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations
{
    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a cylindrical location of an event on the map.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class CylinderLocation : Location
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CylinderLocation" /> class.
        /// </summary>
        public CylinderLocation()
            : base(LocationType.Cylinder)
        {
        }

        /// <summary>
        ///     Gets or sets the location's height.
        /// </summary>
        [JsonProperty("height", Order = 3)]
        public double Height { get; set; }

        /// <summary>
        ///     Gets or sets the location's radius.
        /// </summary>
        [JsonProperty("radius", Order = 4)]
        public double Radius { get; set; }

        /// <summary>
        ///     Gets or sets the location's rotation.
        /// </summary>
        [JsonProperty("rotation", Order = 5)]
        public double Rotation { get; set; }
    }
}