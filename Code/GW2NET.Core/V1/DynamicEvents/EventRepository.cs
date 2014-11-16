// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/event_details.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.DynamicEvents;
    using GW2NET.V1.DynamicEvents.Converters;
    using GW2NET.V1.DynamicEvents.Json;

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
        internal EventRepository(IServiceClient serviceClient, IConverter<EventCollectionDataContract, ICollection<DynamicEvent>> converterForDynamicEventCollection)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForDynamicEventCollection != null);
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
        Task<IDictionaryRange<Guid, DynamicEvent>> IRepository<Guid, DynamicEvent>.FindAllAsync(CancellationToken cancellationToken)
        {
            IEventRepository self = this;
            var request = new DynamicEventDetailsRequest
            {
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<EventCollectionDataContract>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, request.Culture), cancellationToken);
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
        Task<DynamicEvent> IRepository<Guid, DynamicEvent>.FindAsync(Guid identifier, CancellationToken cancellationToken)
        {
            IEventRepository self = this;
            var request = new DynamicEventDetailsRequest
            {
                EventId = identifier, 
                Culture = self.Culture
            };
            var responseTask = this.serviceClient.SendAsync<EventCollectionDataContract>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertsAsyncResponse(task, request.Culture), cancellationToken);
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<Guid, DynamicEvent> ConvertAsyncResponse(Task<IResponse<EventCollectionDataContract>> task, CultureInfo culture)
        {
            var response = task.Result;
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
                dynamicEvent.Culture = culture;
                events.Add(dynamicEvent.EventId, dynamicEvent);
            }

            return events;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private DynamicEvent ConvertsAsyncResponse(Task<IResponse<EventCollectionDataContract>> task, CultureInfo culture)
        {
            Contract.Requires(task != null);
            var response = task.Result;
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

            dynamicEvent.Culture = culture;

            return dynamicEvent;
        }
    }
}