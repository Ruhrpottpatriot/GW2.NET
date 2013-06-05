// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GuildData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Guilds.Models;
using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.WvW;

namespace GW2DotNET.V1.Guilds.DataProvider
{
    /// <summary>
    /// The guild data provider.
    /// </summary>
    public class GuildData : IEnumerable<Guild>
    {
        /// <summary>
        /// The guild id cache.
        /// </summary>
        private IEnumerable<Guid> guildIdCache;

        /// <summary>
        /// The guild cache.
        /// </summary>
        private IEnumerable<Guild> guildCache;

        /// <summary>
        /// The wvw manager.
        /// </summary>
        private WvWManager wvWManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuildData"/> class.
        /// </summary>
        internal GuildData()
        {
        }

        /// <summary>
        /// Sets the wvw manager.
        /// </summary>
        /// <remarks>If the user already has an instance of a <see cref="V1.WvW.WvWManager"/> created it can be set here.
        /// This ensures that already cached data is used and no second call to the api is made.</remarks>
        public WvWManager WvWManager
        {
            set
            {
                this.wvWManager = value;
            }
        }

        /// <summary>
        /// Gets the guild id cache.
        /// </summary>
        private IEnumerable<Guid> GuildIdCache
        {
            get
            {
                if (this.guildIdCache == null)
                {
                    var manager = this.wvWManager ?? new WvWManager();

                    var matches = manager.Matches;

                    this.guildIdCache = matches.SelectMany(match => match.Maps)
                        .SelectMany(map => map.Objectives)
                        .Where(obj => !string.IsNullOrEmpty(obj.OwnerGuild))
                        .Select(obj => new Guid(obj.OwnerGuild));


                    //this.guildIdCache =
                    //    matches.SelectMany(match => match.Maps, (match, map) => new { match, map })
                    //           .SelectMany(@t => @t.map.Objectives, (@t, objective) => new { @t, objective })
                    //           .Where(@t => !string.IsNullOrEmpty(@t.objective.OwnerGuild))
                    //           .Select(@t => new Guid(@t.objective.OwnerGuild));
                }

                return this.guildIdCache;
            }
        }

        /// <summary>
        /// Gets the all guilds.
        /// </summary>
        private IEnumerable<Guild> AllGuilds
        {
            get
            {
                return this.guildCache ?? (this.guildCache = this.GuildIdCache.Select(guid => new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("guild_id", guid)
                }).Select(arguments => ApiCall.GetContent<Guild>("guild_details.json", arguments, ApiCall.Categories.Guild)));
            }
        }

        /// <summary>
        /// Gets a single guilds from the cache or the server if the cache is empty.
        /// </summary>
        /// <param name="guildId">
        /// The guild id.
        /// </param>
        /// <returns>
        /// The <see cref="Guild"/>.
        /// </returns>
        public Guild this[Guid guildId]
        {
            get
            {
                if (this.guildCache == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("guild_id", guildId)
                        };

                    return ApiCall.GetContent<Guild>("guild_details.json", arguments, ApiCall.Categories.Guild);
                }

                return this.guildCache.Single(g => g.Id == guildId);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Guild> GetEnumerator()
        {
            return this.AllGuilds.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.AllGuilds.GetEnumerator();
        }
    }
}