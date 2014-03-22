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

    /// <summary>Represents a map floor, used to populate a world map. All coordinates are map coordinates.</summary>
    /// <remarks>The returned data only contains static content. Dynamic content, such as vendors, is not currently available.</remarks>
    public class Floor : JsonObject
    {
        /// <summary>Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.</summary>
        [JsonProperty("clamped_view", Order = 3)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle? ClampedView { get; set; }

        /// <summary>Gets or sets the floor's continent.</summary>
        /// <remarks>See <a href="https://forum-en.guildwars2.com/forum/community/api/API-Suggestion-Reflect-source-in-map-floor/3795765">forums</a>.</remarks>
        [JsonProperty("continent_id", Order = 0)]
        public int ContinentId { get; set; }

        /// <summary>Gets or sets the floor's number.</summary>
        /// <remarks>See <a href="https://forum-en.guildwars2.com/forum/community/api/API-Suggestion-Reflect-source-in-map-floor/3795765">forums</a>.</remarks>
        [JsonProperty("floor", Order = 1)]
        public int FloorNumber { get; set; }

        /// <summary>Gets or sets the collection of regions.</summary>
        [JsonProperty("regions", Order = 4)]
        public RegionCollection Regions { get; set; }

        /// <summary>Gets or sets the texture's dimensions.</summary>
        [JsonProperty("texture_dims", Order = 2)]
        [JsonConverter(typeof(JsonSizeConverter))]
        public Size TextureDimensions { get; set; }
    }
}