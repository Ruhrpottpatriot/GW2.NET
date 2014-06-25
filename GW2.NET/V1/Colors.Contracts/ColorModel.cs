// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModel.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a color's component information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors.Contracts
{
    using System.Drawing;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a color's component information.</summary>
    public class ColorModel : JsonObject
    {
        /// <summary>Gets or sets the brightness.</summary>
        [DataMember(Name = "brightness")]
        public int Brightness { get; set; }

        /// <summary>Gets or sets the contrast.</summary>
        [DataMember(Name = "contrast")]
        public double Contrast { get; set; }

        /// <summary>Gets or sets the hue in the HSL color space.</summary>
        [DataMember(Name = "hue")]
        public int Hue { get; set; }

        /// <summary>Gets or sets the lightness in the HSL color space.</summary>
        [DataMember(Name = "lightness")]
        public double Lightness { get; set; }

        /// <summary>Gets or sets the color.</summary>
        [DataMember(Name = "rgb")]
        public Color Rgb { get; set; }

        /// <summary>Gets or sets the saturation in the HSL color space.</summary>
        [DataMember(Name = "saturation")]
        public double Saturation { get; set; }
    }
}