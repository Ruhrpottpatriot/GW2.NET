// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Floor.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map floor, used to populate a world map. All coordinates are map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Floors.Contracts
{
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Common.Types;
    using GW2DotNET.V1.Maps.Floors.Contracts.Regions;

    using Newtonsoft.Json;

    /// <summary>Represents a map floor, used to populate a world map. All coordinates are map coordinates.</summary>
    /// <remarks>The returned data only contains static content. Dynamic content, such as vendors, is not currently available.</remarks>
    public class Floor : JsonObject
    {
        /// <summary>Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.</summary>
        [DataMember(Name = "clamped_view", Order = 3)]
        [JsonConverter(typeof(JsonRectangleConverter))]
        public Rectangle? ClampedView { get; set; }

        /// <summary>Gets or sets the floor's continent.</summary>
        /// <remarks>See
        /// <a href="https://forum-en.guildwars2.com/forum/community/api/API-Suggestion-Reflect-source-in-map-floor/3795765">forums</a>
        /// .</remarks>
        [DataMember(Name = "continent_id", Order = 0)]
        public int ContinentId { get; set; }

        /// <summary>Gets or sets the floor's number.</summary>
        /// <remarks>See
        /// <a href="https://forum-en.guildwars2.com/forum/community/api/API-Suggestion-Reflect-source-in-map-floor/3795765">forums</a>
        /// .</remarks>
        [DataMember(Name = "floor", Order = 1)]
        public int FloorNumber { get; set; }

        /// <summary>Gets or sets the language info.</summary>
        [DataMember(Name = "lang", Order = 5)]
        public CultureInfo Language { get; set; }

        /// <summary>Gets or sets the collection of regions.</summary>
        [DataMember(Name = "regions", Order = 4)]
        public RegionCollection Regions { get; set; }

        /// <summary>Gets or sets the texture's dimensions.</summary>
        [DataMember(Name = "texture_dims", Order = 2)]
        [JsonConverter(typeof(JsonSizeConverter))]
        public Size TextureDimensions { get; set; }
    }
}