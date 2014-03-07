// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the ApiManager with the map api data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GW2DotNET.V1.Core.MapsInformation.Continents;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.RestSharp;

namespace GW2DotNET.V1.MapInformation.DataProvider
{
    /// <summary>Provides the ApiManager with the map api data.</summary>
    public class ContinentData : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The continent cache file name.</summary>
        private readonly string continentCacheFileName;

        /// <summary>The data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>Backing field for the continent list property.</summary>
        private Lazy<MapContinentCollection> continentList;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="ContinentData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public ContinentData(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ContinentData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        /// <param name="bypassCaching">The bypass Cache.</param>
        public ContinentData(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            this.continentCacheFileName = string.Format("{0}\\Cache\\ContinentCache-{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            this.BypassCaching = bypassCaching;

            int build;

            this.continentList = !this.BypassCache ? new Lazy<MapContinentCollection>(() => this.ReadCacheFromDisk<MapContinentCollection>(this.continentCacheFileName, out build)) : new Lazy<MapContinentCollection>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets a value indicating whether to bypass the cache.</summary>
        public bool BypassCaching { get; set; }

        /// <summary>Gets the continent list.</summary>
        public IEnumerable<KeyValuePair<int, MapContinent>> ContinentList
        {
            get
            {
                return this.continentList.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            var continentCache = new GameCache<MapContinentCollection>
                                 {
                                     Build = this.dataManager.Build,
                                     CacheData = this.continentList.Value
                                 };

            this.WriteDataToDisk(this.continentCacheFileName, continentCache);
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
            this.continentList = new Lazy<MapContinentCollection>();
        }

        /// <summary>Calls the GW2 api to get all continents asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> of continents.</returns>
        public async Task<IEnumerable<KeyValuePair<int, MapContinent>>> GetAllContinentsAsync()
        {
            var serviceClient = ServiceClient.Create();

            var request = new MapContinentsRequest();

            var response = await request.GetResponseAsync(serviceClient).ConfigureAwait(false);

            var continents = response.EnsureSuccessStatusCode().Deserialize().Continents;

            if (!this.BypassCaching)
            {
                foreach (var kvp in continents)
                {
                    this.continentList.Value[kvp.Key] = kvp.Value;
                }
            }

            return continents;
        }

        /// <summary>Calls the GW2 api to get all continents synchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> of continents.</returns>
        public IEnumerable<KeyValuePair<int, MapContinent>> GetAllContinents()
        {
            var serviceClient = ServiceClient.Create();

            var request = new MapContinentsRequest();

            var response = request.GetResponse(serviceClient);

            var continents = response.EnsureSuccessStatusCode().Deserialize().Continents;

            if (!this.BypassCaching)
            {
                foreach (var kvp in continents)
                {
                    this.continentList.Value[kvp.Key] = kvp.Value;
                }
            }

            return continents;
        }
    }
}