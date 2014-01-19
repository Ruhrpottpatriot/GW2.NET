// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using JsonPointConverter = GW2DotNET.V1.Core.Converters.PointConverter;
using JsonRectangleConverter = GW2DotNET.V1.Core.Converters.RectangleConverter;

namespace GW2DotNET.V1.Core.MapFloor
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="MapFloorRequest"/>.
    /// </summary>
    /// <remarks>
    /// The returned data only contains static content. Dynamic content, such as vendors, is not currently available.
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/map_floor"/> for more information.
    /// </remarks>
    public class MapFloorResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloorResponse"/> class.
        /// </summary>
        public MapFloorResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapFloorResponse"/> class using the specified values.
        /// </summary>
        /// <param name="textureDimensions">The texture's dimensions.</param>
        /// <param name="clampedView">The rectangle of downloadable textures.</param>
        /// <param name="regions">The collection of regions.</param>
        public MapFloorResponse(Point textureDimensions, Rectangle? clampedView, IDictionary<int, Region> regions)
        {
            this.TextureDimensions = textureDimensions;
            this.ClampedView = clampedView;
            this.Regions = regions;
        }

        /// <summary>
        /// Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.
        /// </summary>
        [JsonProperty("clamped_view", Order = 1)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle? ClampedView { get; set; }

        /// <summary>
        /// Gets or sets the collection of regions.
        /// </summary>
        [JsonProperty("regions", Order = 2)]
        public IDictionary<int, Region> Regions { get; set; }

        /// <summary>
        /// Gets or sets the texture's dimensions.
        /// </summary>
        [JsonProperty("texture_dims", Order = 0)]
        [JsonConverter(typeof(JsonPointConverter))]
        public Point TextureDimensions { get; set; }

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