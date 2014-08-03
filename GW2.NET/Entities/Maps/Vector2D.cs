// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vector2D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a vector in two-dimensional space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Maps
{
    /// <summary>Represents a vector in two-dimensional space.</summary>
    public struct Vector2D
    {
        /// <summary>Initializes a new instance of the <see cref="Vector2D"/> struct.</summary>
        /// <param name="x">The X-component value.</param>
        /// <param name="y">The Y-component value.</param>
        public Vector2D(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>Gets or sets the X-component value.</summary>
        public double X { get; set; }

        /// <summary>Gets or sets the Y-component value.</summary>
        public double Y { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>Returns a <see cref="System.String" />.</returns>
        public override string ToString()
        {
            return string.Format("X={0} Y={1}", this.X, this.Y);
        }
    }
}