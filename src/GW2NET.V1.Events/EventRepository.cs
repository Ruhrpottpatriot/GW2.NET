// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/event_details.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GW2NET.Common;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Converters;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events
{
    using System.Diagnostics;

    /// <summary>Represents a repository that retrieves data from the /v1/event_details.json interface.</summary>
    public class EventRepository : IEventRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<EventCollectionDataContract, ICollection<DynamicEvent>> converterForDynamicEventCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="EventRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public EventRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForDynamicEventCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EventRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForDynamicEventCollection">The converter for <see cref="T:ICollection{DynamicEvent}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForDynamicEventCollection"/> is a null reference.</exception>
        internal EventRepository(IServiceClient serviceClient, IConverter<EventCollectionDataContract, ICollection<DynamicEvent>> converterForDynamicEventCollection)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForDynamicEventCollection == null)
            {
                throw new ArgumentNullException("converterForDynamicEventCollection", "Precondition: converterForDynamicEventCollection != null");
            }

            this.serviceClient = serviceClient;
            this.converterForDynamicEventCollection = converterForDynamicEventCollection;
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
        DynamicEvent IRepository<Guid, DynamicEvent>.Find(Guid identifier)
        {
            IEventRepository self = this;
            var request = new DynamicEventDetailsRequest
            {
                EventId = identifier,
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<EventCollectionDataContract>(request);
            var eventCollectionDataContract = response.Content;
            if (eventCollectionDataContract == null)
            {
                return null;
            }

            var eventDataContracts = eventCollectionDataContract.Events;
            if (eventDataContracts == null)
            {
                return null;
            }

            var dynamicEvents = this.converterForDynamicEventCollection.Convert(eventCollectionDataContract);
            if (dynamicEvents == null)
            {
                return null;
            }

            var dynamicEvent = dynamicEvents.SingleOrDefault();
            if (dynamicEvent == null)
            {
                return null;
            }

            dynamicEvent.Culture = request.Culture;

            return dynamicEvent;
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, DynamicEvent> IRepository<Guid, DynamicEvent>.FindAll()
        {
            IEventRepository self = this;
            var request = new DynamicEventDetailsRequest
            {
                Culture = self.Culture
            };
            var response = this.serviceClient.Send<EventCollectionDataContract>(request);
            var eventCollectionDataContract = response.Content;
            if (eventCollectionDataContract == null)
            {
                return new DictionaryRange<Guid, DynamicEvent>(0);
            }

            var eventDataContracts = eventCollectionDataContract.Events;
            if (eventDataContracts == null)
            {
                return new DictionaryRange<Guid, DynamicEvent>(0);
            }

            var dynamicEvents = this.converterForDynamicEventCollection.Convert(eventCollectionDataContract);
            if (dynamicEvents == null)
            {
                return new DictionaryRange<Guid, DynamicEvent>(0);
            }

            var events = new DictionaryRange<Guid, DynamicEvent>(dynamicEvents.Count)
            {
                SubtotalCount = dynamicEvents.Count,
                TotalCount = dynamicEvents.Count
            };
            foreach (var dynamicEvent in dynamicEvents)
            {
                dynamicEvent.Culture = request.Culture;
                events.Add(dynamicEvent.EventId, dynamicEvent);
            }

            return events;
        }

        /// <inheritdoc />
        IDictionaryRange<Guid, DynamicEvent> IRepository<Guid, DynamicEvent>.FindAll(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, DynamicEvent>> IRepository<Guid, DynamicEvent>.FindAllAsync()
        {
            IEventRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<IDictionaryRange<Guid, DynamicEvent>> IRepository<Guid, DynamicEvent>.FindAllAsync(CancellationToken cancellationToken)
        {
            IEventRepository self = this;
            var request = new DynamicEventDetailsRequest
            {
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<EventCollectionDataContract>(request, cancellationToken).ConfigureAwait(false);
            var eventCollectionDataContract = response.Content;
            if (eventCollectionDataContract == null)
            {
                return new DictionaryRange<Guid, DynamicEvent>(0);
            }

            var eventDataContracts = eventCollectionDataContract.Events;
            if (eventDataContracts == null)
            {
                return new DictionaryRange<Guid, DynamicEvent>(0);
            }

            var dynamicEvents = this.converterForDynamicEventCollection.Convert(eventCollectionDataContract);
            if (dynamicEvents == null)
            {
                return new DictionaryRange<Guid, DynamicEvent>(0);
            }

            var events = new DictionaryRange<Guid, DynamicEvent>(dynamicEvents.Count)
            {
                SubtotalCount = dynamicEvents.Count,
                TotalCount = dynamicEvents.Count
            };
            foreach (var dynamicEvent in dynamicEvents)
            {
                dynamicEvent.Culture = request.Culture;
                events.Add(dynamicEvent.EventId, dynamicEvent);
            }

            return events;
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, DynamicEvent>> IRepository<Guid, DynamicEvent>.FindAllAsync(ICollection<Guid> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<Guid, DynamicEvent>> IRepository<Guid, DynamicEvent>.FindAllAsync(ICollection<Guid> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<DynamicEvent> IRepository<Guid, DynamicEvent>.FindAsync(Guid identifier)
        {
            IEventRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        async Task<DynamicEvent> IRepository<Guid, DynamicEvent>.FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            IEventRepository self = this;
            var request = new DynamicEventDetailsRequest
            {
                EventId = identifier,
                Culture = self.Culture
            };
            var response = await this.serviceClient.SendAsync<EventCollectionDataContract>(request, cancellationToken).ConfigureAwait(false);
            var eventCollectionDataContract = response.Content;
            if (eventCollectionDataContract == null)
            {
                return null;
            }

            var eventDataContracts = eventCollectionDataContract.Events;
            if (eventDataContracts == null)
            {
                return null;
            }

            var dynamicEvents = this.converterForDynamicEventCollection.Convert(eventCollectionDataContract);
            if (dynamicEvents == null)
            {
                return null;
            }

            var dynamicEvent = dynamicEvents.SingleOrDefault();
            if (dynamicEvent == null)
            {
                return null;
            }

            dynamicEvent.Culture = request.Culture;

            return dynamicEvent;
        }

        /// <inheritdoc />
        ICollectionPage<DynamicEvent> IPaginator<DynamicEvent>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<DynamicEvent> IPaginator<DynamicEvent>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEvent>> IPaginator<DynamicEvent>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEvent>> IPaginator<DynamicEvent>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEvent>> IPaginator<DynamicEvent>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<DynamicEvent>> IPaginator<DynamicEvent>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }
    }
}