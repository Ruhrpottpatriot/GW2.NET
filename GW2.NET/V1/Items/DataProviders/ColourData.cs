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
using System.Threading.Tasks;
using GW2DotNET.V1.Core.ColorsInformation.Details;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.RestSharp;

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
        private Lazy<Dyes> coloursCache;

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

            this.coloursCache = !this.BypassCache ? new Lazy<Dyes>(() => this.ReadCacheFromDisk<Dyes>(this.colourDataCacheFileName, out build)) : new Lazy<Dyes>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Gets the colour list.</summary>
        public IEnumerable<KeyValuePair<int, Dye>> Dyes
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
            var cache = new GameCache<Dyes>
                        {
                            Build = this.dataManager.Build,
                            CacheData = this.coloursCache.Value
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
            this.coloursCache = new Lazy<Dyes>();
        }

        /// <summary>Calls the GW2 api to get a list of all colours asynchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> containing all colours in the game.</returns>
        public async Task<IEnumerable<KeyValuePair<int, Dye>>> GetDyesAsync()
        {
            var serviceClient = ServiceClient.Create();
            var request       = new ColorsRequest(); // TODO: CultureInfo parameter
            var response      = await request.GetResponseAsync(serviceClient).ConfigureAwait(false);
            var dyes          = response.EnsureSuccessStatusCode().Deserialize().Colors;

            if (!this.BypassCache)
            {
                foreach (var kvp in dyes)
                {
                    this.coloursCache.Value[kvp.Key] = kvp.Value;
                }
            }

            return dyes;
        }

        /// <summary>Calls the GW2 api to get a list of all colours synchronously.</summary>
        /// <returns>A <see cref="IEnumerable{T}" /> containing all colours in the game.</returns>
        public IEnumerable<KeyValuePair<int, Dye>> GetDyes()
        {
            var serviceClient = ServiceClient.Create();
            var request       = new ColorsRequest(); // TODO: CultureInfo parameter
            var response      = request.GetResponse(serviceClient);
            var dyes          = response.EnsureSuccessStatusCode().Deserialize().Colors;

            if (!this.BypassCache)
            {
                foreach (var kvp in dyes)
                {
                    this.coloursCache.Value[kvp.Key] = kvp.Value;
                }
            }

            return dyes;
        }
    }
}