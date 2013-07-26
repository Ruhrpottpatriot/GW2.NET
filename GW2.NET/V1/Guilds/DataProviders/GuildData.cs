// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuildData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GuildData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Guilds.Models;
using GW2DotNET.V1.Infrastructure;

namespace GW2DotNET.V1.Guilds.DataProviders
{
    using System.Diagnostics;
    using System.Runtime.Remoting;

    /// <summary>
    /// The guild data provider.
    /// </summary>
    [Obsolete]
    public class GuildData
    {
        /// <summary>
        /// The guild cache.
        /// </summary>
        private readonly List<Guild> guildCache;

        /// <summary>
        /// Stores the GW2ApiManager that instantiated this object
        /// </summary>
        private readonly ApiManager apiManager;

        /// <summary>Initializes a new instance of the <see cref="GuildData"/> class.</summary>
        /// <param name="apiManager">The api Manager.</param>
        internal GuildData(ApiManager apiManager)
        {
            this.apiManager = apiManager;

            this.guildCache = new List<Guild>();
        }

        /// <summary>
        /// Gets a single guild by ID from the cache if present, or from the API if not.
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
                var guildToReturn = this.guildCache.SingleOrDefault(g => g.Id == guildId);

                if (guildToReturn == null)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("guild_id", guildId)
                        };

                    try
                    {
                        this.apiManager.Logger.WriteToLog("Starting request for guild by id.", TraceEventType.Start);

                        guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", arguments, ApiCall.Categories.Guild);

                        this.apiManager.Logger.WriteToLog("Finished getting guild", TraceEventType.Stop);

                        this.guildCache.Add(guildToReturn);
                    }
                    catch (Exception ex)
                    {
                        this.apiManager.Logger.WriteToLog(ex, TraceEventType.Warning);
                    }
                }

                return guildToReturn;
            }
        }

        /// <summary>
        /// Gets a single guild by name from the cache if present, or from the API if not.
        /// </summary>
        /// <param name="guildName">The name of the guild</param>
        /// <returns>The <see cref="Guild"/></returns>
        public Guild this[string guildName]
        {
            get
            {
                var guildToReturn = this.guildCache.SingleOrDefault(g => g.Name == guildName);

                if (guildToReturn.Id == Guid.Empty)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("guild_name", guildName)
                        };

                    try
                    {
                        this.apiManager.Logger.WriteToLog("Starting request for guild by id.", TraceEventType.Start);

                        guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", arguments, ApiCall.Categories.Guild);

                        this.apiManager.Logger.WriteToLog("Finished request.", TraceEventType.Stop);

                        this.guildCache.Add(guildToReturn);
                    }
                    catch (Exception ex)
                    {
                        this.apiManager.Logger.WriteToLog(ex, TraceEventType.Warning);
                    }
                }

                return guildToReturn;
            }
        }
    }
}