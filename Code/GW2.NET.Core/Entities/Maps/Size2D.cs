// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Size2D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the size of a two-dimensional object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Entities.Maps
{
    /// <summary>Represents the size of a two-dimensional object.</summary>
    public struct Size2D
    {
        /// <summary>Initializes a new instance of the <see cref="Size2D"/> struct.</summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Size2D(double width, double height)
            : this()
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>Gets or sets the height.</summary>
        public double Height { get; set; }

        /// <summary>Gets or sets the width.</summary>
        public double Width { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>Returns a <see cref="System.String" />.</returns>
        public override string ToString()
        {
            return string.Format("Width={0} Height={1}", this.Width, this.Height);
        }
    }
}