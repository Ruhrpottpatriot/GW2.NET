// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/guild_details.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Guilds
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using GW2NET.Guilds;
    using Json;

    /// <summary>Represents a repository that retrieves data from the /v1/guild_details.json interface.</summary>
    public class GuildRepository : IGuildRepository
    {
        private readonly IConverter<GuildDTO, Guild> guildConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="GuildRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="guildConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public GuildRepository(IServiceClient serviceClient, IConverter<GuildDTO, Guild> guildConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException(nameof(serviceClient));
            }

            if (guildConverter == null)
            {
                throw new ArgumentNullException(nameof(guildConverter));
            }

            this.serviceClient = serviceClient;
            this.guildConverter = guildConverter;
        }

        /// <inheritdoc />
        ICollection<Guid> IDiscoverable<Guid>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Guild IRepository<Guid, Guild>.Find(Guid identifier)
        {
            var request = new GuildRequest
            {
                GuildId = identifier
            };
            var response = this.serviceClient.Send<GuildDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.guildConverter.Convert(response.Content, null);
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Guild> IRepository<Guid, Guild>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, Guild> IRepository<Guid, Guild>.FindAll(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync(ICollection<Guid> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<Guild> IRepository<Guid, Guild>.FindAsync(Guid identifier)
        {
            IGuildRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Guild> IRepository<Guid, Guild>.FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            var request = new GuildRequest
            {
                GuildId = identifier
            };
            var response = await this.serviceClient.SendAsync<GuildDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return null;
            }

            return this.guildConverter.Convert(response.Content, response);
        }

        /// <inheritdoc />
        Guild IGuildRepository.FindByName(string name)
        {
            var request = new GuildRequest
            {
                GuildName = name
            };
            var response = this.serviceClient.Send<GuildDTO>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.guildConverter.Convert(response.Content, null);
        }

        /// <inheritdoc />
        Task<Guild> IGuildRepository.FindByNameAsync(string name)
        {
            IGuildRepository self = this;
            return self.FindByNameAsync(name, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<Guild> IGuildRepository.FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            var request = new GuildRequest
            {
                GuildName = name
            };
            var response = await this.serviceClient.SendAsync<GuildDTO>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return null;
            }

            return this.guildConverter.Convert(response.Content, response);
        }

        /// <inheritdoc />
        ICollectionPage<Guild> IPaginator<Guild>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<Guild> IPaginator<Guild>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}