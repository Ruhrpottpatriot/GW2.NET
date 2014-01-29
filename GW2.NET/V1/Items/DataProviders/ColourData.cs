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
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;

using Newtonsoft.Json;

namespace GW2DotNET.V1.Items.DataProviders
{
    /// <summary>
    /// The colour data provider.
    /// </summary>
    public class ColourData
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// The data manager
        /// </summary>
        private readonly IDataManager dataManager;

        /// <summary>
        /// The colours cache.
        /// </summary>
        private readonly Lazy<List<GwColour>> coloursCache;

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
            this.coloursCache = new Lazy<List<GwColour>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets or sets a value indicating whether to bypass cache.</summary>
        public bool BypassCache { get; set; }

        /// <summary>
        /// Gets the colour list.
        /// </summary>
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
        public void WriteCacheToDisk()
        {
            string colourDataCacheFileName = string.Format("{0}\\Cache\\ColourCache-{1}.json", this.dataManager.StoragePath, this.dataManager.Language);

            Dictionary<KeyValuePair<string, int>, List<GwColour>> colourDataDictionary = new Dictionary<KeyValuePair<string, int>, List<GwColour>>
            {
                {
                    new KeyValuePair<string, int>("build", this.dataManager.Build),
                    this.coloursCache.Value
                }
            };

            this.WriteDataToDisk(colourDataCacheFileName, colourDataDictionary);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer.</summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary>Calls the GW2 api to get a list of all colours asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}"/> containing all colours in the game.</returns>
        public async Task<IEnumerable<GwColour>> GetColourListAsync()
        {
            List<KeyValuePair<string, object>> arguments = new List<KeyValuePair<string, object>>
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
        /// <returns>A <see cref="IEnumerable{T}"/> containing all colours in the game.</returns>
        public IEnumerable<GwColour> GetColourList()
        {
            List<KeyValuePair<string, object>> arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.dataManager.Language)
            };

            Dictionary<string, Dictionary<int, GwColour>> returnContent = ApiCall.GetContent<Dictionary<string, Dictionary<int, GwColour>>>("colors.json", arguments, ApiCall.Categories.Miscellaneous);

            Dictionary<int, GwColour> coloursDictionary = returnContent["colors"];

            List<GwColour> colours = this.ResolveColourId(coloursDictionary);

            if (!this.BypassCache)
            {
                this.coloursCache.Value.AddRange(colours);
            }

            return colours;
        }

        /// <summary>Checks if the requested colour is already in the cache,
        /// if not calls the GW2 api to get the specified colour asynchronously.</summary>
        /// <param name="colourId">The colour id.</param>
        /// <returns>The <see cref="GwColour"/> with the specified id.</returns>
        public async Task<GwColour> GetSingleColourAsync(int colourId)
        {
            if (this.coloursCache.Value.Any(colour => colour.Id == colourId))
            {
                return this.coloursCache.Value.SingleOrDefault(colour => colour.Id == colourId);
            }

            IEnumerable<GwColour> colours = await this.GetColourListAsync();

            GwColour colourToReturn = colours.SingleOrDefault(colour => colour.Id == colourId);

            if (!this.BypassCache)
            {
                this.coloursCache.Value.Add(colourToReturn);
            }

            return colourToReturn;
        }

        /// <summary>Checks if the requested colour is already in the cache,
        /// if not calls the GW2 api to get the specified colour synchronously.</summary>
        /// <param name="colourId">The colour id.</param>
        /// <returns>The <see cref="GwColour"/> with the specified id.</returns>
        public GwColour GetSingleColour(int colourId)
        {
            if (this.coloursCache.Value.Any(colour => colour.Id == colourId))
            {
                return this.coloursCache.Value.SingleOrDefault(colour => colour.Id == colourId);
            }
            
            GwColour colourToReturn = this.GetColourList().SingleOrDefault(colour => colour.Id == colourId);

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
        /// <param name="coloursToResolve">The <see cref="Dictionary{TKey, TValue}"/> containing 
        /// the colour ids as Key and the colours itself as value.</param>
        /// <returns>The <see cref="List{T}"/> containing all colours with their ids resolved.</returns>
        private List<GwColour> ResolveColourId(Dictionary<int, GwColour> coloursToResolve)
        {
            return coloursToResolve.Select(keyValuePair => new GwColour(keyValuePair.Key, keyValuePair.Value.Name, keyValuePair.Value.BaseRgb, keyValuePair.Value.Cloth, keyValuePair.Value.Leather, keyValuePair.Value.Metal)).ToList();
        }

        /// <summary>Saves the contents of the cache to the file system.</summary>
        /// <param name="cacheFileName">The complete file name of the file to save the data to.</param>
        /// <param name="dataToSave">The data to save.</param>
        private void WriteDataToDisk(string cacheFileName, object dataToSave)
        {
            string directoryPath = Path.GetDirectoryName(cacheFileName);

            // Make sure the directory exists first
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            else if (string.IsNullOrEmpty(directoryPath))
            {
                throw new NoNullAllowedException("The path to the directory must not be null or an empty string!");
            }

            File.WriteAllText(cacheFileName, JsonConvert.SerializeObject(dataToSave, Formatting.Indented));
        }
    }
}