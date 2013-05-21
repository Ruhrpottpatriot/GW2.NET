// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldEventData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldEventData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;

using GW2DotNET.Models;

using Newtonsoft.Json.Linq;

namespace GW2DotNET.Events
{
    public class EventData
    {
        public IEnumerable<GwEvent> GetEvents(int worldId)
        {
            var jsonString = new WebClient().DownloadString("https://api.guildwars2.com/v1/events.json?world_id=" + worldId);

            var events = (JArray)JObject.Parse(jsonString)["events"];

            return from gwEvent in events
                   let world = int.Parse((string)gwEvent["world_id"])
                   let mapId = int.Parse((string)gwEvent["map_id"])
                   let eventId = (string)gwEvent["event_id"]
                   let state = (string)gwEvent["state"]
                   select new GwEvent(world, mapId, eventId, state);
        }

        public GwEvent GetEvet(int worldId, string eventId)
        {
            var jsonString = new WebClient().DownloadString("https://api.guildwars2.com/v1/events.json?world_id=" + worldId + @"&event_id=" + eventId);

            var events = (JArray)JObject.Parse(jsonString)["events"];

            var eGwEvent = events.Select(gwEvent => new GwEvent(int.Parse((string)gwEvent["world_id"]), int.Parse((string)gwEvent["map_id"]), (string)gwEvent["event_id"], (string)gwEvent["state"])).ToList().Single();

            return eGwEvent;
        }

        public IEnumerable<GwEvent> GetEventsByMap(int worldId, int mapId)
        {
            var jsonString = new WebClient().DownloadString("https://api.guildwars2.com/v1/events.json?world_id=" + worldId + @"&map_id=" + mapId);

            var events = (JArray)JObject.Parse(jsonString)["events"];

            return events.Select(gwEvent => new GwEvent(int.Parse((string)gwEvent["world_id"]), int.Parse((string)gwEvent["map_id"]), (string)gwEvent["event_id"], (string)gwEvent["state"]));
        }
    }
}
