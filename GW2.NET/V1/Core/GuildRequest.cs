// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Guilds.Models;

namespace GW2DotNET.V1.Core
{
    /// <summary>
    /// Represents a request for information regarding a specific guild.
    /// </summary>
    /// <see cref="http://wiki.guildwars2.com/wiki/API:1/guild_details"/>
    public class GuildRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuildRequest"/> class using the specified guild ID.
        /// </summary>
        /// <param name="guildId">The guild id to query for.</param>
        public GuildRequest(Guid guildId)
            : base(new Uri("guild_details.json?guild_id={guild_id}", UriKind.Relative))
        {
            if (guildId == Guid.Empty)
            {
                throw new ArgumentNullException("guildId");
            }

            this.InnerRequest.AddUrlSegment("guild_id", guildId.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuildRequest"/> class using the specified guild name.
        /// </summary>
        /// <param name="guildName">The guild name to query for.</param>
        public GuildRequest(string guildName)
            : base(new Uri("guild_details.json?guild_name={guild_name}", UriKind.Relative))
        {
            if (string.IsNullOrWhiteSpace(guildName))
            {
                throw new ArgumentNullException("guildName");
            }

            this.InnerRequest.AddUrlSegment("guild_name", guildName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="Guild"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an <see cref="ApiResponse"/>.</param>
        /// <returns>Returns a <see cref="Guild"/>.</returns>
        public IApiResponse<Guild> GetResponse(IApiClient handler)
        {
            return base.GetResponse<Guild>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="Guild"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an <see cref="ApiResponse"/>.</param>
        /// <returns>Returns a <see cref="Guild"/>.</returns>
        public Task<IApiResponse<Guild>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<Guild>(handler);
        }
    }
}