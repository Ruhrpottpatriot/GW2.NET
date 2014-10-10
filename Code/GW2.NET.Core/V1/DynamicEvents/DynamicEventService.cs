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
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.DynamicEvents;
    using GW2DotNET.Entities.Maps;
    using GW2DotNET.V1.DynamicEvents.Json;

    /// <summary>Provides the default implementation of the events service.</summary>
    public class DynamicEventService : IDynamicEventService
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
            var response = this.serviceClient.Send<EventStateCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return null;
            }

            return ConvertEventStateContractCollection(response.Content).Values.SingleOrDefault();
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
            return this.serviceClient.SendAsync<EventStateCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return null;
                        }

                        return ConvertEventStateContractCollection(response.Content).Values.SingleOrDefault();
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails()
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventDetails(culture);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventDetails(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new DynamicEventDetailsRequest { Culture = language };
            var response = this.serviceClient.Send<EventDetailsCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEvent>(0);
            }

            var values = ConvertEventDetailsCollectionContract(response.Content);
            var locale = response.Culture ?? language;
            foreach (var value in values.Values)
            {
                value.Locale = locale;
            }

            return values;
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId)
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventDetails(eventId, culture);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="language">The language.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEventDetails(Guid eventId, CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new DynamicEventDetailsRequest { Culture = language, EventId = eventId };
            var response = this.serviceClient.Send<EventDetailsCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return null;
            }

            var value = ConvertEventDetailsCollectionContract(response.Content).Values.SingleOrDefault();
            if (value != null)
            {
                value.Locale = response.Culture ?? language;
            }

            return value;
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync()
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventDetailsAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventDetailsAsync(CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventDetailsAsync(culture, cancellationToken);
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
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new DynamicEventDetailsRequest { Culture = language };
            return this.serviceClient.SendAsync<EventDetailsCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEvent>(0);
                        }

                        var values = ConvertEventDetailsCollectionContract(response.Content);
                        var locale = response.Culture ?? language;
                        foreach (var value in values.Values)
                        {
                            value.Locale = locale;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId)
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventDetailsAsync(eventId, culture, CancellationToken.None);
        }

        /// <summary>Gets a dynamic event and its localized details.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its details.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_details">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventDetailsAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventDetailsAsync(eventId, culture, cancellationToken);
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
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new DynamicEventDetailsRequest { Culture = language, EventId = eventId };
            return this.serviceClient.SendAsync<EventDetailsCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return null;
                        }

                        var value = ConvertEventDetailsCollectionContract(response.Content).Values.SingleOrDefault();
                        if (value != null)
                        {
                            value.Locale = response.Culture ?? language;
                        }

                        return value;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames()
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventNames(culture);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEvent> GetDynamicEventNames(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new DynamicEventNameRequest { Culture = language };
            var response = this.serviceClient.Send<ICollection<EventNameContract>>(request);
            if (response.Content == null)
            {
                return new Dictionary<Guid, DynamicEvent>(0);
            }

            var values = ConvertEventNameContracts(response.Content);
            var locale = response.Culture ?? language;
            foreach (var value in values.Values)
            {
                value.Locale = locale;
            }

            return values;
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync()
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventNamesAsync(culture, CancellationToken.None);
        }

        /// <summary>Gets a collection of dynamic events and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/event_names">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEvent>> GetDynamicEventNamesAsync(CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("en");
            return this.GetDynamicEventNamesAsync(culture, cancellationToken);
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
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new DynamicEventNameRequest { Culture = language };
            return this.serviceClient.SendAsync<ICollection<EventNameContract>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new Dictionary<Guid, DynamicEvent>(0);
                        }

                        var values = ConvertEventNameContracts(response.Content);
                        var locale = response.Culture ?? language;
                        foreach (var value in values.Values)
                        {
                            value.Locale = locale;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEvents()
        {
            var request = new DynamicEventStateRequest();
            var response = this.serviceClient.Send<EventStateCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateContractCollection(response.Content);
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
            return this.serviceClient.SendAsync<EventStateCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateContractCollection(response.Content);
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
            var response = this.serviceClient.Send<EventStateCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateContractCollection(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IDictionary<Guid, DynamicEventState>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            var request = new DynamicEventStateRequest { EventId = eventId };
            return this.serviceClient.SendAsync<EventStateCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateContractCollection(response.Content);
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
            var response = this.serviceClient.Send<EventStateCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateContractCollection(response.Content);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IDictionary<Guid, DynamicEventState> GetDynamicEventsByMap(int mapId, int worldId)
        {
            var request = new DynamicEventStateRequest { MapId = mapId, WorldId = worldId };
            var response = this.serviceClient.Send<EventStateCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateContractCollection(response.Content);
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
            return this.serviceClient.SendAsync<EventStateCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateContractCollection(response.Content);
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
            return this.serviceClient.SendAsync<EventStateCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateContractCollection(response.Content);
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
            var response = this.serviceClient.Send<EventStateCollectionContract>(request);
            if (response.Content == null || response.Content.Events == null)
            {
                return new Dictionary<Guid, DynamicEventState>(0);
            }

            return ConvertEventStateContractCollection(response.Content);
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
            return this.serviceClient.SendAsync<EventStateCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null || response.Content.Events == null)
                        {
                            return new Dictionary<Guid, DynamicEventState>(0);
                        }

                        return ConvertEventStateContractCollection(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<Guid, DynamicEvent> ConvertEventDetailsCollectionContract(EventDetailsCollectionContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Events != null);
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEvent>>() != null);
            var values = new Dictionary<Guid, DynamicEvent>(content.Events.Count);
            foreach (var value in content.Events.Select(ConvertEventDetailsContract))
            {
                Contract.Assume(value != null);
                values.Add(value.EventId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static DynamicEvent ConvertEventDetailsContract(KeyValuePair<string, EventDetailsContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);

            // Create a new event object
            var value = new DynamicEvent();

            // Set the event identifier
            value.EventId = Guid.Parse(content.Key);

            // Set the name of the event
            if (content.Value.Name != null)
            {
                value.Name = content.Value.Name;
            }

            // Set the level
            value.Level = content.Value.Level;

            // Set the map identifier
            value.MapId = content.Value.MapId;

            // Set additional flags
            if (content.Value.Flags != null)
            {
                value.Flags = MapDynamicEventFlags(content.Value.Flags);
            }

            // Set the location
            if (content.Value.Location != null)
            {
                value.Location = ConvertLocationContract(content.Value.Location);
            }

            // Return the event object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static DynamicEvent ConvertEventNameContract(EventNameContract content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<DynamicEvent>() != null);

            // Create a new event object
            var value = new DynamicEvent();

            // Set the event identifier
            if (content.Id != null)
            {
                value.EventId = Guid.Parse(content.Id);
            }

            // Set the name of the event
            if (content.Name != null)
            {
                value.Name = content.Name;
            }

            // Return the event object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<Guid, DynamicEvent> ConvertEventNameContracts(ICollection<EventNameContract> content)
        {
            Contract.Requires(content != null);
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEvent>>() != null);
            var values = new Dictionary<Guid, DynamicEvent>(content.Count);
            foreach (var value in content.Select(ConvertEventNameContract))
            {
                Contract.Assume(value != null);
                values.Add(value.EventId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<Guid, DynamicEventState> ConvertEventStateContractCollection(EventStateCollectionContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Events != null);
            Contract.Ensures(Contract.Result<IDictionary<Guid, DynamicEventState>>() != null);
            var values = new Dictionary<Guid, DynamicEventState>(content.Events.Count);
            foreach (var value in content.Events.Select(MapDynamicEventState))
            {
                Contract.Assume(value != null);
                values.Add(value.EventId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Location ConvertLocationContract(LocationContract content)
        {
            Contract.Requires(content != null);
            switch (content.Type)
            {
                case "sphere":
                    return MapSphereLocation(content);
                case "cylinder":
                    return MapCylinderLocation(content);
                case "poly":
                    return MapPolygonLocation(content);
            }

            return MapUnknownLocation(content);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static ICollection<Vector2D> ConvertVector2DCollection(double[][] content)
        {
            Contract.Requires(content != null);
            var values = new List<Vector2D>(content.Length);
            values.AddRange(content.Select(ConvertVector2D));
            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Vector3D ConvertPoint3DContract(double[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 3);
            return new Vector3D(content[0], content[1], content[2]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Vector2D ConvertZRangeContract(double[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 2);
            return new Vector2D(content[0], content[1]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static CylinderLocation MapCylinderLocation(LocationContract content)
        {
            Contract.Requires(content != null);

            // Create a new location object
            var value = new CylinderLocation();

            // Set the center coordinates
            if (content.Center != null && content.Center.Length == 3)
            {
                value.Center = ConvertPoint3DContract(content.Center);
            }

            // Set the cylinder's height
            value.Height = content.Height;

            // Set the cylinder's radius
            value.Radius = content.Radius;

            // Set the cylinder's rotation
            value.Rotation = content.Rotation;

            // Return the location object
            return value;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static DynamicEventFlags MapDynamicEventFlags(IEnumerable<string> content)
        {
            Contract.Requires(content != null);
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
                        flags |= (DynamicEventFlags)Enum.Parse(typeof(DynamicEventFlags), value ?? string.Empty, true);
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
                value.State = MapEventState(content.State);
            }

            // Return the event state object
            return value;
        }

        /// <summary>Infrastructure. Converts text to bit flags.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The bit flags.</returns>
        private static EventState MapEventState(string content)
        {
            Contract.Requires(content != null);
            return (EventState)Enum.Parse(typeof(EventState), content);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Vector2D ConvertVector2D(double[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 2);
            return new Vector2D(content[0], content[1]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static PolygonLocation MapPolygonLocation(LocationContract content)
        {
            Contract.Requires(content != null);
            var value = new PolygonLocation();
            if (content.Center != null && content.Center.Length == 3)
            {
                value.Center = ConvertPoint3DContract(content.Center);
            }

            if (content.ZRange != null && content.ZRange.Length == 2)
            {
                value.ZRange = ConvertZRangeContract(content.ZRange);
            }

            if (content.Points != null)
            {
                value.Points = ConvertVector2DCollection(content.Points);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static SphereLocation MapSphereLocation(LocationContract content)
        {
            Contract.Requires(content != null);

            // Create a new location object
            var value = new SphereLocation();

            // Set the center coordinates
            if (content.Center != null && content.Center.Length == 3)
            {
                value.Center = ConvertPoint3DContract(content.Center);
            }

            // Set the sphere's radius
            value.Radius = content.Radius;

            // Set the sphere's rotation
            value.Rotation = content.Rotation;

            // Return the location object
            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static UnknownLocation MapUnknownLocation(LocationContract content)
        {
            Contract.Requires(content != null);

            // Create a new location object
            var value = new UnknownLocation();

            // Set the center coordinates
            if (content.Center != null && content.Center.Length == 3)
            {
                value.Center = ConvertPoint3DContract(content.Center);
            }

            // Return the location object
            return value;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}