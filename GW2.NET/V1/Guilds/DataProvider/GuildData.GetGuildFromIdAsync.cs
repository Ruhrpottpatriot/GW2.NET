// <copyright file="GuildData.GetGuildFromIdAsync.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the GuildData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Threading;
using GW2DotNET.V1.Guilds.Models;

namespace GW2DotNET.V1.Guilds.DataProvider
{
    /// <summary>
    ///     Delegate for GetGuildAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetGuildFromIdCompletedEventHandler(object sender, GetGuildFromIdCompletedEventArgs e);

    /// <summary>
    ///     The guild data provider.
    /// </summary>
    public partial class GuildData
    {
        private SendOrPostCallback onGetGuildFromIdCompletedDelegate;

        private SendOrPostCallback onGetGuildFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetGuildAsync request completes.
        /// </summary>
        public event GetGuildFromIdCompletedEventHandler GetGuildFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetGuildAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetGuildFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetGuildFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetGuildFromIdCompletedEventArgs;

            OnGetGuildCompleted(e);
        }

        private void OnGetGuildCompleted(GetGuildFromIdCompletedEventArgs e)
        {
            if (GetGuildFromIdCompleted != null)
            {
                GetGuildFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetGuildFromIdReportProgress(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetGuildFromId(e);
        }

        private void OnProgressChangedGetGuildFromId(ProgressChangedEventArgs e)
        {
            if (GetGuildFromIdProgressChanged != null)
            {
                GetGuildFromIdProgressChanged(this, e);
            }
        }

        private void GetGuildFromIdCompletionMethod(Guid guildId, Guild guild, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetGuildFromIdCompletedEventArgs(guildId, guild, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetGuildFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetGuildAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="asyncOp"></param>
        private void GetGuildFromIdWorker(Guid guildId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var guildToReturn = new Guild();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    guildToReturn = this[guildId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetGuildFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetGuildFromIdCompletionMethod(guildId, guildToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetGuild request. TaskId must be unique.
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="taskId"></param>
        public virtual void GetGuildFromIdAsync(Guid guildId, object taskId)
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

            GetGuildFromIdWorkerEventHandler workerDelegate = GetGuildFromIdWorker;

            workerDelegate.BeginInvoke(guildId, asyncOp, null, null);
        }

        private delegate void GetGuildFromIdWorkerEventHandler(Guid guildId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetGuildFromIdAysnc request.
    /// </summary>
    public class GetGuildFromIdCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly Guild guild;

        private readonly Guid guildId;

        /// <summary>
        /// </summary>
        /// <param name="guildId"></param>
        /// <param name="guild"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetGuildFromIdCompletedEventArgs(Guid guildId, Guild guild, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.guildId = guildId;
            this.guild = guild;
        }

        /// <summary>
        /// </summary>
        public Guid GuildId
        {
            get
            {
                RaiseExceptionIfNecessary();

                return guildId;
            }
        }

        /// <summary>
        /// </summary>
        public Guild Guild
        {
            get
            {
                RaiseExceptionIfNecessary();

                return guild;
            }
        }
    }
}