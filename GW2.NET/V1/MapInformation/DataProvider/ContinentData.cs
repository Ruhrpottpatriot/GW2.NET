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
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.MapInformation.Models;

namespace GW2DotNET.V1.MapInformation.DataProvider
{
    /// <summary>Provides the ApiManager with the map api data.</summary>
    public class ContinentData
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The data manager.</summary>
        private readonly IDataManager manager;

        /// <summary>Backing field for the continent list property.</summary>
        private List<Continent> continentList;

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
        /// <param name="manager">The data manager.</param>
        /// <param name="bypassCaching">The bypass Cache.</param>
        public ContinentData(IDataManager manager, bool bypassCaching)
        {
            this.manager = manager;
            this.BypassCaching = bypassCaching;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets a value indicating whether to bypass the cache.</summary>
        public bool BypassCaching { get; set; }

        /// <summary>Gets the continent list.</summary>
        public IEnumerable<Continent> ContinentList
        {
            get
            {
                return this.continentList;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------
        
        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public void WriteCacheToDisk()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task" />.</returns>
        public async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented");
        }

        /// <summary>Calls the GW2 api to get all continents asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of continents.</returns>
        public async Task<IEnumerable<Continent>> GetAllContinentsAsync()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.manager.Language)
            };

            Dictionary<string, Dictionary<int, Continent>> returnContent = await ApiCall.GetContentAsync<Dictionary<string, Dictionary<int, Continent>>>(
                "continents.json",
                args,
                ApiCall.Categories.World);

            Dictionary<int, Continent> continentDictionary = returnContent.Values.First();

            List<Continent> continents = this.ResolveId(continentDictionary);

            if (!this.BypassCaching)
            {
                this.continentList = continents;
            }

            return continents;
        }

        /// <summary>Calls the GW2 api to get all continents synchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of continents.</returns>
        public IEnumerable<Continent> GetAllContinents()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.manager.Language)
            };

            Dictionary<string, Dictionary<int, Continent>> returnContent = ApiCall.GetContent<Dictionary<string, Dictionary<int, Continent>>>(
                "continents.json",
                args,
                ApiCall.Categories.World);

            Dictionary<int, Continent> continentDictionary = returnContent.Values.First();

            List<Continent> continents = this.ResolveId(continentDictionary);

            if (!this.BypassCaching)
            {
                this.continentList = continents;
            }

            return continents;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Private Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Resolves the ids of the continent dictionary.</summary>
        /// <param name="continentsToResolve">The <see cref="Dictionary{TKey, TValue}"/> containing 
        /// the continent ids as Key and the continents itself as value.</param>
        /// <returns>A <see cref="List{T}"/> containing all continents with their ids resolved..</returns>
        private List<Continent> ResolveId(Dictionary<int, Continent> continentsToResolve)
        {
            List<Continent> continents = new List<Continent>();

            foreach (KeyValuePair<int, Continent> keyValuePair in continentsToResolve)
            {
                keyValuePair.Value.Id = keyValuePair.Key;

                continents.Add(keyValuePair.Value);
            }

            return continents;
        }
    }
}
