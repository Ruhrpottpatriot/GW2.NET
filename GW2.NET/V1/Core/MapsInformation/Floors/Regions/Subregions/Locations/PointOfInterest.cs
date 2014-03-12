// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointOfInterest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a Point of Interest (POI) location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.MapsInformation.Floors.Regions.Subregions.Locations
{
    using System;
    using System.Drawing;

    using GW2DotNET.V1.Core.Converters;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     Represents a Point of Interest (POI) location.
    /// </summary>
    public class PointOfInterest : JsonObject, IEquatable<PointOfInterest>, IComparable<PointOfInterest>
    {
        /// <summary>
        ///     Gets or sets the Point of Interest's coordinates.
        /// </summary>
        [JsonProperty("coord", Order = 4)]
        [JsonConverter(typeof(JsonPointFConverter))]
        public PointF Coordinates { get; set; }

        /// <summary>
        ///     Gets or sets the Point of Interest's floor.
        /// </summary>
        [JsonProperty("floor", Order = 3)]
        public int Floor { get; set; }

        /// <summary>
        ///     Gets or sets the Point of Interest's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the Point of Interest's ID.
        /// </summary>
        [JsonProperty("poi_id", Order = 0)]
        public int PointOfInterestId { get; set; }

        /// <summary>
        ///     Gets or sets the Point of Interest's type.
        /// </summary>
        [JsonProperty("type", Order = 2)]
        [JsonConverter(typeof(StringEnumConverter))]
        public PointOfInterestType Type { get; set; }

        /// <summary>
        ///     Indicates whether an object is equal to another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(PointOfInterest left, PointOfInterest right)
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
        public static bool operator !=(PointOfInterest left, PointOfInterest right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(PointOfInterest other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.PointOfInterestId.CompareTo(other.PointOfInterestId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(PointOfInterest other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.PointOfInterestId == other.PointOfInterestId;
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

            return this.Equals((PointOfInterest)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.PointOfInterestId;
        }
    }
}