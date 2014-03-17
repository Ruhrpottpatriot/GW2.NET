// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents the location of an event on the map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents.Details.Locations
{
    using System;

    using GW2DotNET.V1.Core.Common;
    using GW2DotNET.V1.Core.Common.Converters;
    using GW2DotNET.V1.Core.Common.Drawing;

    using Newtonsoft.Json;

    /// <summary>Represents the location of an event on the map.</summary>
    [JsonConverter(typeof(LocationConverter))]
    public abstract class Location : JsonObject, IEquatable<Location>
    {
        /// <summary>Initializes a new instance of the <see cref="Location"/> class.</summary>
        /// <param name="locationType">The location's type.</param>
        protected Location(LocationType locationType)
        {
            this.Type = locationType;
        }

        /// <summary>Gets or sets the center coordinates.</summary>
        [JsonProperty("center", Order = 1)]
        [JsonConverter(typeof(JsonPoint3DConverter))]
        public Point3D Center { get; set; }

        /// <summary>Gets or sets the dynamic event details.</summary>
        public DynamicEventDetails DynamicEventDetails { get; set; }

        /// <summary>Gets the shape of the location.</summary>
        [JsonProperty("type", Order = 0)]
        public LocationType Type { get; private set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Location left, Location right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Location left, Location right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Location other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Center.Equals(other.Center);
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

            return this.Equals((Location)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.Center.GetHashCode();
        }
    }
}