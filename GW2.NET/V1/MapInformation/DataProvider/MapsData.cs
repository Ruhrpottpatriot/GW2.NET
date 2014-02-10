// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the api manager with the maps data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.MapInformation.Models;

namespace GW2DotNET.V1.MapInformation.DataProvider
{
    /// <summary>Provides the api manager with the maps data.</summary>
    public class MapsData : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The maps cache file name.</summary>
        private readonly string mapsCacheFileName;

        /// <summary>The maps.</summary>
        private Lazy<List<Map>> mapsCache;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="MapsData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public MapsData(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapsData"/> class.</summary>
        /// <param name="dataManager">The data manger.</param>
        /// <param name="bypassCaching">A value indicating whether to bypass caching.</param>
        internal MapsData(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCaching;
            this.mapsCacheFileName = string.Format("{0}\\Cache\\MapsCache-{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            int build;

            this.mapsCache = !this.BypassCache ? new Lazy<List<Map>>(() => this.ReadCacheFromDisk<List<Map>>(this.mapsCacheFileName, out build)) : new Lazy<List<Map>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the map list.</summary>
        public IEnumerable<Map> MapList
        {
            get
            {
                return this.mapsCache.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            GameCache<IEnumerable<Map>> mapCache = new GameCache<IEnumerable<Map>>
            {
                Build = this.dataManager.Build,
                CacheData = this.mapsCache.Value
            };

            this.WriteDataToDisk(this.mapsCacheFileName, mapCache);
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
            this.mapsCache = new Lazy<List<Map>>();
        }

        /// <summary>Calls the GW2 api to get a list of maps asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/>containing all maps.</returns>
        public async Task<IEnumerable<Map>> GetMapListAsync()
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>("lang", this.dataManager.Language)
                            };

            Dictionary<string, Dictionary<int, Map>> returnContent = await ApiCall.GetContentAsync<Dictionary<string, Dictionary<int, Map>>>("maps.json", args, ApiCall.Categories.World);

            Dictionary<int, Map> mapsDictionary = returnContent.Values.First();

            List<Map> maps = this.ResolveId(mapsDictionary);

            if (!this.BypassCache)
            {
                this.mapsCache.Value.AddRange(maps);
            }

            return maps;
        }

        /// <summary>Calls the GW2 api to get a list of maps synchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/>containing all maps.</returns>
        public IEnumerable<Map> GetMapList()
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>("lang", this.dataManager.Language)
                            };

            Dictionary<string, Dictionary<int, Map>> returnContent = ApiCall.GetContent<Dictionary<string, Dictionary<int, Map>>>("maps.json", args, ApiCall.Categories.World);

            Dictionary<int, Map> mapsDictionary = returnContent.Values.First();

            List<Map> maps = this.ResolveId(mapsDictionary);

            if (!this.BypassCache)
            {
                this.mapsCache.Value.AddRange(maps);
            }

            return maps;
        }

        /// <summary>Calls the GW2 api to get a single map asynchronously</summary>
        /// <param name="mapId">The id of the map to get.</param>
        /// <returns>The <see cref="Map"/> with the specified id.</returns>
        public async Task<Map> GetMapAsync(int mapId)
        {
            if (!this.BypassCache)
            {
                return this.mapsCache.Value.SingleOrDefault(map => map.Id == mapId);
            }

            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>("lang", this.dataManager.Language),
                                new KeyValuePair<string, object>("map_id", mapId)
                            };

            Dictionary<string, Dictionary<int, Map>> returnContent = await ApiCall.GetContentAsync<Dictionary<string, Dictionary<int, Map>>>("maps.json", args, ApiCall.Categories.World);

            Dictionary<int, Map> mapsDictionary = returnContent.Values.First();

            List<Map> maps = this.ResolveId(mapsDictionary);

            if (!this.BypassCache)
            {
                this.mapsCache.Value.AddRange(maps);
            }

            return maps.SingleOrDefault();
        }

        /// <summary>Calls the GW2 api to get a single map synchronously</summary>
        /// <param name="mapId">The id of the map to get.</param>
        /// <returns>The <see cref="Map"/> with the specified id.</returns>
        public Map GetMap(int mapId)
        {
            if (!this.BypassCache)
            {
                return this.mapsCache.Value.SingleOrDefault(map => map.Id == mapId);
            }

            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>("lang", this.dataManager.Language),
                                new KeyValuePair<string, object>("map_id", mapId)
                            };

            Dictionary<string, Dictionary<int, Map>> returnContent = ApiCall.GetContent<Dictionary<string, Dictionary<int, Map>>>("maps.json", args, ApiCall.Categories.World);

            Dictionary<int, Map> mapsDictionary = returnContent.Values.First();

            List<Map> maps = this.ResolveId(mapsDictionary);

            if (!this.BypassCache)
            {
                this.mapsCache.Value.AddRange(maps);
            }

            return maps.SingleOrDefault();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Private Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Resolves the ids of the maps returned by the api.</summary>
        /// <param name="mapsToResolve">The <see cref="Dictionary{TKey, TValue}"/> containing 
        /// the map ids as Key and the maps itself as value.</param>
        /// <returns>A <see cref="List{T}"/> with maps that have their Ids resolved.</returns>
        private List<Map> ResolveId(Dictionary<int, Map> mapsToResolve)
        {
            return mapsToResolve.Select(keyValuePair => keyValuePair.Value.ResolveId(keyValuePair.Key)).ToList();
        }
    }
}