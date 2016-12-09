// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Objective.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of a World versus World map's objectives.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.WorldVersusWorld
{
    using System;
    using System.Globalization;

    using GW2NET.Guilds;

    /// <summary>Represents one of a World versus World map's objectives.</summary>
    public class MatchObjective : IEquatable<MatchObjective>
    {
        /// <summary>Gets or sets the type of the objective.</summary>
        public virtual string Type { get; set; }

        /// <summary>Gets or sets the locale.</summary>
        public virtual CultureInfo Culture { get; set; }

        /// <summary>Gets or sets the name of the objective. This is a navigation property. Use the value of <see cref="ObjectiveId"/> to obtain a reference.</summary>
        public virtual ObjectiveName Name { get; set; }

        /// <summary>Gets or sets the objective identifier.</summary>
        public virtual string ObjectiveId { get; set; }

        /// <summary>Gets or sets the current owner.</summary>
        public virtual TeamColor Owner { get; set; }

        /// <summary>Gets or sets the guild currently claiming the objective. This is a navigation property. Use the value of <see cref="OwnerGuildId"/> to obtain a reference.</summary>
        public virtual Guild OwnerGuild { get; set; }

        /// <summary>Gets or sets the identifier of the guild currently claiming the objective.</summary>
        public virtual Guid? OwnerGuildId { get; set; }

        /// <summary>Gets of sets timestamp when objective was claimed by a guild.</summary>
        public virtual string ClaimedAt { get; set; }

        /// <summary>Gets of sets timestamp of last flip of the objective.</summary>
        public virtual string LastFlipped { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(MatchObjective left, MatchObjective right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(MatchObjective left, MatchObjective right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public virtual bool Equals(MatchObjective other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ObjectiveId == other.ObjectiveId;
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

            return this.Equals((MatchObjective)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.ObjectiveId.GetHashCode();
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var name = this.Name;
            if (name != null)
            {
                return name.ToString();
            }

            return this.ObjectiveId;
        }
    }
}