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

namespace GW2DotNET.V1.World
{
    /// <summary>
    /// A class for retrieving information about the
    /// state of world events.
    /// <para></para>
    /// Note that unlike MapData and WorldData, this class does NOT
    /// implement IList. This is intentional, because we do not expose
    /// the event names list to the caller. We only return events objects
    /// that have status information, not just name-id mappings.
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// Cache the event names here
        /// </summary>
        private Dictionary<Guid, string> eventNamesCache = null;

        /// <summary>
        /// The events names will be retrieved in this language
        /// </summary>
        private Language language;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventData"/> class.
        /// This should only be called by WorldManager.
        /// </summary>
        /// <param name="language">The language in which to return names</param>
        internal EventData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets or sets the EventNames dictionary.
        /// The event name list should not be accessed outside of
        /// this class, but we must cache it. We need it
        /// every time event states are retrieved in order to
        /// resolve the IDs to names. Accessing it via this
        /// private property will make sure it's there when
        /// we need it.
        /// </summary>
        private Dictionary<Guid, string> EventNames
        {
            get
            {
                if (this.eventNamesCache == null)
                {
                    var namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("event_names.json", null, ApiCall.Categories.World);

                    // Create a new Dictionary to hold the names,
                    // whereas the key is the event id and the valus the event name.
                    var eventNames = new Dictionary<Guid, string>();

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

                        eventNames.Add(id, name);
                    }
                }

                return this.eventNamesCache;
            }

            set
            {
                this.eventNamesCache = value;
            }
        }

        /// <summary>
        /// Gets all events for a particular world.
        /// </summary>
        /// <param name="world"></param>
        /// <returns>A list of GwEvent items</returns>
        public IList<GwEvent> GetEvents(GwWorld world)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", world.Id)
            };

            var response = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", arguments, ApiCall.Categories.World);

            // Use Linq to match the event ids from the response with the nameResponse 
            // and put them in a list then return them.
            return (from eventsList in response.Values
                    from events in eventsList
                    from eventName in this.EventNames
                    where events.EventId == eventName.Key
                    select new GwEvent(events.WorldId, events.MapId, events.EventId, events.State, eventName.Value)).ToList();
        }

        /// <summary>
        /// Gets a single event from the API.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="eventId">The event id.</param>
        /// <returns>The <see cref="GwEvent"/>.</returns>
        public GwEvent GetEvent(int worldId, Guid eventId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId),
                new KeyValuePair<string, object>("event_id", eventId)
            };

            var eventsResponse = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", arguments, ApiCall.Categories.World);

            GwEvent eventToReturn = new GwEvent();

            foreach (var singleEvent in eventsResponse.Values.SelectMany(variable => variable))
            {
                eventToReturn = new GwEvent(singleEvent.WorldId, singleEvent.MapId, singleEvent.EventId, singleEvent.State, this.EventNames[singleEvent.EventId]);
            }

            return eventToReturn;
        }

        /// <summary>
        /// Gets all events on a specific map.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// ReSharper disable CSharpWarnings::CS1584
        /// <returns>An <see cref="IEnumerable"/> with all events on the specified map.</returns>
        /// ReSharper restore CSharpWarnings::CS1584
        public IList<GwEvent> GetEventsByMap(int worldId, int mapId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId), 
                new KeyValuePair<string, object>("map_id", mapId)
            };

            var eventsResponse = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", arguments, ApiCall.Categories.World);

            // Turn the API events into events with names and return them
            return (from variable in eventsResponse.Values
                    from apiEvent in variable
                    select new GwEvent(apiEvent.WorldId, apiEvent.MapId, apiEvent.EventId, apiEvent.State, this.EventNames[apiEvent.EventId])).ToList();
        }
    }
}
