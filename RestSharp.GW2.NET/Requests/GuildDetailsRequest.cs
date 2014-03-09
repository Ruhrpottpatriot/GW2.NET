// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsRequest.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Core;
using GW2DotNET.V1.Core.GuildInformation.Details;

namespace RestSharp.GW2DotNET.Requests
{
    /// <summary>
    ///     Represents a request for information regarding a specific guild.
    /// </summary>
    /// <remarks>
    ///     See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details" /> for more information.
    /// </remarks>
    public class GuildDetailsRequest : ServiceRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GuildDetailsRequest" /> class.
        /// </summary>
        /// <param name="guildId">The guild ID to query for.</param>
        public GuildDetailsRequest(Guid guildId)
            : base(Resources.GuildDetails)
        {
            this.AddParameter("guild_id", guildId);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GuildDetailsRequest" /> class.
        /// </summary>
        /// <param name="guildName">The guild name to query for.</param>
        public GuildDetailsRequest(string guildName)
            : base(Resources.GuildDetails)
        {
            this.AddParameter("guild_name", guildName);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public IServiceResponse<Guild> GetResponse(IServiceClient serviceClient)
        {
            return base.GetResponse<Guild>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Guild>> GetResponseAsync(IServiceClient serviceClient)
        {
            return base.GetResponseAsync<Guild>(serviceClient);
        }

        /// <summary>
        ///     Sends the current request and returns a response.
        /// </summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /> that provides cancellation support.</param>
        /// <returns>The response.</returns>
        public Task<IServiceResponse<Guild>> GetResponseAsync(IServiceClient serviceClient, CancellationToken cancellationToken)
        {
            return base.GetResponseAsync<Guild>(serviceClient, cancellationToken);
        }
    }
}