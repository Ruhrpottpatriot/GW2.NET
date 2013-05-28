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

using GW2DotNET.V1.Infrastructure;
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
    public class EventData : IEnumerable<GwEvent>
    {
        /// <summary>
        /// Keep a pointer to our WorldManager here for ID resolution.
        /// </summary>
        private readonly WorldManager wm;

        /// <summary>
        /// The events names will be retrieved in this language
        /// </summary>
        private readonly Language language;

        /// <summary>
        /// Cache the event names here
        /// </summary>
        private Dictionary<Guid, string> eventNamesCache;

        /// <summary>
        /// The event cache.
        /// </summary>
        private IEnumerable<GwEvent> eventCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventData"/> class.
        /// This should only be called by WorldManager.
        /// </summary>
        /// <param name="language">The language in which to return names</param>
        /// <param name="wm">An instance of WorldManager to use for ID resolution</param>
        internal EventData(Language language, WorldManager wm)
        {
            this.language = language;
            this.wm = wm;
        }

        /// <summary>
        /// Gets or sets the world.
        /// </summary>
        public GwWorld World { get; set; }

        /// <summary>
        /// Gets the events.
        /// </summary>
        public IEnumerable<GwEvent> Events
        {
            get
            {
                if (this.eventCache == null)
                {
                    if (this.World.Id == 0)
                    {
                        this.eventCache = this.GetAllEvents();

                        return this.eventCache;
                    }

                    this.eventCache = this.GetEvents(this.World);
                }

                return this.eventCache;
            }
        }

        /// <summary>
        /// Gets the EventNames dictionary.
        /// This is not exposed to callers. It is for internal
        /// usage only.
        /// </summary>
        private Dictionary<Guid, string> EventNames
        {
            get
            {
                if (this.eventNamesCache == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                                        {
                                            new KeyValuePair<string, object>(
                                                "lang", this.language)
                                        };

                    var namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("event_names.json", arguments, ApiCall.Categories.World);

                    // Create a new Dictionary to hold the names,
                    // whereas the key is the event id and the valus the event name.
                    this.eventNamesCache = new Dictionary<Guid, string>();

                    // Iterate through the namesResponse,
                    // so we can throw away that damn List<Dictionary<string,string>>! *blargh*
                    foreach (var eventName in namesResponse)
                    {
                        Guid id = new Guid();
                        string name = string.Empty;

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

                return this.eventNamesCache;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<GwEvent> GetEnumerator()
        {
            return this.Events.GetEnumerator();
        }
        
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Events.GetEnumerator();
        }

        /// <summary>
        /// Gets all events for a particular world.
        /// </summary>
        /// <param name="world">The world for which to retrieve events</param>
        /// <returns>A list of events</returns>
        private IEnumerable<GwEvent> GetEvents(GwWorld world)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                                        new KeyValuePair<string, object>(
                                            "world_id", world.Id)
            };
            var response = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", arguments, ApiCall.Categories.World);

            return (from eventsList in response.Values
                    from events in eventsList
                    from eventName in this.EventNames
                    where events.EventId == eventName.Key
                    select this.GetResolvedEvent(events)).ToList();
        }

        /// <summary>
        /// Gets a single event from the API.
        /// </summary>
        /// <param name="world">The world id.</param>
        /// <param name="eventId">The event id.</param>
        /// <returns>The <see cref="GwEvent"/>.</returns>
        private GwEvent GetEvent(GwWorld world, Guid eventId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", world.Id),
                new KeyValuePair<string, object>("event_id", eventId)
            };

            var eventsResponse = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", arguments, ApiCall.Categories.World);

            GwEvent eventToReturn = new GwEvent();

            foreach (var singleEvent in eventsResponse.Values.SelectMany(variable => variable))
            {
                eventToReturn = this.GetResolvedEvent(singleEvent);
            }

            return eventToReturn;
        }

        /// <summary>
        /// Gets all events on a specific map.
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="map">The map</param>
        /// <returns>An <see cref="T:System.Collections.IEnumerable"/> with all events on the specified map.</returns>
        private IEnumerable<GwEvent> GetEventsByMap(GwWorld world, GwMap map)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", world.Id), 
                new KeyValuePair<string, object>("map_id", map.Id)
            };

            var eventsResponse = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", arguments, ApiCall.Categories.World);

            // Turn the API events into events with names and return them
            return (from variable in eventsResponse.Values
                    from apiEvent in variable
                    select this.GetResolvedEvent(apiEvent)).ToList();
        }

        /// <summary>
        /// Gets all events for all maps on all worlds.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerable"/></returns>
        private IEnumerable<GwEvent> GetAllEvents()
        {
            var eventsResponse = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", new List<KeyValuePair<string, object>>(), ApiCall.Categories.World);

            // Turn the API events into events with names and return them
            return (from variable in eventsResponse.Values
                    from apiEvent in variable
                    select this.GetResolvedEvent(apiEvent)).ToList();
        }

        /// <summary>
        /// Returns a GwEvent that has all ID properties resolved
        /// and has the event name set.
        /// </summary>
        /// <param name="unresolvedEvent">A GwEvent object</param>
        /// <returns>A GwEvent with IDs resolved</returns>
        private GwEvent GetResolvedEvent(GwEvent unresolvedEvent)
        {
            return new GwEvent(
                    unresolvedEvent.WorldId,
                    unresolvedEvent.MapId,
                    unresolvedEvent.EventId,
                    unresolvedEvent.State,
                    this.wm.Events.EventNames[unresolvedEvent.EventId],
                    this.wm.Worlds[unresolvedEvent.WorldId],
                    this.wm.Maps[unresolvedEvent.MapId]);
        }
    }
}
