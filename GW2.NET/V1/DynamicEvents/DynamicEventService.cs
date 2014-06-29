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
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.DynamicEvents.Contracts;

    /// <summary>Provides the default implementation of the events service.</summary>
    public class DynamicEventService : IDynamicEventService
    {
        /// <summary>Infrastructure. Holds a reference to the serializer settings.</summary>
        private static readonly DynamicEventDetailsSerializerSettings Settings = new DynamicEventDetailsSerializerSettings();

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
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventStateCollectionResult>());

            return result.Events.SingleOrDefault();
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
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventStateCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith(task => task.Result.Events.SingleOrDefault(), cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventDetails()
        {
            return this.GetDynamicEventDetails(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventDetails(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventCollectionResult>(Settings));

            // Apply patches
            foreach (var dynamicEvent in result.Events)
            {
                // Patch missing event identifier
                dynamicEvent.Value.EventId = dynamicEvent.Key;

                // Patch missing language information
                dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
            }

            return result.Events.Values;
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
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventCollectionResult>(Settings));

            // Apply patches
            foreach (var dynamicEvent in result.Events)
            {
                // Patch missing event identifier
                dynamicEvent.Value.EventId = dynamicEvent.Key;

                // Patch missing language information
                dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
            }

            return result.Events.Values.SingleOrDefault();
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync()
        {
            return this.GetDynamicEventDetailsAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventDetailsAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language)
        {
            return this.GetDynamicEventDetailsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventDetailsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventDetailsRequest { Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventCollectionResult>(Settings), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEvent>>(
                task =>
                    {
                        var result = task.Result;

                        // Apply patches
                        foreach (var dynamicEvent in result.Events)
                        {
                            // Patch missing event identifier
                            dynamicEvent.Value.EventId = dynamicEvent.Key;

                            // Patch missing language information
                            dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
                        }

                        return result.Events.Values;
                    }, 
                cancellationToken);

            return t2;
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
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventCollectionResult>(Settings), cancellationToken);
            var t2 = t1.ContinueWith(
                task =>
                    {
                        var result = task.Result;

                        // Apply patches
                        foreach (var dynamicEvent in result.Events)
                        {
                            // Patch missing event identifier
                            dynamicEvent.Value.EventId = dynamicEvent.Key;

                            // Patch missing language information
                            dynamicEvent.Value.Language = language.TwoLetterISOLanguageName;
                        }

                        return result.Events.Values.SingleOrDefault();
                    }, 
                cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames()
        {
            return this.GetDynamicEventNames(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventName> GetDynamicEventNames(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventNameRequest { Culture = language };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventNameCollection>());

            // Patch missing language information
            foreach (var eventName in result)
            {
                eventName.Language = language.TwoLetterISOLanguageName;
            }

            return result;
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync()
        {
            return this.GetDynamicEventNamesAsync(CultureInfo.GetCultureInfo("en"), CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventNamesAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language)
        {
            return this.GetDynamicEventNamesAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventName>> GetDynamicEventNamesAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new DynamicEventNameRequest { Culture = language };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventNameCollection>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEventName>>(
                task =>
                    {
                        var result = task.Result;

                        // Patch missing language information
                        foreach (var eventName in result)
                        {
                            eventName.Language = language.TwoLetterISOLanguageName;
                        }

                        return result;
                    }, 
                cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their start times.</summary>
        /// <returns>A collection of dynamic events and their start times.</returns>
        public IEnumerable<DynamicEventRotation> GetDynamicEventRotations()
        {
            return (from rotationElement in this.LoadConfiguration().Descendants("rotation").Where(element => element.Attributes("event_id").Any())
                    let shiftElements = rotationElement.Descendants("shift")
                    let eventId = Guid.Parse(rotationElement.Attribute("event_id").Value)
                    let shifts = shiftElements.Select(
                        element =>
                            {
                                var shift = DateTimeOffset.Parse(element.Value);
                                if (shift < DateTime.UtcNow)
                                {
                                    shift = shift.AddDays(1D);
                                }

                                return shift;
                            }).OrderBy(offset => offset.Ticks)
                    select new DynamicEventRotation { EventId = eventId, Shifts = new DynamicEventShifts(shifts) }).ToList();
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventState> GetDynamicEvents()
        {
            var request = new DynamicEventStateRequest();
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventStateCollectionResult>());

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsAsync()
        {
            return this.GetDynamicEventsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest();
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventStateCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEventState>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventState> GetDynamicEventsById(Guid eventId)
        {
            var request = new DynamicEventStateRequest { EventId = eventId };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventStateCollectionResult>());

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { EventId = eventId };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventStateCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEventState>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            return this.GetDynamicEventsByIdAsync(eventId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventState> GetDynamicEventsByMap(int mapId)
        {
            var request = new DynamicEventStateRequest { MapId = mapId };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventStateCollectionResult>());

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventState> GetDynamicEventsByMap(int mapId, int worldId)
        {
            var request = new DynamicEventStateRequest { MapId = mapId, WorldId = worldId };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventStateCollectionResult>());

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByMapAsync(int mapId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { MapId = mapId };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventStateCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEventState>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, worldId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { MapId = mapId, WorldId = worldId };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventStateCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEventState>>(task => task.Result.Events, cancellationToken);

            return t2;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEventState> GetDynamicEventsByWorld(int worldId)
        {
            var request = new DynamicEventStateRequest { WorldId = worldId };
            var result = this.serviceClient.Send(request, new JsonSerializer<DynamicEventStateCollectionResult>());

            return result.Events;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId)
        {
            return this.GetDynamicEventsByWorldAsync(worldId, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEventState>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { WorldId = worldId };
            var t1 = this.serviceClient.SendAsync(request, new JsonSerializer<DynamicEventStateCollectionResult>(), cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<DynamicEventState>>(task => task.Result.Events, cancellationToken);

            return t2;
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