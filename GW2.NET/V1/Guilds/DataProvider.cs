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
    public class DataProvider
    {
        /// <summary>
        /// The guild cache.
        /// </summary>
        private List<Guild> guildCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider"/> class.
        /// </summary>
        internal DataProvider()
        {
            this.guildCache = new List<Guild>();
        }

        /// <summary>
        /// Gets a collection of all guilds currently in the cache.
        /// </summary>
        public IEnumerable<Guild> All
        {
            get
            {
                return this.guildCache;
            }
        }

        /// <summary>
        /// Gets a single guild from the api.
        /// </summary>
        /// <param name="guildName">
        /// The name of the guild.
        /// </param>
        /// <returns>
        /// A <see cref="Guild"/>.
        /// </returns>
        public Guild GetSingleGuild(string guildName)
        {
            var guildToReturn = this.guildCache.SingleOrDefault(g => g.Name == guildName);

            if (guildToReturn == null)
            {
                var args = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("guild_name", guildName)
                };

                guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", args, ApiCall.Categories.Guild);

                this.guildCache.Add(guildToReturn);
            }

            return guildToReturn;
        }

        /// <summary>
        /// Gets a single guild from the api.
        /// </summary>
        /// <param name="guildId">
        /// The id of the guild.
        /// </param>
        /// <returns>
        /// A <see cref="Guild"/>.
        /// </returns>
        public Guild GetSingleGuild(Guid guildId)
        {
            var guildToReturn = this.guildCache.SingleOrDefault(g => g.Id == guildId);

            if (guildToReturn == null)
            {
                var args = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("guild_id", guildId)
                };

                guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", args, ApiCall.Categories.Guild);

                this.guildCache.Add(guildToReturn);
            }

            return guildToReturn;
        }

        /// <summary>
        /// Clears the guild cache for all already downloaded guilds.
        /// </summary>
        /// <exception cref="CacheEmptyException">
        /// Thrown when the cache could not be cleared as it was already empty.
        /// </exception>
        public void ClearCache()
        {
            if (this.guildCache == null)
            {
                throw new CacheEmptyException("Could not clear cache as it was empty.");
            }

            this.guildCache = new List<Guild>();
        }
    }
}
