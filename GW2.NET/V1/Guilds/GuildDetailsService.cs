// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildDetailsService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the guild details service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Guilds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Guilds;
    using GW2DotNET.V1.Guilds.Json;

    /// <summary>Provides the default implementation of the guild details service.</summary>
    public class GuildDetailsService : IGuildDetailsService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="GuildDetailsService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public GuildDetailsService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsById(Guid guildId)
        {
            var request = new GuildDetailsRequest { GuildId = guildId };
            var response = this.serviceClient.Send<GuildContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return MapGuildContracts(response.Content);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId)
        {
            var request = new GuildDetailsRequest { GuildId = guildId };
            var cancellationToken = CancellationToken.None;
            return this.serviceClient.SendAsync<GuildContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapGuildContracts(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildId">The guild identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByIdAsync(Guid guildId, CancellationToken cancellationToken)
        {
            var request = new GuildDetailsRequest { GuildId = guildId };
            return this.serviceClient.SendAsync<GuildContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapGuildContracts(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Guild GetGuildDetailsByName(string guildName)
        {
            var request = new GuildDetailsRequest { GuildName = guildName };
            var response = this.serviceClient.Send<GuildContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return MapGuildContracts(response.Content);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName)
        {
            var request = new GuildDetailsRequest { GuildName = guildName };
            var cancellationToken = CancellationToken.None;
            return this.serviceClient.SendAsync<GuildContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapGuildContracts(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a guild and its details.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A guild and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/guild_details">wiki</a> for more information.</remarks>
        public Task<Guild> GetGuildDetailsByNameAsync(string guildName, CancellationToken cancellationToken)
        {
            var request = new GuildDetailsRequest { GuildName = guildName };
            return this.serviceClient.SendAsync<GuildContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapGuildContracts(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Emblem MapEmblemContract(EmblemContract content)
        {
            if (content == null)
            {
                return null;
            }

            return new Emblem
                       {
                           BackgroundId = content.BackgroundId, 
                           ForegroundId = content.ForegroundId, 
                           Flags = MapEmblemTransformationsContracts(content.Flags), 
                           BackgroundColorId = content.BackgroundColorId, 
                           ForegroundPrimaryColorId = content.ForegroundPrimaryColorId, 
                           ForegroundSecondaryColorId = content.ForegroundSecondaryColorId
                       };
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static EmblemTransformations MapEmblemTransformationsContract(string content)
        {
            Contract.Requires(content != null);
            return (EmblemTransformations)Enum.Parse(typeof(EmblemTransformations), content);
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static EmblemTransformations MapEmblemTransformationsContracts(IEnumerable<string> content)
        {
            return content.Aggregate(EmblemTransformations.None, (current, flag) => current | MapEmblemTransformationsContract(flag));
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Guild MapGuildContracts(GuildContract content)
        {
            Contract.Requires(content != null);
            return new Guild { GuildId = Guid.Parse(content.GuildId), Name = content.Name, Tag = content.Tag, Emblem = MapEmblemContract(content.Emblem) };
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}