// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rectangle.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a rectangle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Drawing
{
    /// <summary>Represents a rectangle.</summary>
    public struct Rectangle
    {
        /// <summary>Initializes a new instance of the <see cref="Rectangle"/> struct.</summary>
        /// <param name="upperLeft">The coordinates of the upper-left corner.</param>
        /// <param name="lowerRight">The coordinates of the lower-right corner.</param>
        public Rectangle(Vector2D upperLeft, Vector2D lowerRight)
            : this()
        {
            this.X = upperLeft.X;
            this.Y = upperLeft.Y;
            this.Width = lowerRight.X - upperLeft.X;
            this.Height = lowerRight.Y - upperLeft.Y;
        }

        /// <summary>Gets or sets the height.</summary>
        public double Height { get; set; }

        /// <summary>Gets or sets the width.</summary>
        public double Width { get; set; }

        /// <summary>Gets or sets the X-coordinate.</summary>
        public double X { get; set; }

        /// <summary>Gets or sets the Y-coordinate.</summary>
        public double Y { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>Returns a <see cref="string" />.</returns>
        public override string ToString()
        {
            return string.Format("X={0} Y={1} Width={2} Height={3}", this.X, this.Y, this.Width, this.Height);
        }
    }
}