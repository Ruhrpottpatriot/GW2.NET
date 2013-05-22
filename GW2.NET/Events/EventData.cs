﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldEventData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using GW2DotNET.Events.Models;
using GW2DotNET.Infrastructure;

using Newtonsoft.Json.Linq;

namespace GW2DotNET.Events
{
    /// <summary>
    /// Contains methods to get the data of the already discovered events in the game.
    /// </summary>
    public class EventData
    {
        /// <summary>
        /// Gets all the events on the specified world.
        /// </summary>
        /// <param name="worldId">The id of the world. </param>
        /// <returns>An <see cref="IEnumerable"/> with all the events on the specified world.</returns>
        public IEnumerable<GwEvent> GetEvents(int worldId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId)
            };

            var jsonString1 = ApiCall.CallApi("events.json", arguments);

            var jsonString2 = ApiCall.CallApi("event_names.json", null);

            var events = (JArray)JObject.Parse(jsonString1)["events"];

            var eventNames = JArray.Parse(jsonString2);

            return (from gwEvent in events
                    from eventName in eventNames
                    where (string)eventName["id"] == (string)gwEvent["event_id"]
                    select new GwEvent(int.Parse((string)gwEvent["world_id"]), int.Parse((string)gwEvent["map_id"]), (string)gwEvent["event_id"], (string)gwEvent["state"], (string)eventName["name"])).ToList();
        }

        /// <summary>
        /// Gets a single event from the api.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="eventId">The event id.</param>
        /// <returns>The <see cref="GwEvent"/>.</returns>
        public GwEvent GetEvet(int worldId, string eventId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId),
                new KeyValuePair<string, object>("event_id", eventId)
            };

            var jsonString = ApiCall.CallApi("events.json", arguments);

            var events = (JArray)JObject.Parse(jsonString)["events"];

            return events.Select(e => new GwEvent(int.Parse((string)e["world_id"]), int.Parse((string)e["map_id"]), (string)e["event_id"], (string)e["state"], string.Empty)).ToList().Single();
        }

        /// <summary>
        /// Gets all events on a specific map.
        /// </summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// <returns>An <see cref="IEnumerable"/> with all events on the specified map.</returns>
        public IEnumerable<GwEvent> GetEventsByMap(int worldId, int mapId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId),
                new KeyValuePair<string, object>("map_id", mapId)
            };

            var jsonString = ApiCall.CallApi("events.json", arguments);

            var events = (JArray)JObject.Parse(jsonString)["events"];

            return events.Select(gwEvent => new GwEvent(int.Parse((string)gwEvent["world_id"]), int.Parse((string)gwEvent["map_id"]), (string)gwEvent["event_id"], (string)gwEvent["state"], string.Empty));
        }
    }
}