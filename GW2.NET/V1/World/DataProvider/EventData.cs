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
        /// Gets the EventNames dictionary.
        /// This is not exposed to callers. It is for internal
        /// usage only.
        /// </summary>
        internal Dictionary<Guid, string> EventNames
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
                        var id = new Guid();
                        
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
        /// Gets the events.
        /// </summary>
        private IEnumerable<GwEvent> Events
        {
            get
            {
                return this.eventCache ?? (this.eventCache = this.GetAllEvents());
            }
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
                return this.Events.Where(e => e.World == world);
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
        /// Gets all events for all maps on all worlds.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerable"/></returns>
        private IEnumerable<GwEvent> GetAllEvents()
        {
            var response = ApiCall.GetContent<Dictionary<string, List<GwEvent>>>("events.json", new List<KeyValuePair<string, object>>(), ApiCall.Categories.World);

            // Turn the API events into events with names and return them
            return response["events"].Select(gwEvent => gwEvent.ResolveName(this.wm)).ToList();
        }
    }
}
