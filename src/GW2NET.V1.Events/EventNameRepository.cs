// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventNameRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/event_names.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Converters;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events
{
    /// <summary>Represents a repository that retrieves data from the /v1/event_names.json interface.</summary>
    public class EventNameRepository : IEventNameRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<EventNameDataContract>, ICollection<DynamicEventName>> converterForDynamicEventNameCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="EventNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public EventNameRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForCollection<EventNameDataContract, DynamicEventName>(new ConverterForDynamicEventName()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="EventNameRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForDynamicEventNameCollection">The converter for <see cref="T:ICollection{DynamicEventName}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> or <paramref name="converterForDynamicEventNameCollection"/> is a null reference.</exception>
        internal EventNameRepository(IServiceClient serviceClient, IConverter<ICollection<EventNameDataContract>, ICollection<DynamicEventName>> converterForDynamicEventNameCollection)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (converterForDynamicEventNameCollection == null)
            {
                throw new ArgumentNullException("converterForDynamicEventNameCollection", "Precondition: converterForDynamicEventNameCollection != null");
            }

            this.serviceClient = serviceClient;
            this.converterForDynamicEventNameCollection = converterForDynamicEventNameCollection;
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
            var response = this.serviceClient.Send<ICollection<EventNameDataContract>>(request);
            var eventNameDataContracts = response.Content;
            if (eventNameDataContracts == null)
            {
                return new DictionaryRange<Guid, DynamicEventName>(0);
            }

            var dynamicEventNames = new DictionaryRange<Guid, DynamicEventName>(eventNameDataContracts.Count)
            {
                SubtotalCount = eventNameDataContracts.Count,
                TotalCount = eventNameDataContracts.Count
            };

            foreach (var dynamicEventName in this.converterForDynamicEventNameCollection.Convert(eventNameDataContracts))
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
            var response = await this.serviceClient.SendAsync<ICollection<EventNameDataContract>>(request, cancellationToken).ConfigureAwait(false);
            if (response.Content == null)
            {
                return new DictionaryRange<Guid, DynamicEventName>(0);
            }

            var dynamicEventNames = new DictionaryRange<Guid, DynamicEventName>(response.Content.Count)
            {
                SubtotalCount = response.Content.Count,
                TotalCount = response.Content.Count
            };

            foreach (var dynamicEventName in this.converterForDynamicEventNameCollection.Convert(response.Content))
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
