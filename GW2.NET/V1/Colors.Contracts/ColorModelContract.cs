// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModelContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a color's component information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors.Contracts
{
    using System.Runtime.Serialization;

    /// <summary>Represents a color's component information.</summary>
    [DataContract]
    public sealed class ColorModelContract
    {
        /// <summary>Gets or sets the brightness.</summary>
        [DataMember(Name = "brightness", Order = 0)]
        public int Brightness { get; set; }

        /// <summary>Gets or sets the contrast.</summary>
        [DataMember(Name = "contrast", Order = 1)]
        public double Contrast { get; set; }

        /// <summary>Gets or sets the hue in the HSL color space.</summary>
        [DataMember(Name = "hue", Order = 2)]
        public int Hue { get; set; }

        /// <summary>Gets or sets the lightness in the HSL color space.</summary>
        [DataMember(Name = "lightness", Order = 4)]
        public double Lightness { get; set; }

        /// <summary>Gets or sets the color.</summary>
        [DataMember(Name = "rgb", Order = 5)]
        public int[] Rgb { get; set; }

        /// <summary>Gets or sets the saturation in the HSL color space.</summary>
        [DataMember(Name = "saturation", Order = 3)]
        public double Saturation { get; set; }
    }
}