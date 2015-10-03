// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Color.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an RGB color.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Colors
{
    /// <summary>Represents an RGB color.</summary>
    public struct Color
    {
        /// <summary>Initializes a new instance of the <see cref="Color"/> struct.</summary>
        /// <param name="r">The red component value.</param>
        /// <param name="g">The green component value.</param>
        /// <param name="b">The blue component value.</param>
        public Color(int r, int g, int b)
            : this()
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>Gets or sets the blue component value.</summary>
        public int B { get; set; }

        /// <summary>Gets or sets the green component value.</summary>
        public int G { get; set; }

        /// <summary>Gets or sets the red component value.</summary>
        public int R { get; set; }
    }
}