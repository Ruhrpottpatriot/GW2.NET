// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Matchup.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World matchup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Worlds.Contracts;

    using Newtonsoft.Json;

    /// <summary>Represents a World versus World matchup.</summary>
    public class Matchup : ServiceContract, IEquatable<Matchup>
    {
        /// <summary>Gets or sets the blue world.</summary>
        [DataMember(Name = "blue_world_id")]
        [JsonConverter(typeof(UnknownWorldConverter))]
        public World BlueWorld { get; set; }

        /// <summary>Gets or sets the timestamp (UTC) of when the match ends.</summary>
        [DataMember(Name = "end_time")]
        public DateTimeOffset EndTime { get; set; }

        /// <summary>Gets or sets the green world.</summary>
        [DataMember(Name = "green_world_id")]
        [JsonConverter(typeof(UnknownWorldConverter))]
        public World GreenWorld { get; set; }

        /// <summary>Gets or sets the match identifier.</summary>
        [DataMember(Name = "wvw_match_id")]
        public string MatchId { get; set; }

        /// <summary>Gets or sets the red world.</summary>
        [DataMember(Name = "red_world_id")]
        [JsonConverter(typeof(UnknownWorldConverter))]
        public World RedWorld { get; set; }

        /// <summary>Gets or sets the timestamp (UTC) of when the match started.</summary>
        [DataMember(Name = "start_time")]
        public DateTimeOffset StartTime { get; set; }

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
        public bool Equals(Matchup other)
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
            return this.MatchId;
        }
    }
}