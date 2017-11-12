// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vector3D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a vector in three-dimensional space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Drawing
{
    /// <summary>Represents a vector in three-dimensional space.</summary>
    public struct Vector3D
    {
        /// <summary>Initializes a new instance of the <see cref="Vector3D"/> struct.</summary>
        /// <param name="x">The X-component value.</param>
        /// <param name="y">The Y-component value.</param>
        /// <param name="z">The Z-component value.</param>
        public Vector3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>Gets or sets the X-coordinate.</summary>
        public double X { get; set; }

        /// <summary>Gets or sets the Y-coordinate.</summary>
        public double Y { get; set; }

        /// <summary>Gets or sets the Z-coordinate.</summary>
        public double Z { get; set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>Returns a <see cref="System.String" />.</returns>
        public override string ToString()
        {
            return string.Format("X={0} Y={1} Z={2}", this.X, this.Y, this.Z);
        }
    }
}
