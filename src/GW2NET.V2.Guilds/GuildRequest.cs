// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildRequest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a request for information regarding a specific guild.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;

    /// <summary>Represents a request for information regarding a specific guild.</summary>
    public sealed class GuildRequest : IRequest
    {
        /// <summary>Gets or sets the guild identifier.</summary>
        public Guid? GuildId { get; set; }

        /// <summary>Gets or sets the guild name.</summary>
        public string GuildName { get; set; }

        /// <summary>Gets the resource path.</summary>
        public string Resource
        {
            get
            {
                return "v1/guild_details.json";
            }
        }

        /// <summary>Gets the request parameters.</summary>
        /// <returns>A collection of parameters.</returns>
        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            // Get the 'guild_id' parameter
            if (this.GuildId.HasValue)
            {
                yield return new KeyValuePair<string, string>("guild_id", this.GuildId.Value.ToString());
            }

            // Get the 'guild_name' parameter
            if (this.GuildName != null)
            {
                yield return new KeyValuePair<string, string>("guild_name", this.GuildName);
            }
        }
    }
}