// ----------------------------------public ----------------------------------------------------------------------------------
// <copyright file="EventData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Maps.Models;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World.DataProvider
{
    using System.Collections;

    /// <summary>
    /// A class for retrieving information about the
    /// state of world events.
    /// </summary>
    /// <remarks>
    /// Note that unlike MapData and WorldData, this class does NOT
    /// implement IEnumerable. This is intentional, because we do not expose
    /// the event names list to the caller. We only return events objects
    /// that have status information, not just name-id mappings.
    /// </remarks>
    public partial class EventData : IEnumerable<GwEvent>
    {
        /// <summary>
        /// Keep a pointer to our WorldManager here for ID resolution.
        /// </summary>
        private readonly ApiManager apiManager;

        /// <summary>
        /// Cache the event names here
        /// </summary>
        private Dictionary<Guid, string> eventNamesCache;

        /// <summary>
        /// Sync object for thread safety. You MUST lock this
        /// object before touching the private eventNamesCache object.
        /// </summary>
        private readonly object eventNamesCacheSyncObject = new object();

        /// <summary>The events cache.</summary>
        private IEnumerable<GwEvent> eventsCache;

        /// <summary>
        /// Sync object for thread safety. You MUST lock this
        /// object before touching the private eventsCache object.
        /// </summary>
        private readonly object eventsCacheSyncObject = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventData"/> class.
        /// This should only be called by WorldManager.
        /// </summary>
        /// <param name="apiManager">An instance of GW2ApiManager to use for ID resolution</param>
        internal EventData(ApiManager apiManager)
        {
            this.apiManager = apiManager;
            this.BypassCaching = false;
        }

        /// <summary>Gets or sets a value indicating whether to bypass caching.</summary>
        public bool BypassCaching
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the EventNames dictionary.
        /// This is not exposed to callers. It is for internal
        /// usage only.
        /// </summary>
        internal Dictionary<Guid, string> EventNames
        {
            get
            {
                lock (eventNamesCacheSyncObject)
                {
                    if (this.eventNamesCache == null)
                    {
                        var arguments = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>(
                                    "lang", this.apiManager.Language)
                            };

                        var namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("event_names.json",
                                                                                                 arguments,
                                                                                                 ApiCall.Categories
                                                                                                        .World);

                        // Create a new Dictionary to hold the names,
                        // whereas the key is the event id and the valus the event name.
                        this.eventNamesCache = new Dictionary<Guid, string>();

                        // Iterate through the namesResponse,
                        // so we can throw away that damn List<Dictionary<string,string>>! *blargh*
                        foreach (var eventName in namesResponse)
                        {
                            var id = new Guid();

                            var name = string.Empty;

                            foreach (var variable in eventName)
                            {
                                if (variable.Key == "id")
                                {
                                    id = new Guid(variable.Value);
                                }
                                else
                                {
                                    name = variable.Value;
                                }
                            }

                            this.eventNamesCache.Add(id, name);
                        }
                    }
                }

                return this.eventNamesCache;
            }
        }

        /// <summary>
        /// Gets the events.
        /// </summary>
        private IEnumerable<GwEvent> AllEvents
        {
            get
            {
                if (this.BypassCaching)
                {
                    return this.GetEvents();
                }

                lock (eventsCacheSyncObject)
                {
                    return this.eventsCache ?? (this.eventsCache = this.GetEvents());
                }
            }
        }

        /// <summary>
        /// Gets all events asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<GwEvent>> GetAllEventsAsync(CancellationToken cancellationToken)
        {
            Func<IEnumerable<GwEvent>> methodCall = () => this.AllEvents;

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of <see cref="GwEvent"/>s pre-sorted with a <see cref="GwWorld"/>.
        /// </summary>
        /// <param name="world">The world to pre-sort the events.</param>
        /// <returns>The collection of events.</returns>
        public IEnumerable<GwEvent> this[GwWorld world]
        {
            get
            {
                if (this.BypassCaching)
                {
                    return this.GetEvents(world.Id);
                }

                lock (eventsCacheSyncObject)
                {
                    if (this.eventsCache == null)
                    {
                        this.eventsCache = this.GetEvents();
                    }
                }

                return this.eventsCache.Where(w => w.World == world);
            }
        }

        /// <summary>
        /// Gets all events for a given world asynchronously.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<GwEvent>> GetEventsFromWorldAsync(GwWorld world, CancellationToken cancellationToken)
        {
            Func<IEnumerable<GwEvent>> methodCall = () => this[world];

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>
        /// Gets all events for a particular map on all worlds.
        /// </summary>
        /// <param name="map">The map to get all events from.</param>
        /// <returns>A collection of events on the specified map.</returns>
        public IEnumerable<GwEvent> this[Map map]
        {
            get
            {
                if (this.BypassCaching)
                {
                    return this.GetEvents(mapId: map.Id);
                }

                lock (eventsCacheSyncObject)
                {
                    if (this.eventsCache == null)
                    {
                        this.eventsCache = this.GetEvents();
                    }
                }

                return this.eventsCache.Where(e => e.Map == map);
            }
        }

        /// <summary>
        /// Gets all events for a given map on all worlds asynchronously.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<GwEvent>> GetEventsFromMapAsync(Map map, CancellationToken cancellationToken)
        {
            Func<IEnumerable<GwEvent>> methodCall = () => this[map];

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>
        /// Gets one event for all worlds.
        /// </summary>
        /// <param name="eventId">The id of the event to retrieve.</param>
        /// <returns>A collection of events with the specified event id.</returns>
        public IEnumerable<GwEvent> this[Guid eventId]
        {
            get
            {
                if (this.BypassCaching)
                {
                    return this.GetEvents(eventId: eventId);
                }

                lock (eventsCacheSyncObject)
                {
                    if (this.eventsCache == null)
                    {
                        this.eventsCache = this.GetEvents();
                    }
                }

                return this.eventsCache.Where(e => e.EventId == eventId);
            }
        }

        /// <summary>
        /// Gets one event from all worlds asynchronously.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<GwEvent>> GetEventsFromIdAsync(Guid eventId, CancellationToken cancellationToken)
        {
            Func<IEnumerable<GwEvent>> methodCall = () => this[eventId];

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<GwEvent> GetEnumerator()
        {
            return this.AllEvents.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AllEvents.GetEnumerator();
        }

        /// <summary>Gets all events for all maps on all worlds.</summary>
        /// <param name="worldId">The world Id.</param>
        /// <param name="mapId">The map Id.</param>
        /// <param name="eventId">The event Id.</param>
        /// <returns>An <see cref="T:System.Collections.IEnumerable"/></returns>
        private IEnumerable<GwEvent> GetEvents(int? worldId = null, int? mapId = null, Guid? eventId = null)
        {
            var parameters = new List<KeyValuePair<string, object>>();

            if (worldId != null)
            {
                parameters.Add(new KeyValuePair<string, object>("world_id", worldId));
            }

            if (mapId != null)
            {
                parameters.Add(new KeyValuePair<string, object>("map_id", mapId));
            }

            if (eventId != null)
            {
                parameters.Add(new KeyValuePair<string, object>("event_id", eventId));
            }

            return ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", parameters, ApiCall.Categories.World)["events"].Select(evnt => evnt.ResolveIDs(this.apiManager));
        }
    }
}
