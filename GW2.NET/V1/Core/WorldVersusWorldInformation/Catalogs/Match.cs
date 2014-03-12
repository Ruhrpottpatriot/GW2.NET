// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Match.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World match.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Catalogs
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a World versus World match.
    /// </summary>
    public class Match : JsonObject, IEquatable<Match>, IComparable<Match>
    {
        /// <summary>
        ///     Gets or sets the blue world's ID.
        /// </summary>
        [JsonProperty("blue_world_id", Order = 2)]
        public int BlueWorldId { get; set; }

        /// <summary>
        ///     Gets or sets the timestamp (UTC) of when the match ends.
        /// </summary>
        [JsonProperty("end_time", Order = 5)]
        public DateTimeOffset EndTime { get; set; }

        /// <summary>
        ///     Gets or sets the green world's ID.
        /// </summary>
        [JsonProperty("green_world_id", Order = 3)]
        public int GreenWorldId { get; set; }

        /// <summary>
        ///     Gets or sets the match's ID.
        /// </summary>
        [JsonProperty("wvw_match_id", Order = 0)]
        public string MatchId { get; set; }

        /// <summary>
        ///     Gets or sets the red world's ID.
        /// </summary>
        [JsonProperty("red_world_id", Order = 1)]
        public int RedWorldId { get; set; }

        /// <summary>
        ///     Gets or sets the timestamp (UTC) of when the match started.
        /// </summary>
        [JsonProperty("start_time", Order = 4)]
        public DateTimeOffset StartTime { get; set; }

        /// <summary>
        ///     Indicates whether an object is equal to another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(Match left, Match right)
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
        public static bool operator !=(Match left, Match right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Match other)
        {
            if (other == null)
            {
                return 1;
            }

            return string.Compare(this.MatchId, other.MatchId, StringComparison.Ordinal);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Match other)
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

            return this.Equals((Match)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.StartTime.GetHashCode() * 397) ^ (this.MatchId != null ? this.MatchId.GetHashCode() : 0);
            }
        }
    }
}