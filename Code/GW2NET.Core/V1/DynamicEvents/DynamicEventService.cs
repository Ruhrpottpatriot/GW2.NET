// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the events service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.DynamicEvents;
    using GW2NET.V1.DynamicEvents.Json;

    /// <summary>Provides the default implementation of the events service.</summary>
    public class DynamicEventService : IDynamicEventStateService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public DynamicEventService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public DynamicEventState GetDynamicEvent(Guid eventId, int worldId)
        {
            var request = new DynamicEventStateRequest { EventId = eventId, WorldId = worldId };
            var response = this.serviceClient.Send<EventStateCollectionDataContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return null;
            }

            return ConvertEventStateCollectionDataContract(response.Content).Values.SingleOrDefault();
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId)
        {
            return this.GetDynamicEventAsync(eventId, worldId, CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEventState> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { EventId = eventId, WorldId = worldId };
            return this.serviceClient.SendAsync<EventStateCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return null;
                        }

                        return ConvertEventStateCollectionDataContract(response.Content).Values.SingleOrDefault();
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEvents()
        {
            var request = new DynamicEventStateRequest();
            var response = this.serviceClient.Send<EventStateCollectionDataContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateCollectionDataContract(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync()
        {
            return this.GetDynamicEventsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest();
            return this.serviceClient.SendAsync<EventStateCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateCollectionDataContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsById(Guid eventId)
        {
            var request = new DynamicEventStateRequest { EventId = eventId };
            var response = this.serviceClient.Send<EventStateCollectionDataContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateCollectionDataContract(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { EventId = eventId };
            return this.serviceClient.SendAsync<EventStateCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateCollectionDataContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            return this.GetDynamicEventsByIdAsync(eventId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId)
        {
            var request = new DynamicEventStateRequest { MapId = mapId };
            var response = this.serviceClient.Send<EventStateCollectionDataContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateCollectionDataContract(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId, int worldId)
        {
            var request = new DynamicEventStateRequest { MapId = mapId, WorldId = worldId };
            var response = this.serviceClient.Send<EventStateCollectionDataContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateCollectionDataContract(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { MapId = mapId };
            return this.serviceClient.SendAsync<EventStateCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateCollectionDataContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, worldId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { MapId = mapId, WorldId = worldId };
            return this.serviceClient.SendAsync<EventStateCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateCollectionDataContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByWorld(int worldId)
        {
            var request = new DynamicEventStateRequest { WorldId = worldId };
            var response = this.serviceClient.Send<EventStateCollectionDataContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateCollectionDataContract(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId)
        {
            return this.GetDynamicEventsByWorldAsync(worldId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { WorldId = worldId };
            return this.serviceClient.SendAsync<EventStateCollectionDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateCollectionDataContract(response.Content);
                    }, 
                cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static EventState ConvertEventState(string content)
        {
            Contract.Requires(content != null);
            return (EventState)Enum.Parse(typeof(EventState), content);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static IDictionary<Guid, DynamicEventState> ConvertEventStateCollectionDataContract(EventStateCollectionDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Events != null);
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            var values = new Dictionary<Guid, DynamicEventState>(content.Events.Count);
            foreach (var value in content.Events.Select(ConvertEventStateDataContract))
            {
                Contract.Assume(value != null);
                values.Add(value.EventId, value);
            }

            return values;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private static DynamicEventState ConvertEventStateDataContract(EventStateDataContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<DynamicEventState>() != null);

            // Create a new event state object
            var value = new DynamicEventState();

            // Set the event identifier
            if (content.EventId != null)
            {
                value.EventId = Guid.Parse(content.EventId);
            }

            // Set the map identifier
            value.MapId = content.MapId;

            // Set the world identifier
            value.WorldId = content.WorldId;

            // Set the state of the event
            if (content.State != null)
            {
                value.State = ConvertEventState(content.State);
            }

            // Return the event state object
            return value;
        }
    }
}