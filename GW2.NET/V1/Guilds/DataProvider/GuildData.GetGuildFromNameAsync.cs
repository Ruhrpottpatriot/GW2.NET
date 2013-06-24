using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using GW2DotNET.V1.Guilds.Models;

namespace GW2DotNET.V1.Guilds.DataProvider
{
    /// <summary>
    ///     Delegate for GetGuildAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetGuildFromNameCompletedEventHandler(object sender, GetGuildFromNameCompletedEventArgs e);

    /// <summary>
    ///     The guild data provider.
    /// </summary>
    public partial class GuildData
    {
        private SendOrPostCallback onGetGuildFromNameCompletedDelegate;

        private SendOrPostCallback onGetGuildFromNameProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetGuildAsync request completes.
        /// </summary>
        public event GetGuildFromNameCompletedEventHandler GetGuildFromNameCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetGuildAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetGuildFromNameProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetGuildFromNameCompletedCallback(object operationState)
        {
            var e = operationState as GetGuildFromNameCompletedEventArgs;

            OnGetGuildCompleted(e);
        }

        private void OnGetGuildCompleted(GetGuildFromNameCompletedEventArgs e)
        {
            if (GetGuildFromNameCompleted != null)
            {
                GetGuildFromNameCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetGuildFromNameReportProgress(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetGuildFromName(e);
        }

        private void OnProgressChangedGetGuildFromName(ProgressChangedEventArgs e)
        {
            if (GetGuildFromNameProgressChanged != null)
            {
                GetGuildFromNameProgressChanged(this, e);
            }
        }

        private void GetGuildFromNameCompletionMethod(string guildName, Guild guild, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetGuildFromNameCompletedEventArgs(guildName, guild, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetGuildFromNameCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetGuildAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="guildName"></param>
        /// <param name="asyncOp"></param>
        private void GetGuildFromNameWorker(string guildName, AsyncOperation asyncOp)
        {
            Exception e = null;
            var guildToReturn = new Guild();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    guildToReturn = this[guildName];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetGuildFromNameProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetGuildFromNameCompletionMethod(guildName, guildToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetGuild request. TaskId must be unique.
        /// </summary>
        /// <param name="guildName"></param>
        /// <param name="taskId"></param>
        public virtual void GetGuildFromNameAsync(string guildName, object taskId)
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

            GetGuildFromNameWorkerEventHandler workerDelegate = GetGuildFromNameWorker;

            workerDelegate.BeginInvoke(guildName, asyncOp, null, null);
        }

        private delegate void GetGuildFromNameWorkerEventHandler(string guildName, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetGuildFromNameAysnc request.
    /// </summary>
    public class GetGuildFromNameCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly Guild guild;

        private readonly string guildName;

        /// <summary>
        /// </summary>
        /// <param name="guildName"></param>
        /// <param name="guild"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetGuildFromNameCompletedEventArgs(string guildName, Guild guild, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.guildName = guildName;
            this.guild = guild;
        }

        /// <summary>
        /// </summary>
        public string GuildName
        {
            get
            {
                RaiseExceptionIfNecessary();

                return guildName;
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
