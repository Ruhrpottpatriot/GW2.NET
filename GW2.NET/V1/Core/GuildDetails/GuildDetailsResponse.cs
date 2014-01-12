// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.GuildDetails
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="GuildDetailsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details"/> for more information.
    /// </remarks>
    public partial class GuildDetailsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuildDetailsResponse"/> class.
        /// </summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="guildTag">The guild's tag.</param>
        /// <param name="guildEmblem">The guild's emblem.</param>
        [JsonConstructor]
        public GuildDetailsResponse(Guid guildId, string guildName, string guildTag, Emblem guildEmblem)
        {
            this.GuildId = guildId;
            this.GuildName = guildName;
            this.GuildTag = guildTag;
            this.GuildEmblem = guildEmblem;
        }

        /// <summary>
        /// Gets the guild's ID.
        /// </summary>
        [JsonProperty("guild_id")]
        public Guid GuildId { get; private set; }

        /// <summary>
        /// Gets the guild's name.
        /// </summary>
        [JsonProperty("guild_name")]
        public string GuildName { get; private set; }

        /// <summary>
        /// Gets the guild's tag.
        /// </summary>
        [JsonProperty("tag")]
        public string GuildTag { get; private set; }

        /// <summary>
        /// Gets detailed information about the guild's emblem, if any. 
        /// </summary>
        [JsonProperty("emblem")]
        public Emblem GuildEmblem { get; private set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
