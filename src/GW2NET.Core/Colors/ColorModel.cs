// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModel.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a color's component information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Colors
{
    /// <summary>Represents a color's component information.</summary>
    public class ColorModel
    {
        /// <summary>Gets or sets the brightness.</summary>
        public virtual int Brightness { get; set; }

        /// <summary>Gets or sets the contrast.</summary>
        public virtual double Contrast { get; set; }

        /// <summary>Gets or sets the hue in the HSL color space.</summary>
        public virtual int Hue { get; set; }

        /// <summary>Gets or sets the lightness in the HSL color space.</summary>
        public virtual double Lightness { get; set; }

        /// <summary>Gets or sets the color.</summary>
        public virtual Color Rgb { get; set; }

        /// <summary>Gets or sets the saturation in the HSL color space.</summary>
        public virtual double Saturation { get; set; }
    }
}