// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guild.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild and its details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Details.Contracts
{
    using System;
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Contracts;

    /// <summary>Represents a guild and its details.</summary>
    public class Guild : JsonObject, IEquatable<Guild>, IComparable<Guild>
    {
        /// <summary>Infrastructure. Stores an emblem.</summary>
        private Emblem emblem;

        /// <summary>Gets or sets detailed information about the guild's emblem, if any.</summary>
        [DataMember(Name = "emblem", Order = 3)]
        public Emblem Emblem
        {
            get
            {
                return this.emblem;
            }

            set
            {
                this.emblem = value;
                value.Guild = this;
            }
        }

        /// <summary>Gets or sets the guild's ID.</summary>
        [DataMember(Name = "guild_id", Order = 0)]
        public Guid GuildId { get; set; }

        /// <summary>Gets or sets the guild's name.</summary>
        [DataMember(Name = "guild_name", Order = 1)]
        public string Name { get; set; }

        /// <summary>Gets or sets the guild's tag.</summary>
        [DataMember(Name = "tag", Order = 2)]
        public string Tag { get; set; }

        /// <summary>Indicates whether an object is equal to another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator ==(Guild left, Guild right)
        {
            return object.Equals(left, right);
        }

        /// <summary>Indicates whether an object differs from another object of the same type.</summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter; otherwise, false.</returns>
        public static bool operator !=(Guild left, Guild right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than<paramref name="other"/>.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Guild other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.GuildId.CompareTo(other.GuildId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Guild other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.GuildId.Equals(other.GuildId);
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

            return this.Equals((Guild)obj);
        }

        /// <summary>Serves as a hash function for a particular type.</summary>
        /// <returns>A hash code for the current <see cref="T:System.Object" />.</returns>
        public override int GetHashCode()
        {
            return this.GuildId.GetHashCode();
        }
    }
}