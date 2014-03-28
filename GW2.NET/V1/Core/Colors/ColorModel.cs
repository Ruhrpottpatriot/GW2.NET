// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModel.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a color's component information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Colors
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a color's component information.</summary>
    public class ColorModel : JsonObject, IEquatable<ColorModel>
    {
        /// <summary>Gets or sets the brightness.</summary>
        [DataMember(Name = "brightness", Order = 0)]
        public int Brightness { get; set; }

        /// <summary>Gets or sets the color palette.</summary>
        public ColorPalette ColorPalette { get; set; }

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
        [JsonConverter(typeof(JsonColorConverter))]
        public Color Rgb { get; set; }

        /// <summary>Gets or sets the saturation in the HSL color space.</summary>
        [DataMember(Name = "saturation", Order = 3)]
        public double Saturation { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(ColorModel left, ColorModel right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(ColorModel left, ColorModel right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ColorModel other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Brightness == other.Brightness && this.Contrast.Equals(other.Contrast) && this.Hue == other.Hue
                   && this.Lightness.Equals(other.Lightness) && this.Rgb.Equals(other.Rgb) && this.Saturation.Equals(other.Saturation);
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((ColorModel)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.Brightness;
                hashCode = (hashCode * 397) ^ this.Contrast.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Hue;
                hashCode = (hashCode * 397) ^ this.Lightness.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Rgb.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Saturation.GetHashCode();
                return hashCode;
            }
        }
    }
}