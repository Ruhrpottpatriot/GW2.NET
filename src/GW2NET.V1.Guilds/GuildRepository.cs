// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/guild_details.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.V1.Guilds.Converters;
using GW2NET.V1.Guilds.Json;

namespace GW2NET.V1.Guilds
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Guilds;

    /// <summary>Represents a repository that retrieves data from the /v1/guild_details.json interface.</summary>
    public class GuildRepository : IGuildRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<GuildDataContract, Guild> converterForGuild;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="GuildRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public GuildRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForGuild())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GuildRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForGuild">The converter for <see cref="Guild"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForGuild"/> is a null reference.</exception>
        internal GuildRepository(IServiceClient serviceClient, IConverter<GuildDataContract, Guild> converterForGuild)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForGuild == null)
            {
                throw new ArgumentNullException("converterForGuild", "Precondition: converterForGuild != null");
            }

            this.serviceClient = serviceClient;
            this.converterForGuild = converterForGuild;
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
            var response = this.serviceClient.Send<GuildDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.converterForGuild.Convert(response.Content);
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
        Task<Guild> IRepository<Guid, Guild>.FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            var request = new GuildRequest
            {
                GuildId = identifier
            };
            var responseTask = this.serviceClient.SendAsync<GuildDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Guild>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Guild IGuildRepository.FindByName(string name)
        {
            var request = new GuildRequest
            {
                GuildName = name
            };
            var response = this.serviceClient.Send<GuildDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return this.converterForGuild.Convert(response.Content);
        }

        /// <inheritdoc />
        Task<Guild> IGuildRepository.FindByNameAsync(string name)
        {
            IGuildRepository self = this;
            return self.FindByNameAsync(name, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Guild> IGuildRepository.FindByNameAsync(string name, CancellationToken cancellationToken)
        {
            var request = new GuildRequest
            {
                GuildName = name
            };
            var responseTask = this.serviceClient.SendAsync<GuildDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Guild>(this.ConvertAsyncResponse, cancellationToken);
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Guild ConvertAsyncResponse(Task<IResponse<GuildDataContract>> task)
        {
            var response = task.Result;
            if (response.Content == null)
            {
                return null;
            }

            return this.converterForGuild.Convert(response.Content);
        }
    }
}