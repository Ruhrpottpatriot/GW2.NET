// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Continent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a continent.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Continents.Contracts
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a continent.</summary>
    public class Continent : ServiceContract, IEquatable<Continent>
    {
        /// <summary>Gets or sets the dimensions of the continent.</summary>
        [DataMember(Name = "continent_dims")]
        public Size ContinentDimensions { get; set; }

        /// <summary>Gets or sets the ID of the continent.</summary>
        [DataMember(Name = "continent_id")]
        public int ContinentId { get; set; }

        /// <summary>Gets or sets the name of the continent.</summary>
        [DataMember(Name = "name")]
        public string ContinentName { get; set; }

        /// <summary>Gets or sets a collection of floors available for this continent.</summary>
        [DataMember(Name = "floors")]
        public ContinentFloorCollection Floors { get; set; }

        /// <summary>Gets or sets the maximum zoom level for use with the map tile service.</summary>
        [DataMember(Name = "max_zoom")]
        public int MaximumZoom { get; set; }

        /// <summary>Gets or sets the minimum zoom level for use with the map tile service.</summary>
        [DataMember(Name = "min_zoom")]
        public int MinimumZoom { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Continent left, Continent right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Continent left, Continent right)
        {
            return !object.Equals(left, right);
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

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.ContinentId;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            var name = this.ContinentName;
            if (name != null)
            {
                return name;
            }

            return this.ContinentId.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}