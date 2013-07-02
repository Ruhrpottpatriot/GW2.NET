using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World.DataProvider
{
    /// <summary>
    ///     Delegate for GetAllWorldsAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetAllWorldsCompletedEventHandler(object sender, GetAllWorldsCompletedEventArgs e);

    public partial class WorldData
    {
        private SendOrPostCallback onGetAllWorldsCompletedDelegate;

        private SendOrPostCallback onGetAllWorldsProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetAllWorldsAsync request completes.
        /// </summary>
        public event GetAllWorldsCompletedEventHandler GetAllWorldsCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetAllWorldsAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetAllWorldsProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllWorldsCompletedCallback(object operationState)
        {
            var e = operationState as GetAllWorldsCompletedEventArgs;

            OnGetWorldCompleted(e);
        }

        private void OnGetWorldCompleted(GetAllWorldsCompletedEventArgs e)
        {
            if (GetAllWorldsCompleted != null)
            {
                GetAllWorldsCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllWorldsReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetAllWorlds(e);
        }

        private void OnProgressChangedGetAllWorlds(ProgressChangedEventArgs e)
        {
            if (GetAllWorldsProgressChanged != null)
            {
                GetAllWorldsProgressChanged(this, e);
            }
        }

        private void GetAllWorldsCompletionMethod(IEnumerable<GwWorld> worlds, Exception exception, bool canceled,
                                                  AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetAllWorldsCompletedEventArgs(worlds, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetAllWorldsCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetWorldAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="asyncOp"></param>
        private void GetAllWorldsWorker(AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<GwWorld> worldsToReturn = new GwWorld[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    worldsToReturn = this.Worlds;
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetAllWorldsProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetAllWorldsCompletionMethod(worldsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetAllWorlds request. TaskId must be unique.
        /// </summary>
        /// <param name="taskId"></param>
        public virtual void GetAllWorldsAsync(object taskId)
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

            GetAllWorldsWorkerEventHandler workerDelegate = GetAllWorldsWorker;

            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private delegate void GetAllWorldsWorkerEventHandler(AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetAllWorldsAysnc request.
    /// </summary>
    public class GetAllWorldsCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<GwWorld> worlds;

        /// <summary>
        /// </summary>
        /// <param name="worlds"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetAllWorldsCompletedEventArgs(IEnumerable<GwWorld> worlds, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.worlds = worlds;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<GwWorld> Worlds
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.worlds;
            }
        }
    }
}