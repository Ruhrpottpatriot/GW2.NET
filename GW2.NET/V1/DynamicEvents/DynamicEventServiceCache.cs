// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicEventServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides an implementation of the dynamic events service, backed up by a caching provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.DynamicEvents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Extensions;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Common;
    using GW2DotNET.V1.Common.Caching;
    using GW2DotNET.V1.DynamicEvents.Contracts;

    /// <summary>Provides an implementation of the dynamic events service, backed up by a caching provider.</summary>
    public class DynamicEventServiceCache : ServiceObjectCache, IDynamicEventServiceCache
    {
        /// <summary>Infrastructure. Holds a reference to the default in-memory cache.</summary>
        private static readonly Lazy<DynamicEventServiceCache> DefaultServiceCache = new Lazy<DynamicEventServiceCache>();

        /// <summary>Infrastructure. Holds a reference to the fallback service.</summary>
        private readonly IDynamicEventService fallbackService;

        /// <summary>Initializes a new instance of the <see cref="DynamicEventServiceCache"/> class.</summary>
        public DynamicEventServiceCache()
            : this(new DynamicEventService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        public DynamicEventServiceCache(ObjectCache objectCache)
            : this(objectCache, new DynamicEventService())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventServiceCache"/> class.</summary>
        /// <param name="fallbackService">The fallback Service.</param>
        public DynamicEventServiceCache(IDynamicEventService fallbackService)
            : this(new MemoryCache(Services.Events), fallbackService)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DynamicEventServiceCache"/> class.</summary>
        /// <param name="objectCache">The object Cache.</param>
        /// <param name="fallbackService">The fallback Service.</param>
        public DynamicEventServiceCache(ObjectCache objectCache, IDynamicEventService fallbackService)
            : base(objectCache)
        {
            Preconditions.EnsureNotNull(paramName: "fallbackService", value: fallbackService);
            this.fallbackService = fallbackService;
        }

        /// <summary>Gets the default implementation of the service, backed up by an in-memory cache.</summary>
        public static DynamicEventServiceCache Default
        {
            get
            {
                return DefaultServiceCache.Value;
            }
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEvent(Guid eventId, int worldId, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEvent(eventId, worldId);
            }

            return this.GetDynamicEvents(true).Single(dynamicEvent => dynamicEvent.EventId == eventId && dynamicEvent.WorldId == worldId);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public DynamicEvent GetDynamicEvent(Guid eventId, int worldId)
        {
            return this.GetDynamicEvent(eventId, worldId, true);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId, bool allowCache)
        {
            return this.GetDynamicEventAsync(eventId, worldId, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventAsync(eventId, worldId, cancellationToken);
            }

            return
                this.GetDynamicEventsAsync(cancellationToken, true)
                    .ContinueWith(
                        task => task.Result.Single(dynamicEvent => dynamicEvent.EventId == eventId && dynamicEvent.WorldId == worldId), 
                        cancellationToken);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId)
        {
            return this.GetDynamicEventAsync(eventId, worldId, CancellationToken.None, true);
        }

        /// <summary>Gets a dynamic event and its status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A dynamic event and its status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<DynamicEvent> GetDynamicEventAsync(Guid eventId, int worldId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventAsync(eventId, worldId, CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEvents(bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEvents();
            }

            var dynamicEvents = this.Get<IEnumerable<DynamicEvent>>(GetKey());

            if (dynamicEvents == null)
            {
                this.SetDynamicEvents(dynamicEvents = this.fallbackService.GetDynamicEvents());
            }

            return dynamicEvents;
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEvents()
        {
            return this.GetDynamicEvents(true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(bool allowCache)
        {
            return this.GetDynamicEventsAsync(CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsAsync(cancellationToken);
            }

            var dynamicEvents = this.Get<IEnumerable<DynamicEvent>>(GetKey());

            if (dynamicEvents != null)
            {
                return Task.Factory.FromResult(dynamicEvents);
            }

            return this.fallbackService.GetDynamicEventsAsync(cancellationToken).ContinueWith(
                task =>
                    {
                        this.SetDynamicEvents(dynamicEvents = task.Result);
                        return dynamicEvents;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync()
        {
            return this.GetDynamicEventsAsync(CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsAsync(CancellationToken cancellationToken)
        {
            return this.GetDynamicEventsAsync(cancellationToken, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsById(eventId);
            }

            return this.GetDynamicEvents(true).Where(dynamicEvent => dynamicEvent.EventId == eventId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsById(Guid eventId)
        {
            return this.GetDynamicEventsById(eventId, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, bool allowCache)
        {
            return this.GetDynamicEventsByIdAsync(eventId, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsByIdAsync(eventId, cancellationToken);
            }

            return this.GetDynamicEventsAsync(cancellationToken, true)
                       .ContinueWith(task => task.Result.Where(dynamicEvent => dynamicEvent.EventId == eventId), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId)
        {
            return this.GetDynamicEventsByIdAsync(eventId, CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="eventId">The dynamic event filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventsByIdAsync(eventId, cancellationToken, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsByMap(mapId);
            }

            return this.GetDynamicEvents(true).Where(dynamicEvent => dynamicEvent.MapId == mapId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsByMap(mapId, worldId);
            }

            return this.GetDynamicEvents(true).Where(dynamicEvent => dynamicEvent.MapId == mapId && dynamicEvent.WorldId == worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId)
        {
            return this.GetDynamicEventsByMap(mapId, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByMap(int mapId, int worldId)
        {
            return this.GetDynamicEventsByMap(mapId, worldId, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, bool allowCache)
        {
            return this.GetDynamicEventsByMapAsync(mapId, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsByMapAsync(mapId, cancellationToken);
            }

            return this.GetDynamicEventsAsync(cancellationToken, true)
                       .ContinueWith(task => task.Result.Where(dynamicEvent => dynamicEvent.MapId == mapId), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, bool allowCache)
        {
            return this.GetDynamicEventsByMapAsync(mapId, worldId, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsByMapAsync(mapId, worldId, cancellationToken);
            }

            return
                this.GetDynamicEventsAsync(cancellationToken, true)
                    .ContinueWith(task => task.Result.Where(dynamicEvent => dynamicEvent.MapId == mapId && dynamicEvent.WorldId == worldId), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventsByMapAsync(mapId, cancellationToken, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId)
        {
            return this.GetDynamicEventsByMapAsync(mapId, worldId, CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="mapId">The map filter.</param>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByMapAsync(int mapId, int worldId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventsByMapAsync(mapId, worldId, cancellationToken, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsByWorld(worldId);
            }

            return this.GetDynamicEvents(true).Where(dynamicEvent => dynamicEvent.WorldId == worldId);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public IEnumerable<DynamicEvent> GetDynamicEventsByWorld(int worldId)
        {
            return this.GetDynamicEventsByWorld(worldId, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, bool allowCache)
        {
            return this.GetDynamicEventsByWorldAsync(worldId, CancellationToken.None, allowCache);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken, bool allowCache)
        {
            if (!allowCache)
            {
                return this.fallbackService.GetDynamicEventsByWorldAsync(worldId, cancellationToken);
            }

            return this.GetDynamicEventsAsync(cancellationToken, true)
                       .ContinueWith(task => task.Result.Where(dynamicEvent => dynamicEvent.WorldId == worldId), cancellationToken);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId)
        {
            return this.GetDynamicEventsByWorldAsync(worldId, CancellationToken.None, true);
        }

        /// <summary>Gets a collection of dynamic events and their status.</summary>
        /// <param name="worldId">The world filter.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of dynamic events and their status.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/events">wiki</a> for more information.</remarks>
        public Task<IEnumerable<DynamicEvent>> GetDynamicEventsByWorldAsync(int worldId, CancellationToken cancellationToken)
        {
            return this.GetDynamicEventsByWorldAsync(worldId, cancellationToken, true);
        }

        /// <summary>Sets a collection of dynamic events and their status.</summary>
        /// <param name="dynamicEvents">A collection of dynamic events and their status.</param>
        public void SetDynamicEvents(IEnumerable<DynamicEvent> dynamicEvents)
        {
            var absoluteExpiration = DateTimeOffset.Now.AddMinutes(1D);
            this.SetDynamicEvents(dynamicEvents, new CacheItemParameters { AbsoluteExpiration = absoluteExpiration });
        }

        /// <summary>Sets a collection of dynamic events and their status.</summary>
        /// <param name="dynamicEvents">A collection of dynamic events and their status.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        public void SetDynamicEvents(IEnumerable<DynamicEvent> dynamicEvents, CacheItemParameters parameters)
        {
            this.Set(GetKey(), dynamicEvents, parameters);
        }

        /// <summary>When overridden in a derived class: specifies how to replace a cache entry that expired.</summary>
        /// <param name="cacheItem">The <see cref="CacheItem"/>.</param>
        /// <param name="parameters">The cache entry parameters.</param>
        /// <returns>The replacement <see cref="CacheItem"/>.</returns>
        /// <remarks>Notes to inheritors: returning null for items that were configured to be removable will cause them to be removed.</remarks>
        protected override CacheItem OnExpiring(CacheItem cacheItem, CacheItemParameters parameters)
        {
            cacheItem.Value = this.GetDynamicEvents(allowCache: false);
            parameters.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1D);
            return cacheItem;
        }

        /// <summary>Infrastructure. Gets the cache item key.</summary>
        /// <returns>The key.</returns>
        private static string GetKey()
        {
            return "events";
        }
    }
}