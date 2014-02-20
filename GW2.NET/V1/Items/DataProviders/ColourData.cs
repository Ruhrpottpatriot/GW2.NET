// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColourData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The colour data provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;

namespace GW2DotNET.V1.Items.DataProviders
{
    /// <summary>The colour data provider.</summary>
    public class ColourData : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The colour data cache file name.</summary>
        private readonly string colourDataCacheFileName;

        /// <summary>The data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The colours cache.</summary>
        private Lazy<List<GwColour>> coloursCache;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors & Destructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="ColourData"/> class.</summary>
        /// <param name="dataManager">The data manager.</param>
        public ColourData(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColourData"/> class.</summary>
        /// <param name="dataManager">The api manager.</param>
        /// <param name="bypassCaching">A value indicating whether to bypass caching.</param>
        internal ColourData(IDataManager dataManager, bool bypassCaching)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCaching;
            this.colourDataCacheFileName = string.Format("{0}\\Cache\\ColourCache-{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            int build;

            this.coloursCache = !this.BypassCache ? new Lazy<List<GwColour>>(() => this.ReadCacheFromDisk<List<GwColour>>(this.colourDataCacheFileName, out build)) : new Lazy<List<GwColour>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the colour list.</summary>
        public IEnumerable<GwColour> ColourList
        {
            get
            {
                return this.coloursCache.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Writes the complete cache to the disk using the specified serializer.</summary>
        public override void WriteCacheToDisk()
        {
            var cache = new GameCache<List<GwColour>>
                        {
                            Build = this.dataManager.Build, CacheData = this.coloursCache.Value
                        };

            this.WriteDataToDisk(this.colourDataCacheFileName, cache);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer.</summary>
        /// <returns>The <see cref="Task" />.</returns>
        public override async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary>Clears the cache.</summary>
        public override void ClearCache()
        {
            this.coloursCache = new Lazy<List<GwColour>>();
        }

        /// <summary>Calls the GW2 api to get a list of all colours asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> containing all colours in the game.</returns>
        public async Task<IEnumerable<GwColour>> GetColourListAsync()
        {
            var arguments = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>("lang", this.dataManager.Language)
                            };

            Dictionary<string, Dictionary<int, GwColour>> returnContent = await ApiCall.GetContentAsync<Dictionary<string, Dictionary<int, GwColour>>>("colors.json", arguments, ApiCall.Categories.Miscellaneous);

            Dictionary<int, GwColour> coloursDictionary = returnContent["colors"];

            List<GwColour> colours = this.ResolveColourId(coloursDictionary);

            if (!this.BypassCache)
            {
                this.coloursCache.Value.AddRange(colours);
            }

            return colours;
        }

        /// <summary>Calls the GW2 api to get a list of all colours synchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> containing all colours in the game.</returns>
        public IEnumerable<GwColour> GetColourList()
        {
            var arguments = new List<KeyValuePair<string, object>>
                            {
                                new KeyValuePair<string, object>("lang", this.dataManager.Language)
                            };

            var returnContent = ApiCall.GetContent<Dictionary<string, Dictionary<int, GwColour>>>("colors.json", arguments, ApiCall.Categories.Miscellaneous);

            Dictionary<int, GwColour> coloursDictionary = returnContent["colors"];

            List<GwColour> colours = this.ResolveColourId(coloursDictionary);

            if (!this.BypassCache)
            {
                this.coloursCache.Value.AddRange(colours);
            }

            return colours;
        }

        /// <summary>Checks if the requested colour is already in the cache, if not calls the GW2 api to get the specified colour asynchronously.</summary>
        /// <param name="colourId">The colour id.</param>
        /// <returns>The <see cref="GwColour"/> with the specified id.</returns>
        public async Task<GwColour> GetSingleColourAsync(int colourId)
        {
            if (this.coloursCache.Value.Any(colour => colour.Id == colourId))
            {
                return this.coloursCache.Value.FirstOrDefault(colour => colour.Id == colourId);
            }

            GwColour colourToReturn = (await this.GetColourListAsync()).FirstOrDefault(colour => colour.Id == colourId);

            if (!this.BypassCache)
            {
                this.coloursCache.Value.Add(colourToReturn);
            }

            return colourToReturn;
        }

        /// <summary>Checks if the requested colour is already in the cache, if not calls the GW2 api to get the specified colour synchronously.</summary>
        /// <param name="colourId">The colour id.</param>
        /// <returns>The <see cref="GwColour"/> with the specified id.</returns>
        public GwColour GetSingleColour(int colourId)
        {
            if (this.coloursCache.Value != null && this.coloursCache.Value.Any(colour => colour.Id == colourId))
            {
                return this.coloursCache.Value.FirstOrDefault(colour => colour.Id == colourId);
            }

            GwColour colourToReturn = this.GetColourList().FirstOrDefault(colour => colour.Id == colourId);

            if (!this.BypassCache)
            {
                this.coloursCache.Value.Add(colourToReturn);
            }

            return colourToReturn;
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Private Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Resolves the ids on a <see cref="Dictionary{TKey,TValue}"/> of colours.</summary>
        /// <param name="coloursToResolve">The <see cref="Dictionary{TKey, TValue}"/> containing the colour ids as Key and the colours itself as value.</param>
        /// <returns>The <see cref="List{T}"/> containing all colours with their ids resolved.</returns>
        private List<GwColour> ResolveColourId(Dictionary<int, GwColour> coloursToResolve)
        {
            return coloursToResolve.Select(keyValuePair => new GwColour(keyValuePair.Key, keyValuePair.Value.Name, keyValuePair.Value.BaseRgb, keyValuePair.Value.Cloth, keyValuePair.Value.Leather, keyValuePair.Value.Metal)).ToList();
        }
    }
}