// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloor.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using GW2DotNET.V1.Core.MapsInformation.Floors.Regions;
using Newtonsoft.Json;
using PointConverter = GW2DotNET.V1.Core.Converters.PointConverter;
using RectangleConverter = GW2DotNET.V1.Core.Converters.RectangleConverter;

namespace GW2DotNET.V1.Core.MapsInformation.Floors
{
    /// <summary>
    /// Represents a map floor, used to populate a world map. All coordinates are map coordinates. 
    /// </summary>
    /// <remarks>
    /// The returned data only contains static content. Dynamic content, such as vendors, is not currently available.
    /// </remarks>
    public class MapFloor : JsonObject
    {
        /// <summary>
        /// Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.
        /// </summary>
        [JsonProperty("clamped_view", Order = 1)]
        [JsonConverter(typeof(RectangleConverter))]
        public Rectangle? ClampedView { get; set; }

        /// <summary>
        /// Gets or sets the collection of regions.
        /// </summary>
        [JsonProperty("regions", Order = 2)]
        public MapRegions MapRegions { get; set; }

        /// <summary>
        /// Gets or sets the texture's dimensions.
        /// </summary>
        [JsonProperty("texture_dims", Order = 0)]
        [JsonConverter(typeof(PointConverter))]
        public Point TextureDimensions { get; set; }
    }
}