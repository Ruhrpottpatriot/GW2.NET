// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guild.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the Guild type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Guilds.Models
{
    /// <summary>
    /// Represents a guild in the game.
    /// </summary>
    public partial struct Guild : IEquatable<Guild>
    {
        /// <summary>
        /// The id of the guild.
        /// </summary>
        private readonly Guid id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Guild"/> struct.
        /// </summary>
        /// <param name="id">
        /// The id of the guild.
        /// </param>
        /// <param name="name">
        /// The name of the guild.
        /// </param>
        /// <param name="tag">
        /// The guild tag.
        /// </param>
        /// <param name="emblem">
        /// The guild emblem.
        /// </param>
        [JsonConstructor]
        public Guild(Guid id, string name, string tag, GuildEmblem emblem)
            : this()
        {
            this.id = id;
            this.Emblem = emblem;
            this.Tag = tag;
            this.Name = name;
        }

        /// <summary>
        /// Gets the guild id.
        /// </summary>
        [JsonProperty("guild_id")]
        public Guid Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the guild name.
        /// </summary>
        [JsonProperty("guild_name")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the guild tag.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the guild emblem.
        /// </summary>
        [JsonProperty("emblem")]
        public GuildEmblem Emblem
        {
            get;
            private set;
        }

        /// <summary>
        /// Checks if two instances of <see cref="Guild"/> are equal.
        /// </summary>
        /// <param name="guildA">
        /// The first emblem.
        /// </param>
        /// <param name="guildB">
        /// The second emblem.
        /// </param>
        /// <returns>
        /// true if both instances are the the same, otherwise false.
        /// </returns>
        public static bool operator ==(Guild guildA, Guild guildB)
        {
            return guildA.Id == guildB.Id;
        }

        /// <summary>
        /// Checks if two instances of <see cref="Guild"/> are not equal.
        /// </summary>
        /// <param name="guildA">
        /// The first emblem.
        /// </param>
        /// <param name="guildB">
        /// The second emblem.
        /// </param>
        /// <returns>
        /// true if both instances are the not the same, otherwise false.
        /// </returns>
        public static bool operator !=(Guild guildA, Guild guildB)
        {
            return guildA.Id == guildB.Id;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Guild other)
        {
            return other == this;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param>
        public override bool Equals(object obj)
        {
            // ReSharper disable PossibleInvalidCastException
            return obj is Guid && (Guild)obj == this;
            // ReSharper restore PossibleInvalidCastException
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}
