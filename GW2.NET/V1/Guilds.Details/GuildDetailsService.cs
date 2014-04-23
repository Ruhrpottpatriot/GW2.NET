// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the guild details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Details
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Guilds.Details.Contracts;

    /// <summary>Provides the default implementation of the guild details service.</summary>
    public class GuildDetailsService : ServiceBase, IGuildDetailsService
    {
        /// <summary>Initializes a new instance of the <see cref="GuildDetailsService"/> class.</summary>
        public GuildDetailsService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GuildDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public GuildDetailsService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsById(Guid guildId)
        {
            return this.Request<Guild>(new GuildDetailsServiceRequest { GuildId = guildId });
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId)
        {
            return this.GetGuildDetailsByIdAsync(guildId, CancellationToken.None);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, CancellationToken cancellationToken)
        {
            return this.RequestAsync<Guild>(new GuildDetailsServiceRequest { GuildId = guildId }, cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsByName(string guildName)
        {
            return this.Request<Guild>(new GuildDetailsServiceRequest { GuildName = guildName });
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName)
        {
            return this.GetGuildDetailsByNameAsync(guildName, CancellationToken.None);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName, CancellationToken cancellationToken)
        {
            return this.RequestAsync<Guild>(new GuildDetailsServiceRequest { GuildName = guildName }, cancellationToken);
        }
    }
}