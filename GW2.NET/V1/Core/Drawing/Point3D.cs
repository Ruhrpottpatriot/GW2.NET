// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Point3D.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an x-, y-, and z-coordinate point in 3-D space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.Drawing
{
    /// <summary>
    ///     Represents an x-, y-, and z-coordinate point in 3-D space.
    /// </summary>
    /// <remarks>
    ///     This struct exists because it would be silly to add a WPF reference for its Point3D struct.
    /// </remarks>
    public struct Point3D
    {
        /// <summary>Initializes a new instance of the <see cref="Point3D"/> structure using the specified values.</summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="z">The z-coordinate.</param>
        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        ///     Gets or sets the x-coordinate of this Point3D structure.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the y-coordinate of this Point3D structure.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        ///     Gets or sets the z-coordinate of this Point3D structure.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        ///     Gets the text representation of this instance.
        /// </summary>
        /// <returns>Returns a <see cref="System.String" />.</returns>
        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}]", this.X, this.Y, this.Z);
        }
    }
}