// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The guild details service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Guilds;

    /// <summary>The guild details service contract.</summary>
    [ContractClassFor(typeof(IGuildDetailsService))]
    internal abstract class GuildDetailsServiceContract : IGuildDetailsService
    {
        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsById(Guid guildId)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsByName(string guildName)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Guild>>() != null);
            throw new NotImplementedException();
        }
    }
}