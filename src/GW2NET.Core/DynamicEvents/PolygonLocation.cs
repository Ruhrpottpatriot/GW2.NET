// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolygonLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a polygonal location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.DynamicEvents
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using GW2NET.Common.Drawing;

    /// <summary>Represents a polygonal location.</summary>
    public class PolygonLocation : Location
    {
        private static readonly Vector2D[] EmptyPoints = new Vector2D[0];
        private ICollection<Vector2D> points = EmptyPoints;

        /// <summary>Gets or sets a collection that contains the vertex points of the polygon.</summary>
        public virtual ICollection<Vector2D> Points
        {
            get
            {
                Debug.Assert(this.points != null, "this.points != null");
                return this.points;
            }
            set
            {
                this.points = value ?? EmptyPoints;
            }
        }

        /// <summary>Gets or sets a vector that describes the minimum and maximum Z values.</summary>
        public virtual Vector2D ZRange { get; set; }
    }
}
