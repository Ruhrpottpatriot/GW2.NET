// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventState.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a dynamic event and its state.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.DynamicEvents
{
    using System;

    using GW2NET.Maps;
    using GW2NET.Worlds;

    /// <summary>Represents a dynamic event and its state.</summary>
    public class DynamicEventState : IEquatable<DynamicEventState>
    {
        /// <summary>Gets or sets the event identifier.</summary>
        public virtual Guid EventId { get; set; }

        /// <summary>Gets or sets the map. This is a navigation property. Use the value of <see cref="MapId"/> to obtain a reference.</summary>
        public virtual Map Map { get; set; }

        /// <summary>Gets or sets the map identifier.</summary>
        public virtual int MapId { get; set; }

        /// <summary>Gets or sets the current state of the event.</summary>
        public virtual EventState State { get; set; }

        /// <summary>Gets or sets the world.  This is a navigation property. Use the value of <see cref="WorldId"/> to obtain a reference.</summary>
        public virtual World World { get; set; }

        /// <summary>Gets or sets the world identifier.</summary>
        public virtual int WorldId { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(DynamicEventState left, DynamicEventState right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(DynamicEventState left, DynamicEventState right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(DynamicEventState other)
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

            return this.Equals((DynamicEventState)obj);
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