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
using System.Collections.Specialized;
using System.Linq;
using GW2DotNET.V1.Guilds.Models;
using GW2DotNET.V1.Infrastructure;

namespace GW2DotNET.V1.Guilds.DataProvider
{
    using System.Diagnostics;
    using System.Runtime.Remoting;

    /// <summary>
    ///     The guild data provider.
    /// </summary>
    public partial class GuildData : DataProviderBase
    {
        /// <summary>
        ///     The guild cache.
        /// </summary>
        private readonly List<Guild> guildCache;

        /// <summary>
        ///     This object will be used to synchronize access to the guild cache.
        ///     You MUST lock this object any time you access the guild cache in
        ///     order to maintain thread safety.
        /// </summary>
        private readonly object guildCacheSyncObject = new object();

        /// <summary>
        ///     Stores the GW2ApiManager that instantiated this object
        /// </summary>
        // ReSharper disable NotAccessedField.Local
        private readonly ApiManager apiManager;

        /// <summary>Initializes a new instance of the <see cref="GuildData"/> class.</summary>
        /// <param name="apiManager">The api Manager.</param>
        internal GuildData(ApiManager apiManager)
        {
            this.apiManager = apiManager;

            guildCache = new List<Guild>();

            InitializeDelegates();
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
                Guild guildToReturn;

                lock (guildCacheSyncObject)
                {
                    guildToReturn = guildCache.SingleOrDefault(g => g.Id == guildId);
                }

                if (guildToReturn.Id == Guid.Empty)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("guild_id", guildId)
                        };

                    try
                    {
                        this.apiManager.Logger.WriteToLog("Starting request for guild by id.", TraceEventType.Start);

                        guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", arguments,
                                                                  ApiCall.Categories.Guild);

                        lock (guildCacheSyncObject)
                        {
                            // A different thread could have added this guild to the cache already, so check first
                            if (guildCache.SingleOrDefault(g => g.Id == guildId).Id == Guid.Empty)
                            {
                                guildCache.Add(guildToReturn);
                            }
                        }
                        
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
        ///     Gets a single guild by name from the cache if present, or from the API if not.
        /// </summary>
        /// <param name="guildName">The name of the guild</param>
        /// <returns>
        ///     The <see cref="Guild" />
        /// </returns>
        public Guild this[string guildName]
        {
            get
            {
                Guild guildToReturn;

                lock (guildCacheSyncObject)
                {
                    guildToReturn = guildCache.SingleOrDefault(g => g.Name == guildName);
                }

                if (guildToReturn.Id == Guid.Empty)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("guild_name", guildName)
                        };

                    try
                    {
                        this.apiManager.Logger.WriteToLog("Starting request for guild by id.", TraceEventType.Start);

                        guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", arguments,
                                                                  ApiCall.Categories.Guild);

                        lock (guildCacheSyncObject)
                        {
                            // A different thread could have added this guild to the cache already, so check first
                            if (guildCache.SingleOrDefault(g => g.Name == guildName).Id == Guid.Empty)
                            {
                                guildCache.Add(guildToReturn);
                            }
                        }

                        this.apiManager.Logger.WriteToLog("Finished getting guild", TraceEventType.Stop);
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
        ///     Initialize the delegates. This is called by the constructor.
        /// </summary>
        protected virtual void InitializeDelegates()
        {
            onGetGuildFromIdProgressReportDelegate = GetGuildFromIdReportProgress;

            onGetGuildFromIdCompletedDelegate = GetGuildFromIdCompletedCallback;

            onGetGuildFromNameProgressReportDelegate = GetGuildFromNameReportProgress;

            onGetGuildFromNameCompletedDelegate = GetGuildFromNameCompletedCallback;
        }
    }
}