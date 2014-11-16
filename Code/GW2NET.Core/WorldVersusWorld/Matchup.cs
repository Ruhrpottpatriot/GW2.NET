// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Matchup.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World matchup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.WorldVersusWorld
{
    using System;

    using GW2NET.Worlds;

    /// <summary>Represents a World versus World matchup.</summary>
    public class Matchup : IEquatable<Matchup>
    {
        /// <summary>Gets or sets the blue world. This is a navigation property. Use the value of <see cref="BlueWorldId"/> to obtain a reference.</summary>
        public virtual World BlueWorld { get; set; }

        /// <summary>Gets or sets the blue world identifier.</summary>
        public virtual int BlueWorldId { get; set; }

        /// <summary>Gets or sets the timestamp (UTC) of when the match ends.</summary>
        public virtual DateTimeOffset EndTime { get; set; }

        /// <summary>Gets or sets the green world. This is a navigation property. Use the value of <see cref="GreenWorldId"/> to obtain a reference.</summary>
        public virtual World GreenWorld { get; set; }

        /// <summary>Gets or sets the green world identifier.</summary>
        public virtual int GreenWorldId { get; set; }

        /// <summary>Gets or sets the match identifier.</summary>
        public virtual string MatchId { get; set; }

        /// <summary>Gets or sets the red world. This is a navigation property. Use the value of <see cref="RedWorldId"/> to obtain a reference.</summary>
        public virtual World RedWorld { get; set; }

        /// <summary>Gets or sets the red world identifier.</summary>
        public virtual int RedWorldId { get; set; }

        /// <summary>Gets or sets the timestamp (UTC) of when the match started.</summary>
        public virtual DateTimeOffset StartTime { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Matchup left, Matchup right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Matchup left, Matchup right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(Matchup other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.StartTime.Equals(other.StartTime) && string.Equals(this.MatchId, other.MatchId);
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

            return this.Equals((Matchup)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.StartTime.GetHashCode() * 397) ^ (this.MatchId != null ? this.MatchId.GetHashCode() : 0);
            }
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.MatchId ?? base.ToString();
        }
    }
}