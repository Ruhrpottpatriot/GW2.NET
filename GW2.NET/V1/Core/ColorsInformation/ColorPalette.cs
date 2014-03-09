// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPalette.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a named color and its color component information for cloth, leather and metal materials.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.ColorsInformation
{
    using System;
    using System.Drawing;

    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a named color and its color component information for cloth, leather and metal materials.
    /// </summary>
    public class ColorPalette : JsonObject, IEquatable<ColorPalette>, IComparable<ColorPalette>
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the base RGB values.
        /// </summary>
        [JsonProperty("base_rgb", Order = 2)]
        [JsonConverter(typeof(JsonColorConverter))]
        public Color BaseRgb { get; set; }

        /// <summary>
        ///     Gets or sets detailed information on the appearance when applied on cloth armor.
        /// </summary>
        [JsonProperty("cloth", Order = 3)]
        public ColorModel Cloth { get; set; }

        /// <summary>
        ///     Gets or sets the color's ID.
        /// </summary>
        [JsonProperty("color_id", Order = 0)]
        public int ColorId { get; set; }

        /// <summary>
        ///     Gets or sets detailed information on the appearance when applied on leather armor.
        /// </summary>
        [JsonProperty("leather", Order = 4)]
        public ColorModel Leather { get; set; }

        /// <summary>
        ///     Gets or sets detailed information on the appearance when applied on metal armor.
        /// </summary>
        [JsonProperty("metal", Order = 5)]
        public ColorModel Metal { get; set; }

        /// <summary>
        ///     Gets or sets the name of the dye.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Indicates whether an object is equal to another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(ColorPalette left, ColorPalette right)
        {
            return object.Equals(left, right);
        }

        /// <summary>
        ///     Indicates whether an object differs from another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter;
        ///     otherwise, false.
        /// </returns>
        public static bool operator !=(ColorPalette left, ColorPalette right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following
        ///     meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This
        ///     object is equal to <paramref name="other"/>. Greater than zero This object is greater than<paramref name="other"/>.</returns>
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

            return this.BaseRgb.Equals(other.BaseRgb) && object.Equals(this.Cloth, other.Cloth) && this.ColorId == other.ColorId
                   && object.Equals(this.Leather, other.Leather) && object.Equals(this.Metal, other.Metal) && string.Equals(this.Name, other.Name);
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>;
        ///     otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object.</param>
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

        /// <summary>
        ///     Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="T:System.Object" />.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.BaseRgb.GetHashCode();
                hashCode = (hashCode * 397) ^ (this.Cloth != null ? this.Cloth.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ this.ColorId;
                hashCode = (hashCode * 397) ^ (this.Leather != null ? this.Leather.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Metal != null ? this.Metal.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}