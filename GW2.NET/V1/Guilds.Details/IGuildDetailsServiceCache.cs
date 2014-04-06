// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGuildDetailsServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a guild details service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds.Details
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.Guilds.Details.Types;

    /// <summary>Provides the interface for a guild details service cache.</summary>
    public interface IGuildDetailsServiceCache : IGuildDetailsService
    {
        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Guild GetGuildDetailsById(Guid guildId, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild's ID.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Guild GetGuildDetailsByName(string guildName, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsByNameAsync(string guildName, bool allowCache);

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The guild's name.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        Task<Guild> GetGuildDetailsByNameAsync(string guildName, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a guild and its details.</summary>
        /// <param name="guild">The guild.</param>
        void SetGuildDetails(Guild guild);

        /// <summary>Sets a guild and its details.</summary>
        /// <param name="guild">The guild.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetGuildDetails(Guild guild, CacheItemParameters parameters);
    }
}