// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the api manager with the maps data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Maps.Models;

namespace GW2DotNET.V1.Maps.DataProvider
{
    /// <summary>Provides the api manager with the maps data.</summary>
    public partial class MapsData : IEnumerable<Map>
    {
        /// <summary>The manager.</summary>
        private readonly ApiManager manager;

        /// <summary>The maps.</summary>
        private IEnumerable<Map> mapsCache;

        /// <summary>
        /// Sync object for thread safety. You MUST lock this
        /// object before touching the private continentsCache object.
        /// </summary>
        private readonly object mapsCacheSyncObject = new object();

        /// <summary>Initializes a new instance of the <see cref="MapsData"/> class.</summary>
        /// <param name="manager">The manager.</param>
        internal MapsData(ApiManager manager)
        {
            this.manager = manager;
        }

        /// <summary>Gets all maps from the api.</summary>
        private IEnumerable<Map> Maps
        {
            get
            {
                lock (mapsCacheSyncObject)
                {
                    if (this.mapsCache == null)
                    {
                        var args = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>("lang", this.manager.Language)
                            };

                        this.mapsCache =
                            ApiCall.GetContent<Dictionary<string, Dictionary<int, Map>>>(
                                "maps.json", args, ApiCall.Categories.World)
                                   .Values.First()
                                   .Select(
                                       map =>
                                       map.Value.ResolveId(map.Key)
                                          .ResolveContinent(
                                              this.manager.Continents.Single(
                                                  cont => cont.Id == map.Value.ContinentId)));
                    }
                }

                return this.mapsCache;
            }
        }

        /// <summary>
        /// Gets all maps asynchronously.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<Map>> GetAllMapsAsync(CancellationToken cancellationToken)
        {
            Func<IEnumerable<Map>> methodCall = () => this.Maps;

            return Task.Factory.StartNew(methodCall, cancellationToken);
        }

        /// <summary>Returns a map by its id</summary>
        /// <param name="mapId">The map id.</param>
        /// <returns>The <see cref="Map"/>.</returns>
        /// <remarks>This method will get a single map from the api. 
        /// However since the api returns a complete list of maps as an array 
        /// this property will call the <see cref="Maps"/> property and
        /// then filter the result further with LINQ. This also ensures that
        /// further calls are more rapid. 
        /// </remarks>
        public Map this[int mapId]
        {
            get
            {
                return this.Maps.Single(map => map.Id == mapId);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Map> GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Maps.GetEnumerator();
        }
    }
}
