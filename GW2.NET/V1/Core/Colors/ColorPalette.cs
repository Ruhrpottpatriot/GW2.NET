// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPalette.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a named color and its color component information for cloth, leather and metal materials.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Colors
{
    using System;
    using System.Drawing;
    using System.Globalization;

    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents a named color and its color component information for cloth, leather and metal materials.</summary>
    public class ColorPalette : JsonObject, IEquatable<ColorPalette>, IComparable<ColorPalette>
    {
        /// <summary>Infrastructure. Stores a color model.</summary>
        private ColorModel cloth;

        /// <summary>Infrastructure. Stores a color model.</summary>
        private ColorModel leather;

        /// <summary>Infrastructure. Stores a color model.</summary>
        private ColorModel metal;

        /// <summary>Gets or sets the base RGB values.</summary>
        [JsonProperty("base_rgb", Order = 2)]
        [JsonConverter(typeof(JsonColorConverter))]
        public Color BaseRgb { get; set; }

        /// <summary>Gets or sets detailed information on the color's appearance when applied to cloth armor.</summary>
        [JsonProperty("cloth", Order = 3)]
        public ColorModel Cloth
        {
            get
            {
                return this.cloth;
            }

            set
            {
                this.cloth = value;
                value.ColorPalette = this;
            }
        }

        /// <summary>Gets or sets the color's ID.</summary>
        [JsonProperty("color_id", Order = 0)]
        public int ColorId { get; set; }

        /// <summary>Gets or sets detailed information on the color's appearance when applied to leather armor.</summary>
        [JsonProperty("leather", Order = 4)]
        public ColorModel Leather
        {
            get
            {
                return this.leather;
            }

            set
            {
                this.leather = value;
                value.ColorPalette = this;
            }
        }

        /// <summary>Gets or sets detailed information on the color's appearance when applied to metal armor.</summary>
        [JsonProperty("metal", Order = 5)]
        public ColorModel Metal
        {
            get
            {
                return this.metal;
            }

            set
            {
                this.metal = value;
                value.ColorPalette = this;
            }
        }

        /// <summary>Gets or sets the name of the dye.</summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the language info.</summary>
        [JsonProperty("lang", Order = 6)]
        public CultureInfo Language { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(ColorPalette left, ColorPalette right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(ColorPalette left, ColorPalette right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(ColorPalette other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.ColorId.CompareTo(other.ColorId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ColorPalette other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ColorId == other.ColorId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
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

            return this.Equals((ColorPalette)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.ColorId;
        }
    }
}