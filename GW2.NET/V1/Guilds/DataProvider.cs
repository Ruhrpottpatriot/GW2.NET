// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the DataProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GW2DotNET.V1.Guilds.Models;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Infrastructure.Exceptions;

namespace GW2DotNET.V1.Guilds
{
    /// <summary>The data provider for the guild api</summary>
    /// <remarks>
    /// This data provider will supply the user with a list of guilds. 
    /// As there is currently no way to get a complete list of guilds this implementation
    /// will require the user to know either the guild name, or the guild id. 
    /// When the user requests a guild the data provider will first look in the cache
    /// and see if a guild with that name/id is already present. If it is it will return the guild
    /// from the cache. If no guild with said name/id is present in the cache the data provider
    /// will query the api for said guild. After the query has completed the data provider will
    /// add the guild to the cache and subsequent calls to that guild will be done against the cache.
    /// The users also has the possibility to get a complete collection of all guilds
    /// currently in the cache.
    /// </remarks>
    public class DataProvider : DataProviderBase
    {
        // --------------------------------------------------------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>The data manager.</summary>
        private readonly IDataManager dataManager;

        /// <summary>The guild list cache file name.</summary>
        private readonly string guildListCacheFileName;

        /// <summary>
        /// The guild cache.
        /// </summary>
        private Lazy<List<Guild>> guildList;

        // --------------------------------------------------------------------------------------------------------------------
        // Constructors
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManager">The api Manager.</param>
        /// <remarks>When calling this method the cache is not bypassed by default.</remarks>
        internal DataProvider(IDataManager dataManager)
            : this(dataManager, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DataProvider"/> class.</summary>
        /// <param name="dataManager">The api manager.</param>
        /// <param name="bypassCache">The bypass cache.</param>
        internal DataProvider(IDataManager dataManager, bool bypassCache)
        {
            this.dataManager = dataManager;
            this.BypassCache = bypassCache;
            this.guildListCacheFileName = string.Format("{0}\\Cache\\GuildCache-{1}.json", this.dataManager.SavePath, this.dataManager.Language);

            this.guildList = !this.BypassCache ? new Lazy<List<Guild>>(() => this.ReadCacheFromDisk<GameCache<List<Guild>>>(this.guildListCacheFileName).CacheData) : new Lazy<List<Guild>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Properties
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Gets a collection of <see cref="Guild">Guilds</see> currently in the cache.
        /// </summary>
        public IEnumerable<Guild> GuildList
        {
            get
            {
                return this.guildList.Value;
            }
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Public Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Asynchronously gets a single guild from the api.</summary>
        /// <param name="guildName">The name of the guild.</param>
        /// <returns>The <see cref="Task"/> containing the <see cref="Guild"/> with the specified name.</returns>
        public async Task<Guild> GetSingleGuildAsync(string guildName)
        {
            if (this.BypassCache)
            {
                return await this.FetchGuildByNameAsync(guildName);
            }

            // Check if the guild is present in the cache, if not download it.
            var guildToReturn = this.guildList.Value.SingleOrDefault(g => g.Name == guildName);

            if (guildToReturn == null)
            {
                guildToReturn = await this.FetchGuildByNameAsync(guildName);

                if (!this.BypassCache)
                {
                    this.guildList.Value.Add(guildToReturn);
                }
            }

            return guildToReturn;
        }

        /// <summary>Gets a single guild from the api.</summary>
        /// <param name="guildId">The id of the guild.</param>
        /// <returns>The <see cref="Task"/>containing the <see cref="Guild"/> with the specified id..</returns>
        public async Task<Guild> GetSingleGuildAsync(Guid guildId)
        {
            if (this.BypassCache)
            {
                return await this.FetchGuildByIdAsync(guildId);
            }

            var guildToReturn = this.guildList.Value.SingleOrDefault(g => g.Id == guildId);

            if (guildToReturn == null)
            {
                guildToReturn = await this.FetchGuildByIdAsync(guildId);

                if (!this.BypassCache)
                {
                    this.guildList.Value.Add(guildToReturn);
                }
            }

            return guildToReturn;
        }

        /// <summary>
        /// Writes the complete cache to the disk using the specified serializer.
        /// </summary>
        public override void WriteCacheToDisk()
        {
            GameCache<List<Guild>> guildCache = new GameCache<List<Guild>>
            {
                Build = this.dataManager.Build,
                CacheData = this.guildList.Value
            };
            this.WriteDataToDisk(this.guildListCacheFileName, guildCache);
        }

        /// <summary>Writes the complete cache to the disk asynchronously using the specified serializer</summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task"/>.</returns>
        public override async Task WriteCacheToDiskAsync()
        {
            throw new NotImplementedException("This function has not yet been implemented. Use the synchronous method instead.");
        }

        /// <summary> Clears the guild cache for all already downloaded guilds.</summary>
        /// <exception cref="CacheEmptyException">Thrown when the cache could not be cleared as it was already empty.</exception>
        public void ClearCache()
        {
            if (this.guildList == null)
            {
                throw new CacheEmptyException("Could not clear cache as it was empty.");
            }

            this.guildList = new Lazy<List<Guild>>();
        }

        // --------------------------------------------------------------------------------------------------------------------
        // Private Methods
        // --------------------------------------------------------------------------------------------------------------------

        /// <summary>Asynchronously fetches a guild by its name from the server .</summary>
        /// <param name="guildName">The guild name.</param>
        /// <returns>The <see cref="Task"/> containing the <see cref="Guild"/> with the specified name.</returns>
        private async Task<Guild> FetchGuildByNameAsync(string guildName)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("guild_name", guildName)
            };

            return await ApiCall.GetContentAsync<Guild>("guild_details.json", args, ApiCall.Categories.Guild);
        }

        /// <summary>Asynchronously fetches a guild by it's id from the server.</summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/> containing the <see cref="Guild"/> with the specified id.</returns>
        private async Task<Guild> FetchGuildByIdAsync(Guid id)
        {
            List<KeyValuePair<string, object>> args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("guild_id", id)
            };

            return await ApiCall.GetContentAsync<Guild>("guild_details.json", args, ApiCall.Categories.Guild);
        }
    }
}
