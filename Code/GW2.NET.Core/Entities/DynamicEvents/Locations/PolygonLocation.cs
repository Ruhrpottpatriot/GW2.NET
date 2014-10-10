// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolygonLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a polygonal location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.DynamicEvents
{
    using System.Collections.Generic;

    using GW2DotNET.Entities.Maps;

    /// <summary>Represents a polygonal location.</summary>
    public class PolygonLocation : Location
    {
        /// <summary>Gets or sets a collection that contains the vertex points of the polygon.</summary>
        public virtual ICollection<Vector2D> Points { get; set; }

        /// <summary>Gets or sets a vector that describes the minimum and maximum Z values.</summary>
        public virtual Vector2D ZRange { get; set; }
    }
}