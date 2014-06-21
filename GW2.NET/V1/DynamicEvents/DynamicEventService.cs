// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the events service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.V1.DynamicEvents.Contracts;

    /// <summary>Provides the default implementation of the events service.</summary>
    public class DynamicEventService : IDynamicEventService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventService" /> class.</summary>
        public DynamicEventService()
            : this(new ServiceClient())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public DynamicEventService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEvent(Guid eventId, int worldId)
        {
            var serviceRequest = new DynamicEventRequest { EventId = eventId, WorldId = worldId };
            var result = this.serviceClient.Send<DynamicEventCollectionResult>(serviceRequest);

            return result.Events.SingleOrDefault();
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId)
        {
            return this.GetDynamicEventAsync(eventId, worldId, CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken)
        {
            var serviceRequest = new DynamicEventRequest { EventId = eventId, WorldId = worldId };
            var t1 = this.serviceClient.SendAsync<DynamicEventCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith(task => task.Result.Events.SingleOrDefault(), cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEvents()
        {
            var serviceRequest = new DynamicEventRequest();
            var result = this.serviceClient.Send<DynamicEventCollectionResult>(serviceRequest);

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync()
        {
            return this.GetDynamicEventsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            var serviceRequest = new DynamicEventRequest();
            var t1 = this.serviceClient.SendAsync<DynamicEventCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEvent>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId)
        {
            var serviceRequest = new DynamicEventRequest { EventId = eventId };
            var result = this.serviceClient.Send<DynamicEventCollectionResult>(serviceRequest);

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var serviceRequest = new DynamicEventRequest { EventId = eventId };
            var t1 = this.serviceClient.SendAsync<DynamicEventCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEvent>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            return this.GetDynamicEventsByIdAsync(eventId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId)
        {
            var serviceRequest = new DynamicEventRequest { MapId = mapId };
            var result = this.serviceClient.Send<DynamicEventCollectionResult>(serviceRequest);

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId)
        {
            var serviceRequest = new DynamicEventRequest { MapId = mapId, WorldId = worldId };
            var result = this.serviceClient.Send<DynamicEventCollectionResult>(serviceRequest);

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            var serviceRequest = new DynamicEventRequest { MapId = mapId };
            var t1 = this.serviceClient.SendAsync<DynamicEventCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEvent>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, worldId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            var serviceRequest = new DynamicEventRequest { MapId = mapId, WorldId = worldId };
            var t1 = this.serviceClient.SendAsync<DynamicEventCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEvent>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId)
        {
            var serviceRequest = new DynamicEventRequest { WorldId = worldId };
            var result = this.serviceClient.Send<DynamicEventCollectionResult>(serviceRequest);

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId)
        {
            return this.GetDynamicEventsByWorldAsync(worldId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            var serviceRequest = new DynamicEventRequest { WorldId = worldId };
            var t1 = this.serviceClient.SendAsync<DynamicEventCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEvent>>(task => task.Result.Events, cancellationToken);

            return t2;
        }
    }
}