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
    public partial struct Guild
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
        public string Name { get; private set; }

        /// <summary>
        /// Gets the guild tag.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; private set; }

        /// <summary>
        /// Gets the guild emblem.
        /// </summary>
        [JsonProperty("emblem")]
        public GuildEmblem Emblem { get; private set; }
    }
}
