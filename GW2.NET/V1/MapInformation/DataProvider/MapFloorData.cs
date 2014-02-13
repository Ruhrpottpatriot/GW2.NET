// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFloorData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapFloorData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.MapInformation.Models;

namespace GW2DotNET.V1.MapInformation.DataProvider
{
    /// <summary>The map floor data.</summary>
    public class MapFloorData : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Backing field for the data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The map floor cache file name.</summary>
        private readonly string mapFloorCacheFileName;

        /// <summary>Backing field for the map floor list property.</summary>
        private Lazy<List<MapFloor>> mapFloorList;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="MapFloorData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public MapFloorData(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapFloorData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        /// <param name="bypassCaching">A value indicating whether to bypass caching.</param>
        public MapFloorData(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCaching;
            this.mapFloorCacheFileName = string.Format("{0}\\Cache\\MapFloorCache-{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            int build;

            this.mapFloorList = !this.BypassCache ? new Lazy<List<MapFloor>>(() => this.ReadCacheFromDisk<List<MapFloor>>(this.mapFloorCacheFileName, out build)) : new Lazy<List<MapFloor>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the map floor list.</summary>
        public IEnumerable<MapFloor> MapFloorList
        {
            get
            {
                return this.mapFloorList.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            GameCache<List<MapFloor>> mapFloorCache = new GameCache<List<MapFloor>>()
            {
                Build = this.dataManager.Build,
                CacheData = this.mapFloorList.Value
            };

            this.WriteDataToDisk(this.mapFloorCacheFileName, mapFloorCache);
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
            this.mapFloorList = new Lazy<List<MapFloor>>();
        }

        /// <summary>Calls the GW2 api to get a map floor on the specified map and continent synchronously.</summary>
        /// <param name="continentId">The id of the continent the map floor resides on.</param>
        /// <param name="floor">The id of the floor the map floor resides on.</param>
        /// <returns>The requested <see cref="MapFloor"/>.</returns>
        public MapFloor GetMapFloor(int continentId, int floor)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("continent_id", continentId),
                            new KeyValuePair<string, object>("floor", floor),
                            new KeyValuePair<string, object>("lang", this.dataManager.Language)
                        };

            MapFloor floorToReturn = ApiCall.GetContent<MapFloor>("map_floor.json", args, ApiCall.Categories.World);

            if (!this.BypassCache)
            {
                this.mapFloorList.Value.Add(floorToReturn);
            }

            return floorToReturn;
        }

        /// <summary>Calls the GW2 api to get a map floor on the specified map and continent asynchronously.</summary>
        /// <param name="continentId">The id of the continent the map floor resides on.</param>
        /// <param name="floor">The id of the floor the map floor resides on.</param>
        /// <returns>The requested <see cref="MapFloor"/>.</returns>
        public async Task<MapFloor> GetMapFloorAsync(int continentId, int floor)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("continent_id", continentId),
                            new KeyValuePair<string, object>("floor", floor),
                            new KeyValuePair<string, object>("lang", this.dataManager.Language)
                        };

            MapFloor floorToReturn = await ApiCall.GetContentAsync<MapFloor>("map_floor.json", args, ApiCall.Categories.World);

            if (!this.BypassCache)
            {
                this.mapFloorList.Value.Add(floorToReturn);
            }

            return floorToReturn;
        }
    }
}
