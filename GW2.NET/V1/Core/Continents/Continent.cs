// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Continent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a continent.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.Continents
{
    using System;
    using System.Drawing;

    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a continent.
    /// </summary>
    public class Continent : JsonObject, IEquatable<Continent>, IComparable<Continent>
    {
        /// <summary>
        ///     Gets or sets the dimensions of the continent.
        /// </summary>
        [JsonProperty("continent_dims", Order = 2)]
        [JsonConverter(typeof(JsonSizeConverter))]
        public Size ContinentDimensions { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the continent.
        /// </summary>
        [JsonProperty("continent_id", Order = 0)]
        public int ContinentId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the continent.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string ContinentName { get; set; }

        /// <summary>
        ///     Gets or sets a collection of floors available for this continent.
        /// </summary>
        [JsonProperty("floors", Order = 5)]
        public ContinentFloorCollection Floors { get; set; }

        /// <summary>
        ///     Gets or sets the maximum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("max_zoom", Order = 4)]
        public int MaximumZoom { get; set; }

        /// <summary>
        ///     Gets or sets the minimum zoom level for use with the map tile service.
        /// </summary>
        [JsonProperty("min_zoom", Order = 3)]
        public int MinimumZoom { get; set; }

        /// <summary>
        ///     Indicates whether an object is equal to another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(Continent left, Continent right)
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
        public static bool operator !=(Continent left, Continent right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Continent other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.ContinentId.CompareTo(other.ContinentId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Continent other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ContinentId == other.ContinentId;
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

            return this.Equals((Continent)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ContinentId;
        }
    }
}