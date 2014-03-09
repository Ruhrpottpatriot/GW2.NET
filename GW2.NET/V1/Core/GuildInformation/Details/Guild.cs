// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guild.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a guild and its details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Core.GuildInformation.Details
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a guild and its details.
    /// </summary>
    public class Guild : JsonObject
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets detailed information about the guild's emblem, if any.
        /// </summary>
        [JsonProperty("emblem", Order = 3)]
        public Emblem Emblem { get; set; }

        /// <summary>
        ///     Gets or sets the guild's ID.
        /// </summary>
        [JsonProperty("guild_id", Order = 0)]
        public Guid GuildId { get; set; }

        /// <summary>
        ///     Gets or sets the guild's name.
        /// </summary>
        [JsonProperty("guild_name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the guild's tag.
        /// </summary>
        [JsonProperty("tag", Order = 2)]
        public string Tag { get; set; }

        #endregion
    }
}