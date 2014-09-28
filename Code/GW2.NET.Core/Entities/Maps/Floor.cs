// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Floor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a map floor, used to populate a world map. All coordinates are map coordinates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Maps
{
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>Represents a map floor, used to populate a world map. All coordinates are map coordinates.</summary>
    /// <remarks>The returned data only contains static content. Dynamic content, such as vendors, is not currently available.</remarks>
    public class Floor
    {
        /// <summary>Gets or sets a rectangle of downloadable textures. Every tile coordinate outside of this rectangle is not available on the tile server.</summary>
        public virtual Rectangle? ClampedView { get; set; }

        /// <summary>Gets or sets the continent. This is a navigation property. Use the value of <see cref="ContinentId"/> to obtain a reference.</summary>
        public virtual Continent Continent { get; set; }

        /// <summary>Gets or sets the continent identifier.</summary>
        public virtual int ContinentId { get; set; }

        /// <summary>Gets or sets the floor identifier.</summary>
        public virtual int FloorId { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public virtual CultureInfo Locale { get; set; }

        /// <summary>Gets or sets the collection of regions.</summary>
        public virtual IDictionary<int, Region> Regions { get; set; }

        /// <summary>Gets or sets the texture's dimensions.</summary>
        public virtual Size2D TextureDimensions { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.FloorId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}