// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;

namespace GW2DotNET.V1.Core.GuildDetails
{
    /// <summary>
    /// Represents a request for information regarding a specific guild.
    /// </summary>
    /// <remarks>
    /// See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details"/> for more information.
    /// </remarks>
    public class GuildDetailsRequest : ApiRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuildDetailsRequest"/> class using the specified guild ID.
        /// </summary>
        /// <param name="guildId">The guild id to query for.</param>
        public GuildDetailsRequest(Guid guildId)
            : base(new Uri(Resources.GuildDetails + "?guild_id={guild_id}", UriKind.Relative))
        {
            if (guildId == Guid.Empty)
            {
                throw new ArgumentNullException("guildId");
            }

            this.AddUrlSegment("guild_id", guildId.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuildDetailsRequest"/> class using the specified guild name.
        /// </summary>
        /// <param name="guildName">The guild name to query for.</param>
        public GuildDetailsRequest(string guildName)
            : base(new Uri(Resources.GuildDetails + "?guild_name={guild_name}", UriKind.Relative))
        {
            if (string.IsNullOrWhiteSpace(guildName))
            {
                throw new ArgumentNullException("guildName");
            }

            this.AddUrlSegment("guild_name", guildName);
        }

        /// <summary>
        /// Sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="GuildDetailsResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="GuildDetailsResponse"/>.</returns>
        public IApiResponse<GuildDetailsResponse> GetResponse(IApiClient handler)
        {
            return base.GetResponse<GuildDetailsResponse>(handler);
        }

        /// <summary>
        /// Asynchronously sends this request to the specified <see cref="ApiClient"/> and retrieves a response whose content is of type <see cref="GuildDetailsResponse"/>.
        /// </summary>
        /// <param name="handler">The <see cref="ApiClient"/> that sends the request over a network and returns an instance of type <see cref="ApiResponse{TContent}"/>.</param>
        /// <returns>Returns an instance of type <see cref="GuildDetailsResponse"/>.</returns>
        public Task<IApiResponse<GuildDetailsResponse>> GetResponseAsync(IApiClient handler)
        {
            return base.GetResponseAsync<GuildDetailsResponse>(handler);
        }
    }
}