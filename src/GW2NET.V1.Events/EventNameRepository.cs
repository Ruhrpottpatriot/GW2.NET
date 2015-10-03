// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventNameRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/event_names.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events
{
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

    /// <summary>Represents a repository that retrieves data from the /v1/event_names.json interface.</summary>
    public class EventNameRepository : IEventNameRepository
    {
        private readonly IConverter<ICollection<EventNameDTO>, ICollection<DynamicEventName>> dynamicEventNameCollectionConverter;

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="EventNameRepository"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <param name="dynamicEventNameCollectionConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EventNameRepository(IServiceClient serviceClient, IConverter<ICollection<EventNameDTO>, ICollection<DynamicEventName>> dynamicEventNameCollectionConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            if (dynamicEventNameCollectionConverter == null)
            {
                throw new ArgumentNullException("dynamicEventNameCollectionConverter");
            }

            this.serviceClient = serviceClient;
            this.dynamicEventNameCollectionConverter = dynamicEventNameCollectionConverter;
        }

        /// <inheritdoc />
        CultureInfo ILocalizable.Culture { get; set; }

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
        DynamicEventName IRepository<Guid, DynamicEventName>.Find(Guid identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, DynamicEventName> IRepository<Guid, DynamicEventName>.FindAll()
        {
            IEventNameRepository self = this;
            var request = new DynamicEventNameRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<ICollection<EventNameDTO>>(request);
            if (response.Content == null)
            {
                return new DictionaryRange<Guid, DynamicEventName>(0);
            }

            var dynamicEventNames = new DictionaryRange<Guid, DynamicEventName>(response.Content.Count)
            {
                SubtotalCount = response.Content.Count,
                TotalCount = response.Content.Count
            };

            foreach (var dynamicEventName in this.dynamicEventNameCollectionConverter.Convert(response.Content, null))
            {
                dynamicEventName.Culture = request.Culture;
                dynamicEventNames.Add(dynamicEventName.EventId, dynamicEventName);
            }

            return dynamicEventNames;
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, DynamicEventName> IRepository<Guid, DynamicEventName>.FindAll(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, DynamicEventName>> IRepository<Guid, DynamicEventName>.FindAllAsync()
        {
            return ((IEventNameRepository)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<Guid, DynamicEventName>> IRepository<Guid, DynamicEventName>.FindAllAsync(CancellationToken cancellationToken)
        {
            IEventNameRepository self = this;
            var request = new DynamicEventNameRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<ICollection<EventNameDTO>>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return new DictionaryRange<Guid, DynamicEventName>(0);
            }

            var dynamicEventNames = new DictionaryRange<Guid, DynamicEventName>(response.Content.Count)
            {
                SubtotalCount = response.Content.Count,
                TotalCount = response.Content.Count
            };

            foreach (var dynamicEventName in this.dynamicEventNameCollectionConverter.Convert(response.Content, null))
            {
                dynamicEventName.Culture = request.Culture;
                dynamicEventNames.Add(dynamicEventName.EventId, dynamicEventName);
            }

            return dynamicEventNames;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, DynamicEventName>> IRepository<Guid, DynamicEventName>.FindAllAsync(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, DynamicEventName>> IRepository<Guid, DynamicEventName>.FindAllAsync(ICollection<Guid> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<DynamicEventName> IRepository<Guid, DynamicEventName>.FindAsync(Guid identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<DynamicEventName> IRepository<Guid, DynamicEventName>.FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<DynamicEventName> IPaginator<DynamicEventName>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<DynamicEventName> IPaginator<DynamicEventName>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEventName>> IPaginator<DynamicEventName>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEventName>> IPaginator<DynamicEventName>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEventName>> IPaginator<DynamicEventName>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEventName>> IPaginator<DynamicEventName>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}