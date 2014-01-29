// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the DataProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Events.Models;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Infrastructure.Exceptions;
using GW2DotNET.V1.Infrastructure.Extensions;

namespace GW2DotNET.V1.Events
{
    /// <summary>The data provider for the event api.</summary>
    public class DataProvider
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        private readonly IApiManager apiManager;

        private IEnumerable<GwEvent> events;

        private Dictionary<Guid, string> eventNames;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors and Destructors
        // --------------------------------------------------------------------------------------------------------------------

        public DataProvider(IApiManager apiManager, bool bypassCache = false)
        {
            this.BypassCache = bypassCache;
            this.apiManager = apiManager;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        public bool BypassCache { get; set; }

        public IEnumerable<GwEvent> Events
        {
            get
            {
                if (this.events.IsNullOrEmpty())
                {
                    throw new NoDataDownloadedException("No data was downloaded. Use the appropiate data fetching method first.");
                }

                return this.events;
            }
        }


        public IEnumerable<GwEvent> GetEventsAsync()
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("world_id", "1001")
            };


            var eventList =
                ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", null, ApiCall.Categories.DynamicEvents)["events"];

            this.GetEventNames();


            return eventList
                    .SelectMany(gameEvent => this.eventNames, (gameEvent, eventName) => new { gameEvent, eventName })
                    .Where(evnt => evnt.eventName.Key == evnt.gameEvent.EventId)
                    .Select(
                        evnt =>
                            new GwEvent(evnt.gameEvent.WorldId, evnt.gameEvent.MapId, evnt.gameEvent.EventId, evnt.gameEvent.State)
                            {
                                Name = evnt.eventName.Value
                            });
        }

        private void GetEventNames()
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.apiManager.Language)
            };

            var namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("event_names.json", null, ApiCall.Categories.DynamicEvents);

            // Create a new Dictionary to hold the names,
            // whereas the key is the event id and the valus the event name.
            var cacheData = new Dictionary<Guid, string>();

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

                cacheData.Add(id, name);
            }

            this.eventNames = cacheData;

        }
    }
}
