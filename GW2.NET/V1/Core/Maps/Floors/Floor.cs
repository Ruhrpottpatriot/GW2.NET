// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Floor.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map floor, used to populate a world map. All coordinates are map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Maps.Floors
{
    using System.Drawing;

    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Common.Converters;
    using GW2DotNET.V1.Core.Maps.Floors.Regions;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a map floor, used to populate a world map. All coordinates are map coordinates.
    /// </summary>
    /// <remarks>
    ///     The returned data only contains static content. Dynamic content, such as vendors, is not currently available.
    /// </remarks>
    public class Floor : JsonObject
    {
        /// <summary>
        ///     Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available
        ///     on the tile server.
        /// </summary>
        [JsonProperty("clamped_view", Order = 1)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle? ClampedView { get; set; }

        /// <summary>
        ///     Gets or sets the collection of regions.
        /// </summary>
        [JsonProperty("regions", Order = 2)]
        public RegionCollection Regions { get; set; }

        /// <summary>
        ///     Gets or sets the texture's dimensions.
        /// </summary>
        [JsonProperty("texture_dims", Order = 0)]
        [JsonConverter(typeof(JsonSizeConverter))]
        public Size TextureDimensions { get; set; }
    }
}