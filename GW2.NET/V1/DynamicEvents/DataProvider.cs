// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1.DynamicEvents.Models;
using GW2DotNET.V1.Infrastructure;

namespace GW2DotNET.V1.DynamicEvents
{
    /// <summary>The data provider.</summary>
    public class DataProvider : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The event list cache file name.</summary>
        private readonly string eventListCacheFileName;

        /// <summary>Backing field for the event list, so we can replace values.</summary>
        private Lazy<List<GameEvent>> eventList;

        /// <summary>Caching field for the event names. Lazy initialized.</summary>
        private Lazy<Dictionary<Guid, string>> lazyEventNames;

        /// <summary>Caching field for the map names. Lazy initialized.</summary>
        private Lazy<Dictionary<int, string>> lazyMapNames;

        /// <summary>Caching field for the world names. Lazy initialized.</summary>
        private Lazy<Dictionary<int, string>> lazyWorldNames;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public DataProvider(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManager">The api manager.</param>
        /// <param name="bypassCaching">The bypass caching.</param>
        public DataProvider(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCaching;
            this.eventListCacheFileName = string.Format("{0}\\Cache\\EventCache-{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            this.InitializeLazy();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the events.</summary>
        public IEnumerable<GameEvent> EventList
        {
            get
            {
                return this.eventList.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            GameCache<List<GameEvent>> eventCache = new GameCache<List<GameEvent>>()
            {
                Build = this.dataManager.Build,
                CacheData = this.eventList.Value
            };

            this.WriteDataToDisk(this.eventListCacheFileName, eventCache);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public override async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary>Clears the cache.</summary>
        public override void ClearCache()
        {
            this.lazyEventNames = new Lazy<Dictionary<Guid, string>>(this.GetEventNames);
            this.lazyMapNames = new Lazy<Dictionary<int, string>>(this.GetMapNames);
            this.lazyWorldNames = new Lazy<Dictionary<int, string>>(this.GetWorldNames);

            this.eventList = new Lazy<List<GameEvent>>();
        }

        /// <summary>Gets a list of all events from the server.</summary>
        /// <param name="worldId">The id of the world where the events are on.</param>
        /// <param name="mapId">The id of the map where all events are from.</param>
        /// <returns>A <see cref="IEnumerable{GameEvent}">collection</see> of events.</returns>
        public IEnumerable<GameEvent> GetEventList(int worldId = -1, int mapId = -1)
        {
            List<KeyValuePair<string, object>> args = this.CreateArgumentsForEventListQuery(worldId, mapId);

            IEnumerable<GameEvent> response = ApiCall.GetContent<Dictionary<string, IEnumerable<GameEvent>>>("events.json", args, ApiCall.Categories.DynamicEvents)["events"].ToList();

            List<GameEvent> resolvedEvents = this.ResolveNames(response).ToList();

            if (!this.BypassCache)
            {
                this.eventList.Value.AddRange(resolvedEvents);
            }

            return resolvedEvents;
        }

        /// <summary>Asynchronously gets a list of all events from the server.</summary>
        /// <param name="worldId">The id of the world where the events are on.</param>
        /// <param name="mapId">The id of the map where all events are from.</param>
        /// <returns>A <see cref="IEnumerable{GameEvent}">collection</see> of events.</returns>
        public async Task<IEnumerable<GameEvent>> GetEventListAsync(int worldId = -1, int mapId = -1)
        {
            List<KeyValuePair<string, object>> args = this.CreateArgumentsForEventListQuery(worldId, mapId);

            Dictionary<string, IEnumerable<GameEvent>> response = await ApiCall.GetContentAsync<Dictionary<string, IEnumerable<GameEvent>>>("events.json", args, ApiCall.Categories.DynamicEvents);

            List<GameEvent> resolvedEvents = this.ResolveNames(response["events"]).ToList();

            if (!this.BypassCache)
            {
                this.eventList.Value.AddRange(resolvedEvents);
            }

            return resolvedEvents;
        }

        /// <summary>Gets the details for a particular event.</summary>
        /// <param name="gameEvent">The game event to get the details.</param>
        /// <returns>A <see cref="GameEvent"/> with all details.</returns>
        public GameEvent GetEventDetails(GameEvent gameEvent)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("event_id", gameEvent.EventId),
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            // Get the event details from the server.
            // As return json is heavily nested we have to use
            // a Dictionary<string, Dictionary<Guid, GameEvent>>
            // to deserialize properly (srsly ANet, why?)
            var apiEvent = ApiCall.GetContent<Dictionary<string, Dictionary<Guid, GameEvent>>>("event_details.json", args, ApiCall.Categories.DynamicEvents)["events"][gameEvent.EventId];

            // Transfer the details to the event the user supplied and return it.
            gameEvent.Name = apiEvent.Name;
            gameEvent.Level = apiEvent.Level;
            gameEvent.Flags = apiEvent.Flags;
            gameEvent.Location = apiEvent.Location;

            return gameEvent;
        }

        /// <summary>Gets the details for a particular event asynchronously.</summary>
        /// <param name="gameEvent">The game event to get the details.</param>
        /// <returns>The <see cref="Task{GameEvent}"/> with all details..</returns>
        public async Task<GameEvent> GetEventDetailsAsync(GameEvent gameEvent)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("event_id", gameEvent.EventId),
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            // Get the event details from the server.
            // As return json is heavily nested we have to use
            // a Dictionary<string, Dictionary<Guid, GameEvent>>
            // to deserialize properly (srsly ANet, why?)
            Dictionary<string, Dictionary<Guid, GameEvent>> returnTask = await ApiCall.GetContentAsync<Dictionary<string, Dictionary<Guid, GameEvent>>>("event_details.json", args, ApiCall.Categories.DynamicEvents);

            // Store the return in a task, as we cannot use indexers with await
            GameEvent apiEvent = returnTask["events"][gameEvent.EventId];

            // Transfer the details to the event the user supplied and return it.
            gameEvent.Name = apiEvent.Name;
            gameEvent.Level = apiEvent.Level;
            gameEvent.Flags = apiEvent.Flags;
            gameEvent.Location = apiEvent.Location;

            return gameEvent;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Private Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Creates a <see cref="List{T}"/> containing <see cref="KeyValuePair{TKey,TValue}"/>s as arguments for the event list query.</summary>
        /// <param name="worldId">The world id.</param>
        /// <param name="mapId">The map id.</param>
        /// <returns>The <see cref="List{T}"/> with all arguments.</returns>
        /// <exception cref="ArgumentException">Thrown when both parameters are at their default value, -1.</exception>
        private List<KeyValuePair<string, object>> CreateArgumentsForEventListQuery(int worldId, int mapId)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>();

            // Add the arguments to a list
            if (worldId == -1 && mapId == -1)
            {
                throw new ArgumentException(
                    "Due to a bug, or limitations in the Guild Wars 2 API the events node will return a faulty JSON string. Therefore at least one parameter has to be specified.");
            }
            else if (worldId == -1)
            {
                args.Add(new KeyValuePair<string, object>("map_id", mapId));
            }
            else if (mapId == -1)
            {
                args.Add(new KeyValuePair<string, object>("world_id", worldId));
            }
            else
            {
                args.Add(new KeyValuePair<string, object>("map_id", mapId));
                args.Add(new KeyValuePair<string, object>("world_id", worldId));
            }

            return args;
        }

        /// <summary>Resolves the event-, map- and world-names of an event collection.</summary>
        /// <param name="events">The collection of events.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> which has all it's names resolved..</returns>
        private IEnumerable<GameEvent> ResolveNames(IEnumerable<GameEvent> events)
        {
            List<GameEvent> eventsToReturn = new List<GameEvent>();

            //// Add the names to the events list.
            foreach (GameEvent gameEvent in events)
            {
                // ReSharper disable AccessToForEachVariableInClosure
                foreach (KeyValuePair<Guid, string> pair in this.lazyEventNames.Value.Where(pair => pair.Key == gameEvent.EventId))
                {
                    gameEvent.Name = pair.Value;
                }

                foreach (KeyValuePair<int, string> pair in this.lazyMapNames.Value.Where(pair => pair.Key == gameEvent.Map.Id))
                {
                    gameEvent.Map.Name = pair.Value;
                }

                foreach (
                    KeyValuePair<int, string> pair in this.lazyWorldNames.Value.Where(pair => pair.Key == gameEvent.World.Id))
                {
                    gameEvent.World.Name = pair.Value;
                }
                //// ReSharper restore AccessToForEachVariableInClosure

                eventsToReturn.Add(gameEvent);
            }

            return eventsToReturn;
        }

        /// <summary>Gets the world names from the server.</summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> containing all world names.</returns>
        private Dictionary<int, string> GetWorldNames()
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            // Get the response.
            List<Dictionary<string, string>> namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("world_names.json", args, ApiCall.Categories.DynamicEvents);

            return this.CleanResponse<Dictionary<int, string>>(namesResponse);
        }

        /// <summary>Gets the map names from the server.</summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> containing all map names.</returns>
        private Dictionary<int, string> GetMapNames()
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            // Get the response.
            List<Dictionary<string, string>> namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("map_names.json", args, ApiCall.Categories.DynamicEvents);

            return this.CleanResponse<Dictionary<int, string>>(namesResponse);
        }

        /// <summary>Gets the event names from the server.</summary>
        /// <returns>A <see cref="Dictionary{TKey,TValue}"/> containing all the event names.</returns>
        private Dictionary<Guid, string> GetEventNames()
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            // Get the response.
            List<Dictionary<string, string>> namesResponse = ApiCall.GetContent<List<Dictionary<string, string>>>("event_names.json", args, ApiCall.Categories.DynamicEvents);

            return this.CleanResponse<Dictionary<Guid, string>>(namesResponse);
        }

        /// <summary>Cleans the input of the surrounding </summary>
        /// <param name="dictionaryList">The dictionary list.</param>
        /// <typeparam name="T">A collection implementing the <see cref="IDictionary"/> interface.</typeparam>
        /// <returns>A cleaned <see cref="T"/>.</returns>
        private T CleanResponse<T>(IEnumerable<Dictionary<string, string>> dictionaryList) where T : IDictionary
        {
            Type dictType = typeof(T);

            T cacheDictionary = (T)Activator.CreateInstance(dictType);

            foreach (Dictionary<string, string> dictionary in dictionaryList)
            {
                Type keyType = cacheDictionary.GetType().GetGenericArguments()[0];

                string id = string.Empty;
                string name = string.Empty;

                foreach (KeyValuePair<string, string> keyValuePair in dictionary)
                {
                    if (keyValuePair.Key == "id")
                    {
                        id = keyValuePair.Value;
                    }
                    else
                    {
                        name = keyValuePair.Value;
                    }
                }

                if (keyType == typeof(Guid))
                {
                    cacheDictionary.Add(new Guid(id), name);
                }
                else if (keyType == typeof(int))
                {
                    cacheDictionary.Add(int.Parse(id), name);
                }
            }

            return cacheDictionary;
        }

        /// <summary>Initializes the lazy fields.</summary>
        private void InitializeLazy()
        {
            this.lazyEventNames = new Lazy<Dictionary<Guid, string>>(this.GetEventNames);
            this.lazyMapNames = new Lazy<Dictionary<int, string>>(this.GetMapNames);
            this.lazyWorldNames = new Lazy<Dictionary<int, string>>(this.GetWorldNames);

            int build;

            this.eventList = !this.BypassCache ? new Lazy<List<GameEvent>>(() => this.ReadCacheFromDisk<List<GameEvent>>(this.eventListCacheFileName, out build)) : new Lazy<List<GameEvent>>();
        }
    }
}