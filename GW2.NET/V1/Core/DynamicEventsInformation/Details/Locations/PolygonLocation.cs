// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolygonLocation.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a polygonal location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.DynamicEventsInformation.Details.Locations
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a polygonal location of an event on the map.
    /// </summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class PolygonLocation : Location
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonLocation" /> class.
        /// </summary>
        public PolygonLocation()
            : base(LocationType.Polygon)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the series of points in the polygon.
        /// </summary>
        [JsonProperty("points", Order = 5)]
        public PointCollection PointCollection { get; set; }

        /// <summary>
        ///     Gets or sets the location's range on the z-axis.
        /// </summary>
        [JsonProperty("z_range", Order = 4)]
        [JsonConverter(typeof(JsonPointConverter))]
        public Point ZRange { get; set; }

        #endregion
    }
}