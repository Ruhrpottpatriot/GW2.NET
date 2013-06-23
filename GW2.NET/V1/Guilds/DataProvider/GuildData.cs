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
using System.ComponentModel;
using System.Threading;
using System.Collections.Specialized;

namespace GW2DotNET.V1.Guilds.DataProvider
{
    /// <summary>
    /// Delegate for GetGuildAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetGuildCompletedEventHandler(object sender, GetGuildCompletedEventArgs e);

    /// <summary>
    /// The guild data provider.
    /// </summary>
    public class GuildData : System.ComponentModel.Component
    {
        /// <summary>
        /// The guild cache.
        /// </summary>
        private readonly List<Guild> guildCache;

        /// <summary>
        /// This object will be used to synchronize access to the guild cache.
        /// You MUST lock this object any time you access the guild cache in
        /// order to maintain thread safety.
        /// </summary>
        private object guildCacheSyncObject = new object();

        /// <summary>
        /// Stores the GW2ApiManager that instantiated this object
        /// </summary>
        // ReSharper disable NotAccessedField.Local
        private Gw2ApiManager gw2ApiManager;
        // ReSharper restore NotAccessedField.Local

        /// <summary>
        /// This event fires when a GetGuildAsync request completes.
        /// </summary>
        public event GetGuildCompletedEventHandler GetGuildCompleted;

        /// <summary>
        /// This event fires when the progress of a GetGuildAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler ProgressChanged;

        private SendOrPostCallback onProgressReportDelegate;

        private SendOrPostCallback onCompletedDelegate;

        private delegate void GetGuildWorkerEventHandler(Guid guildId, AsyncOperation asyncOp);

        private HybridDictionary userStateToLifetime = new HybridDictionary();

        /// <summary>Initializes a new instance of the <see cref="GuildData"/> class.</summary>
        /// <param name="gw2ApiManager">The api Manager.</param>
        internal GuildData(Gw2ApiManager gw2ApiManager)
        {
            this.gw2ApiManager = gw2ApiManager;

            this.guildCache = new List<Guild>();

            this.InitializeDelegates();
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

                lock (this.guildCacheSyncObject)
                {
                    guildToReturn = this.guildCache.SingleOrDefault(g => g.Id == guildId);
                }

                if (guildToReturn.Id == Guid.Empty)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("guild_id", guildId)
                        };

                    guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", arguments, ApiCall.Categories.Guild);

                    lock (this.guildCacheSyncObject)
                    {
                        // A different thread could have added this guild to the cache already, so check first
                        if (this.guildCache.SingleOrDefault(g => g.Id == guildId).Id == Guid.Empty)
                        {
                            this.guildCache.Add(guildToReturn);
                        }
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
                Guild guildToReturn;

                lock (this.guildCacheSyncObject)
                {
                    guildToReturn = this.guildCache.SingleOrDefault(g => g.Name == guildName);
                }

                if (guildToReturn.Id == Guid.Empty)
                {
                    var arguments = new List<KeyValuePair<string, object>>
                        {
                            new KeyValuePair<string, object>("guild_name", guildName)
                        };

                    guildToReturn = ApiCall.GetContent<Guild>("guild_details.json", arguments, ApiCall.Categories.Guild);

                    lock (this.guildCacheSyncObject)
                    {
                        // A different thread could have added this guild to the cache already, so check first
                        if (this.guildCache.SingleOrDefault(g => g.Name == guildName).Id == Guid.Empty)
                        {
                            this.guildCache.Add(guildToReturn);
                        }
                    }
                }

                return guildToReturn;
            }
        }

        /// <summary>
        /// Initialize the delegates. This is called by the constructor.
        /// </summary>
        protected virtual void InitializeDelegates()
        {
            onProgressReportDelegate = new SendOrPostCallback(ReportProgress);

            onCompletedDelegate = new SendOrPostCallback(GetGuildCompletedCallback);
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetGuildCompletedCallback(object operationState)
        {
            GetGuildCompletedEventArgs e = operationState as GetGuildCompletedEventArgs;

            OnGetGuildCompleted(e);
        }

        private void OnGetGuildCompleted(GetGuildCompletedEventArgs e)
        {
            if (GetGuildCompleted != null)
            {
                GetGuildCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void ReportProgress(object state)
        {
            ProgressChangedEventArgs e = state as ProgressChangedEventArgs;

            OnProgressChanged(e);
        }

        private void OnProgressChanged(ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(this, e);
            }
        }

        private void GetGuildCompletionMethod(Guid guildID, Guild guild, Exception exception, bool canceled, AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            GetGuildCompletedEventArgs e = new GetGuildCompletedEventArgs(guildID, guild, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onCompletedDelegate, e);
        }

        // Utility method for determining if a task has been canceled.
        private bool TaskCanceled(object taskId)
        {
            return (userStateToLifetime[taskId] == null);
        }

        /// <summary>
        /// Performs the actual GetGuildAsync request. This method
        /// is exectued on the worker thread.
        /// </summary>
        /// <param name="guildID"></param>
        /// <param name="asyncOp"></param>
        private void GetGuildWorker(Guid guildID, AsyncOperation asyncOp)
        {
            Exception e = null;
            ProgressChangedEventArgs pe = null;
            Guild guildToReturn = new Guild();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    guildToReturn = this[guildID];
                    pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(this.onProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            this.GetGuildCompletionMethod(guildID, guildToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        /// Starts an asynchronous GetGuild request. TaskId must be unique.
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="taskId"></param>
        public virtual void GetGuildAsync(Guid guildId, object taskId)
        {
            AsyncOperation asyncOp = AsyncOperationManager.CreateOperation(taskId);

            lock (userStateToLifetime.SyncRoot)
            {
                if (userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException("Task ID parameter must be unique", "taskId");
                }

                userStateToLifetime[taskId] = asyncOp;
            }

            GetGuildWorkerEventHandler workerDelegate = new GetGuildWorkerEventHandler(this.GetGuildWorker);

            workerDelegate.BeginInvoke(guildId, asyncOp, null, null);
        }
    }

    /// <summary>
    /// Holds the results of a GetGuildAysnc request.
    /// </summary>
    public class GetGuildCompletedEventArgs : AsyncCompletedEventArgs
    {
        private Guid guildID;
        private Guild guild;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guildID"></param>
        /// <param name="guild"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetGuildCompletedEventArgs(Guid guildID, Guild guild, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.guildID = guildID;
            this.guild = guild;
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid GuildID
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.guildID;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guild Guild
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.guild;
            }
        }
    }
}