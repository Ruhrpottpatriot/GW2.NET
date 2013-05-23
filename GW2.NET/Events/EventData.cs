﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldEventData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using GW2DotNET.Events.Models;
using GW2DotNET.Infrastructure;

using RestSharp;

namespace GW2DotNET.Events
{
    /// <summary>
    /// Contains methods to get the data of the already discovered events in the game.
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// Keep a single instance of the class here.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Upper case letter would conflict with a property defined below.")]
        // ReSharper disable InconsistentNaming
        private static readonly EventData instance = new EventData();
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// The RestSharp client used for all API requests
        /// </summary>
        private readonly RestClient restClient = new RestClient("https://api.guildwars2.com/v1/");

        /// <summary>
        /// We cache the event_names response here
        /// </summary>
        private List<APIEventName> eventNames;

        /// <summary>
        /// We also cache the event_names here as a dictionary
        /// </summary>
        private Dictionary<Guid, string> eventNamesDictionary;

        /// <summary>
        /// Prevents a default instance of the <see cref="EventData"/> class from being created. 
        /// Callers cannot directly instantiate this class. They must request an instance. 
        /// This ensures that the cached data is used efficiently.
        /// </summary>
        private EventData()
        {
        }

        /// <summary>
        /// Gets an EventData instance
        /// </summary>
        public static EventData Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the event names.
        /// </summary>
        public List<APIEventName> EventNames
        {
            get
            {
                if (this.eventNames == null)
                {
                    RestRequest eventNamesRequest = new RestRequest("event_names.json", Method.GET);
                    IRestResponse<List<APIEventName>> eventNamesResponse = this.restClient.Execute<List<APIEventName>>(eventNamesRequest);
                    this.eventNames = eventNamesResponse.Data;
                }

                return this.eventNames;
            }
        }

        /// <summary>
        /// Gets the event IDs mapped to their respective names.
        /// </summary>
        public Dictionary<Guid, string> EventNamesDictionary
        {
            get
            {
                if (this.eventNamesDictionary == null)
                {
                    this.eventNamesDictionary = new Dictionary<Guid, string>();

                    foreach (var eventName in this.EventNames)
                    {
                        this.eventNamesDictionary.Add(eventName.id, eventName.name);
                    }
                }

                return this.eventNamesDictionary;
            }
        }

        /// <summary>
        /// Gets all the events on the specified world.
        /// </summary>
        /// <param name="worldId">The id of the world. </param>
        /// ReSharper disable CSharpWarnings::CS1584
        /// <returns>An <see cref="IEnumerable"/> with all the events on the specified world.</returns>
        /// ReSharper restore CSharpWarnings::CS1584
        public IEnumerable<GwEvent> GetEvents(int worldId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId)
            };

            IRestResponse<Dictionary<string, List<APIEvent>>> eventsResponse = ApiCall.CallApi<Dictionary<string, List<APIEvent>>>("events.json", arguments);

            // Turn the API events into events with names
            return eventsResponse.Data["events"].Select(apiEvent => new GwEvent(apiEvent, this.EventNamesDictionary[apiEvent.event_id])).ToList();
        }

        /// <summary>
        /// Gets a single event from the api.
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

            IRestResponse<Dictionary<string, List<APIEvent>>> eventsResponse = ApiCall.CallApi<Dictionary<string, List<APIEvent>>>("events.json", arguments);

            // Turn the API events into events with names
            List<GwEvent> eventsToReturn = eventsResponse.Data["events"].Select(apiEvent => new GwEvent(apiEvent, this.EventNamesDictionary[apiEvent.event_id])).ToList();

            // There should only be one, so just return the first element.
            return eventsToReturn.Single();
        }

        /// <summary>
        /// Gets all events on a specific map.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// ReSharper disable CSharpWarnings::CS1584
        /// <returns>An <see cref="IEnumerable"/> with all events on the specified map.</returns>
        /// ReSharper restore CSharpWarnings::CS1584
        public IEnumerable<GwEvent> GetEventsByMap(int worldId, int mapId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId), 
                new KeyValuePair<string, object>("map_id", mapId)
            };

            IRestResponse<Dictionary<string, List<APIEvent>>> eventsResponse = ApiCall.CallApi<Dictionary<string, List<APIEvent>>>("events.json", arguments);

            // Turn the API events into events with names
            return eventsResponse.Data["events"].Select(apiEvent => new GwEvent(apiEvent)
                {
                    Name = this.EventNamesDictionary[apiEvent.event_id]
                }).ToList();
        }
    }
}