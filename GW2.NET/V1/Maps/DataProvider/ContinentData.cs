// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the ApiManager with the map api data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Maps.Models;

namespace GW2DotNET.V1.Maps.DataProvider
{
    /// <summary>Provides the ApiManager with the map api data.</summary>
    public partial class ContinentData : DataProviderBase, IEnumerable<Continent>
    {
        /// <summary>The api manager.</summary>
        private readonly ApiManager manager;

        /// <summary>The continents.</summary>
        private IEnumerable<Continent> continentsCache;

        /// <summary>
        /// Sync object for thread safety. You MUST lock this
        /// object before touching the private continentsCache object.
        /// </summary>
        private readonly object continentsCacheSyncObject = new object();

        /// <summary>Initializes a new instance of the <see cref="ContinentData"/> class.</summary>
        /// <param name="manager">The manager.</param>
        internal ContinentData(ApiManager manager)
        {
            this.manager = manager;

            this.InitializeDelegates();
        }

        /// <summary>
        /// Initialize the delegates. This is called by the constructor.
        /// </summary>
        protected virtual void InitializeDelegates()
        {
            onGetContinentFromIdCompletedDelegate = GetContinentFromIdCompletedCallback;

            onGetContinentFromIdProgressReportDelegate = GetContinentFromIdReportProgressCallback;

            onGetAllContinentsCompletedDelegate = GetAllContinentsCompletedCallback;

            onGetAllContinentsProgressReportDelegate = GetAllContinentsReportProgressCallback;
        }

        /// <summary>Gets all continents from the api.</summary>
        private IEnumerable<Continent> Continents
        {
            get
            {
                lock (continentsCacheSyncObject)
                {
                    if (this.continentsCache == null)
                    {
                        var args = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>(
                                    "lang", this.manager.Language)
                            };

                        this.continentsCache =
                            ApiCall.GetContent<Dictionary<string, Dictionary<int, Continent>>>(
                                "continents.json", args, ApiCall.Categories.World)
                                   .Values.First()
                                   .Select(con => con.Value.ResolveId(con.Key));
                    }
                }

                return this.continentsCache;
            }
        }

        /// <summary>Gets a continent by it's id.</summary>
        /// <param name="id">The id of the continent.</param>
        /// <returns>The <see cref="Continent"/>.</returns>
        /// <remarks>This method will get a single continent from the api. 
        /// However since the api returns a complete list of continents as an array 
        /// this property will call the <see cref="Continents"/> property and
        /// then filter the result further with LINQ. This also ensures that
        /// further calls are more rapid. 
        /// </remarks>
        public Continent this[int id]
        {
            get
            {
                return this.Continents.Single(continent => continent.Id == id);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Continent> GetEnumerator()
        {
            return this.Continents.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Continents.GetEnumerator();
        }
    }
}
