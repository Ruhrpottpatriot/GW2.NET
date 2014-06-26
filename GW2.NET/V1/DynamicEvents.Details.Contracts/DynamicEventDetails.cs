// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventDetails.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its localized details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents.Details.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.DynamicEvents.Details.Contracts.Locations;

    /// <summary>Represents a dynamic event and its localized details.</summary>
    public class DynamicEventDetails : ServiceContract, IEquatable<DynamicEventDetails>
    {
        /// <summary>Gets or sets the event identifier.</summary>
        [DataMember(Name = "event_id")]
        public Guid EventId { get; set; }

        /// <summary>Gets or sets additional flags.</summary>
        [DataMember(Name = "flags")]
        public DynamicEventFlags Flags { get; set; }

        /// <summary>Gets or sets the language.</summary>
        [DataMember(Name = "lang")]
        public string Language { get; set; }

        /// <summary>Gets or sets the event level.</summary>
        [DataMember(Name = "level")]
        public int Level { get; set; }

        /// <summary>Gets or sets the location of the event.</summary>
        [DataMember(Name = "location")]
        public Location Location { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        [DataMember(Name = "map_id")]
        public int MapId { get; set; }

        /// <summary>Gets or sets the name of the event.</summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(DynamicEventDetails left, DynamicEventDetails right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(DynamicEventDetails left, DynamicEventDetails right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(DynamicEventDetails other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.EventId.Equals(other.EventId);
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current<see cref="T:System.Object"/>.</summary>
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

            return this.Equals((DynamicEventDetails)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.EventId.GetHashCode();
        }
    }
}