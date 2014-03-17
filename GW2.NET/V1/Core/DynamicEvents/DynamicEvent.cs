// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEvent.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its status.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.DynamicEvents
{
    using System;

    using GW2DotNET.V1.Core.Common;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>Represents a dynamic event and its status.</summary>
    public class DynamicEvent : JsonObject, IEquatable<DynamicEvent>, IComparable<DynamicEvent>
    {
        /// <summary>Gets or sets the <see cref="Guid" /> identifying the event.</summary>
        [JsonProperty("event_id", Order = 2)]
        public Guid EventId { get; set; }

        /// <summary>Gets or sets the map on which the event is running.</summary>
        [JsonProperty("map_id", Order = 1)]
        public int MapId { get; set; }

        /// <summary>Gets or sets the current state of the event.</summary>
        [JsonProperty("state", Order = 3)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DynamicEventState State { get; set; }

        /// <summary>Gets or sets the world on which the event is running.</summary>
        [JsonProperty("world_id", Order = 0)]
        public int WorldId { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(DynamicEvent left, DynamicEvent right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(DynamicEvent left, DynamicEvent right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(DynamicEvent other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.EventId.CompareTo(other.EventId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(DynamicEvent other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.WorldId == other.WorldId && this.EventId.Equals(other.EventId);
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

            return this.Equals((DynamicEvent)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.WorldId * 397) ^ this.EventId.GetHashCode();
            }
        }
    }
}