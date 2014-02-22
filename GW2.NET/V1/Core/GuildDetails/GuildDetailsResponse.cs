// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsResponse.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.GuildDetails.Models;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.GuildDetails
{
    /// <summary>
    /// Represents a response that is the result of a <see cref="GuildDetailsRequest"/>.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details"/> for more information.
    /// </remarks>
    public class GuildDetailsResponse : JsonObject
    {
        /// <summary>
        /// Gets or sets detailed information about the guild's emblem, if any.
        /// </summary>
        [JsonProperty("emblem", Order = 3)]
        public Emblem GuildEmblem { get; set; }

        /// <summary>
        /// Gets or sets the guild's ID.
        /// </summary>
        [JsonProperty("guild_id", Order = 0)]
        [JsonConverter(typeof(GuidConverter))]
        public Guid GuildId { get; set; }

        /// <summary>
        /// Gets or sets the guild's name.
        /// </summary>
        [JsonProperty("guild_name", Order = 1)]
        public string GuildName { get; set; }

        /// <summary>
        /// Gets or sets the guild's tag.
        /// </summary>
        [JsonProperty("tag", Order = 2)]
        public string GuildTag { get; set; }
    }
}