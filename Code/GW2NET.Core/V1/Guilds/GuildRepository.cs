// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/guild_details.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Guilds;
    using GW2NET.V1.Guilds.Json;
    using GW2NET.V1.Guilds.Json.Converters;

    /// <summary>Represents a repository that retrieves data from the /v1/guild_details.json interface.</summary>
    public class GuildRepository : IRepository<Guid, Guild>, IRepository<string, Guild>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<GuildDataContract, Guild> converterForGuild;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="GuildRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public GuildRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForGuild())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GuildRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForGuild">The converter for <see cref="Guild"/>.</param>
        internal GuildRepository(IServiceClient serviceClient, IConverter<GuildDataContract, Guild> converterForGuild)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForGuild != null);
            Contract.Ensures(this.serviceClient != null);
            Contract.Ensures(this.converterForGuild != null);
            this.serviceClient = serviceClient;
            this.converterForGuild = converterForGuild;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        ICollection<Guid> IDiscoverable<Guid>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        Task<ICollection<Guid>> IDiscoverable<Guid>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Guild"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Guild"/> with the specified identifier.</returns>
        Guild IRepository<Guid, Guild>.Find(Guid identifier)
        {
            var request = new GuildRequest { GuildId = identifier };
            var response = this.serviceClient.Send<GuildDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.converterForGuild.Convert(response.Content);
        }

        /// <summary>Finds every <see cref="Guild"/>.</summary>
        /// <returns>A collection of every <see cref="Guild"/>.</returns>
        IDictionaryRange<Guid, Guild> IRepository<Guid, Guild>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Guild"/> with one of the specified identifiers.</returns>
        IDictionaryRange<Guid, Guild> IRepository<Guid, Guild>.FindAll(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/>.</summary>
        /// <returns>A collection of every <see cref="Guild"/>.</returns>
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Guild"/></returns>
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Guild"/> with one of the specified identifiers.</returns>
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Guild"/> with one of the specified identifiers.</returns>
        Task<IDictionaryRange<Guid, Guild>> IRepository<Guid, Guild>.FindAllAsync(ICollection<Guid> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Guild"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Guild"/> with the specified identifier.</returns>
        Task<Guild> IRepository<Guid, Guild>.FindAsync(Guid identifier)
        {
            IRepository<Guid, Guild> self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="Guild"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Guild"/> with the specified identifier.</returns>
        Task<Guild> IRepository<Guid, Guild>.FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            var request = new GuildRequest { GuildId = identifier };
            return this.serviceClient.SendAsync<GuildDataContract>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return null;
                }

                return this.converterForGuild.Convert(response.Content);
            }, cancellationToken);
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        ICollectionPage<Guild> IPaginator<Guild>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        ICollectionPage<Guild> IPaginator<Guild>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <returns>The page.</returns>
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        Task<ICollectionPage<Guild>> IPaginator<Guild>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        ICollection<string> IDiscoverable<string>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Guild"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Guild"/> with the specified identifier.</returns>
        Guild IRepository<string, Guild>.Find(string identifier)
        {
            var request = new GuildRequest { GuildName = identifier };
            var response = this.serviceClient.Send<GuildDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.converterForGuild.Convert(response.Content);
        }

        /// <summary>Finds every <see cref="Guild"/>.</summary>
        /// <returns>A collection of every <see cref="Guild"/>.</returns>
        IDictionaryRange<string, Guild> IRepository<string, Guild>.FindAll()
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Guild"/> with one of the specified identifiers.</returns>
        IDictionaryRange<string, Guild> IRepository<string, Guild>.FindAll(ICollection<string> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/>.</summary>
        /// <returns>A collection of every <see cref="Guild"/></returns>
        Task<IDictionaryRange<string, Guild>> IRepository<string, Guild>.FindAllAsync()
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="Guild"/></returns>
        Task<IDictionaryRange<string, Guild>> IRepository<string, Guild>.FindAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="Guild"/> with one of the specified identifiers.</returns>
        Task<IDictionaryRange<string, Guild>> IRepository<string, Guild>.FindAllAsync(ICollection<string> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds every <see cref="Guild"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="Guild"/> with one of the specified identifiers.</returns>
        Task<IDictionaryRange<string, Guild>> IRepository<string, Guild>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>Finds the <see cref="Guild"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="Guild"/> with the specified identifier.</returns>
        Task<Guild> IRepository<string, Guild>.FindAsync(string identifier)
        {
            IRepository<string, Guild> self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <summary>Finds the <see cref="Guild"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="Guild"/> with the specified identifier.</returns>
        Task<Guild> IRepository<string, Guild>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new GuildRequest { GuildName = identifier };
            return this.serviceClient.SendAsync<GuildDataContract>(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                if (response.Content == null)
                {
                    return null;
                }

                return this.converterForGuild.Convert(response.Content);
            }, cancellationToken);
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForGuild != null);
        }
    }
}