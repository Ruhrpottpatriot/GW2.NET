// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Floor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map floor, used to populate a world map. All coordinates are map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Maps.Contracts
{
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Maps.Contracts.Regions;


    /// <summary>Represents a map floor, used to populate a world map. All coordinates are map coordinates.</summary>
    /// <remarks>The returned data only contains static content. Dynamic content, such as vendors, is not currently available.</remarks>
    public class Floor : ServiceContract
    {
        /// <summary>Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.</summary>
        [DataMember(Name = "clamped_view")]
        public Rectangle? ClampedView { get; set; }

        /// <summary>Gets or sets the floor's continent.</summary>
        /// <remarks>See <a href="https://forum-en.guildwars2.com/forum/community/api/API-Suggestion-Reflect-source-in-map-floor/3795765">forums</a>.</remarks>
        [DataMember(Name = "continent_id")]
        public Continent Continent { get; set; }

        /// <summary>Gets or sets the floor's number.</summary>
        /// <remarks>See <a href="https://forum-en.guildwars2.com/forum/community/api/API-Suggestion-Reflect-source-in-map-floor/3795765">forums</a>.</remarks>
        [DataMember(Name = "floor")]
        public int FloorNumber { get; set; }

        /// <summary>Gets or sets the language.</summary>
        [DataMember(Name = "lang")]
        public string Language { get; set; }

        /// <summary>Gets or sets the collection of regions.</summary>
        [DataMember(Name = "regions")]
        public RegionCollection Regions { get; set; }

        /// <summary>Gets or sets the texture's dimensions.</summary>
        [DataMember(Name = "texture_dims")]
        public Size TextureDimensions { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.FloorNumber.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}