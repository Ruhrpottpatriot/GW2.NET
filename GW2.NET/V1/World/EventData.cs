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
    internal class EventData
    {
        internal IList<GwEvent> GetEvents(int worldId)
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", worldId)
            };

            var response = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", arguments, ApiCall.Categories.World);

            var namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("event_names.json", null, ApiCall.Categories.World);

            // Create a new Dictionary tol hold the names,
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


            // Use Linq to match the event ids from the response with the nameResponse 
            // and put them in a list then return them.
            return (from eventsList in response.Values
                    from events in eventsList
                    from eventName in eventNames
                    where events.EventId == eventName.Key
                    select new GwEvent(events.WorldId, events.MapId, events.EventId, events.State, eventName.Value)).ToList();
        }

        internal IList<GwEvent> GetEvents(GwWorld world)
        {
            return this.GetEvents(world.Id);
        }
    }
}
