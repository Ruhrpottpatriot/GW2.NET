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
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.DynamicEvents;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.DynamicEvents.Contracts;

    /// <summary>Provides the default implementation of the events service.</summary>
    public class DynamicEventService : IDynamicEventService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

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
        public DynamicEventState GetDynamicEvent(Guid eventId, int worldId)
        {
            var request = new DynamicEventStateRequest { EventId = eventId, WorldId = worldId };
            var response = this.serviceClient.Send(request, new JsonSerializer<EventStateCollectionContract>());
            return MapEventStateContracts(response.Content).Values.SingleOrDefault();
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventStateCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventStateContracts(response.Content).Values.SingleOrDefault();
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails()
        {
            return this.GetDynamicEventDetails(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<EventDetailsCollectionContract>());
            return MapEventDetailsCollectionContract(response.Content, language);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId)
        {
            return this.GetDynamicEventDetails(eventId, CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language, EventId = eventId };
            var response = this.serviceClient.Send(request, new JsonSerializer<EventDetailsCollectionContract>());
            return MapEventDetailsCollectionContract(response.Content, language).Values.SingleOrDefault();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync()
        {
            return this.GetDynamicEventDetailsAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventDetailsCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventDetailsCollectionContract(response.Content, language);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId)
        {
            return this.GetDynamicEventDetailsAsync(eventId, CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(eventId, CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(eventId, language, CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language, EventId = eventId };
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventDetailsCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventDetailsCollectionContract(response.Content, language).Values.SingleOrDefault();
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames()
        {
            return this.GetDynamicEventNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventNameRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<ICollection<EventNameContract>>());
            return MapEventNameContracts(response.Content, language);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync()
        {
            return this.GetDynamicEventNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CultureInfo language)
        {
            return this.GetDynamicEventNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventNameRequest { Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<ICollection<EventNameContract>>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventNameContracts(response.Content, language);
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their start times.</summary>
        /// <returns>A collection of dynamic events and their start times.</returns>
        public IDictionary<Guid, DynamicEventRotation> GetDynamicEventRotations()
        {
            var configuration = this.LoadConfiguration();
            var rotationElements = configuration.Descendants("rotation").Where(element => element.Attributes("event_id").Any()).ToList();
            var values = new Dictionary<Guid, DynamicEventRotation>(rotationElements.Count);
            foreach (var contract in rotationElements)
            {
                var eventId = Guid.Parse(contract.Attribute("event_id").Value);
                var shifts = contract.Descendants("shift").Select(
                    element =>
                        {
                            var shift = DateTimeOffset.Parse(element.Value);
                            if (shift < DateTime.UtcNow)
                            {
                                shift = shift.AddDays(1D);
                            }

                            return shift;
                        }).OrderBy(offset => offset.Ticks);

                values.Add(eventId, new DynamicEventRotation { EventId = eventId, Shifts = new List<DateTimeOffset>(shifts) });
            }

            return values;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEvents()
        {
            var request = new DynamicEventStateRequest();
            var response = this.serviceClient.Send(request, new JsonSerializer<EventStateCollectionContract>());
            return MapEventStateContracts(response.Content);
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventStateCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventStateContracts(response.Content);
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
            var response = this.serviceClient.Send(request, new JsonSerializer<EventStateCollectionContract>());
            return MapEventStateContracts(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { EventId = eventId };
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventStateCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventStateContracts(response.Content);
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
            var response = this.serviceClient.Send(request, new JsonSerializer<EventStateCollectionContract>());
            return MapEventStateContracts(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId, int worldId)
        {
            var request = new DynamicEventStateRequest { MapId = mapId, WorldId = worldId };
            var response = this.serviceClient.Send(request, new JsonSerializer<EventStateCollectionContract>());
            return MapEventStateContracts(response.Content);
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventStateCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventStateContracts(response.Content);
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventStateCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventStateContracts(response.Content);
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
            var response = this.serviceClient.Send(request, new JsonSerializer<EventStateCollectionContract>());
            return MapEventStateContracts(response.Content);
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
            return this.serviceClient.SendAsync(request, new JsonSerializer<EventStateCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapEventStateContracts(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static CylinderLocation MapCylinderLocation(LocationContract content)
        {
            return new CylinderLocation
                       {
                           Center = MapPoint3DContract(content.Center), 
                           Height = content.Height, 
                           Radius = content.Radius, 
                           Rotation = content.Rotation
                       };
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static DynamicEventFlags MapDynamicEventFlags(IEnumerable<string> content)
        {
            var flags = DynamicEventFlags.None;
            foreach (var value in content)
            {
                switch (value)
                {
                    case "group_event":
                        flags |= DynamicEventFlags.GroupEvent;
                        break;
                    case "map_wide":
                        flags |= DynamicEventFlags.MapWide;
                        break;
                    default:

                        // Attempt to parse a previously unknown value, ultimately resulting in an argument exception
                        flags |= (DynamicEventFlags)Enum.Parse(typeof(DynamicEventFlags), value, true);
                        break;
                }
            }

            return flags;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static DynamicEventState MapDynamicEventState(EventStateContract content)
        {
            return new DynamicEventState
                       {
                           EventId = Guid.Parse(content.EventId), 
                           MapId = content.MapId, 
                           WorldId = content.WorldId, 
                           State = MapEventState(content)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<Guid, DynamicEvent> MapEventDetailsCollectionContract(EventDetailsCollectionContract content, CultureInfo culture)
        {
            var values = new Dictionary<Guid, DynamicEvent>(content.Events.Count);
            foreach (var value in content.Events.Select(MapEventDetailsContract))
            {
                value.Language = culture.TwoLetterISOLanguageName;
                values.Add(value.EventId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static DynamicEvent MapEventDetailsContract(KeyValuePair<string, EventDetailsContract> content)
        {
            return new DynamicEvent
                       {
                           EventId = Guid.Parse(content.Key), 
                           Name = content.Value.Name, 
                           Level = content.Value.Level, 
                           MapId = content.Value.MapId, 
                           Flags = MapDynamicEventFlags(content.Value.Flags), 
                           Location = MapLocationContract(content.Value.Location)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static DynamicEvent MapEventNameContract(EventNameContract content)
        {
            return new DynamicEvent { EventId = Guid.Parse(content.Id), Name = content.Name };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<Guid, DynamicEvent> MapEventNameContracts(ICollection<EventNameContract> content, CultureInfo culture)
        {
            var values = new Dictionary<Guid, DynamicEvent>(content.Count);
            foreach (var value in content.Select(MapEventNameContract))
            {
                value.Language = culture.TwoLetterISOLanguageName;
                values.Add(value.EventId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static EventState MapEventState(EventStateContract content)
        {
            return (EventState)Enum.Parse(typeof(EventState), content.State);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<Guid, DynamicEventState> MapEventStateContracts(EventStateCollectionContract content)
        {
            var values = new Dictionary<Guid, DynamicEventState>(content.Events.Count);
            foreach (var value in content.Events.Select(MapDynamicEventState))
            {
                values.Add(value.EventId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Location MapLocationContract(LocationContract content)
        {
            switch (content.Type)
            {
                case "sphere":
                    return MapSphereLocation(content);
                case "cylinder":
                    return MapCylinderLocation(content);
                case "poly":
                    return MapPolygonLocation(content);
                default:
                    return MapUnknownLocation(content);
            }
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Point2D MapPoint2DContract(double[] content)
        {
            return new Point2D(content[0], content[1]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<Point2D> MapPoint2DContracts(double[][] content)
        {
            var values = new List<Point2D>(content.Length);
            values.AddRange(content.Select(MapPoint2DContract));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Point3D MapPoint3DContract(double[] content)
        {
            return new Point3D(content[0], content[1], content[2]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static PolygonLocation MapPolygonLocation(LocationContract content)
        {
            return new PolygonLocation
                       {
                           Center = MapPoint3DContract(content.Center), 
                           ZRange = MapZRangeContract(content.ZRange), 
                           Points = MapPoint2DContracts(content.Points)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static SphereLocation MapSphereLocation(LocationContract content)
        {
            return new SphereLocation { Center = MapPoint3DContract(content.Center), Radius = content.Radius, Rotation = content.Rotation };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static UnknownLocation MapUnknownLocation(LocationContract content)
        {
            return new UnknownLocation { Center = MapPoint3DContract(content.Center) };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Vector2D MapZRangeContract(double[] content)
        {
            return new Vector2D(content[0], content[1]);
        }

        /// <summary>Infrastructure. Loads the configuration.</summary>
        /// <returns>The configuration.</returns>
        private XDocument LoadConfiguration()
        {
            var type = this.GetType();
            using (var stream = type.Assembly.GetManifestResourceStream(type.Namespace + ".Rotations.xml"))
            {
                return XDocument.Load(stream);
            }
        }
    }
}