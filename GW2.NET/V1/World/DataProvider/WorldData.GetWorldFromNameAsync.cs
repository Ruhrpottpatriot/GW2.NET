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
    ///     Delegate for GetWorldFromNameAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetWorldFromNameCompletedEventHandler(object sender, GetWorldFromNameCompletedEventArgs e);

    public partial class WorldData
    {
        private SendOrPostCallback onGetWorldFromNameCompletedDelegate;

        private SendOrPostCallback onGetWorldFromNameProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetWorldAsync request completes.
        /// </summary>
        public event GetWorldFromNameCompletedEventHandler GetWorldFromNameCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetWorldAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetWorldFromNameProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetWorldFromNameCompletedCallback(object operationState)
        {
            var e = operationState as GetWorldFromNameCompletedEventArgs;

            OnGetWorldCompleted(e);
        }

        private void OnGetWorldCompleted(GetWorldFromNameCompletedEventArgs e)
        {
            if (GetWorldFromNameCompleted != null)
            {
                GetWorldFromNameCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetWorldFromNameReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetWorldFromName(e);
        }

        private void OnProgressChangedGetWorldFromName(ProgressChangedEventArgs e)
        {
            if (GetWorldFromNameProgressChanged != null)
            {
                GetWorldFromNameProgressChanged(this, e);
            }
        }

        private void GetWorldFromNameCompletionMethod(int worldId, GwWorld world, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetWorldFromNameCompletedEventArgs(worldId, world, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetWorldFromNameCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetWorldAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="asyncOp"></param>
        private void GetWorldFromNameWorker(int worldId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var worldToReturn = new GwWorld();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    worldToReturn = this[worldId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetWorldFromNameProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetWorldFromNameCompletionMethod(worldId, worldToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetWorld request. TaskId must be unique.
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="taskId"></param>
        public virtual void GetWorldFromNameAsync(int worldId, object taskId)
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

            GetWorldFromNameWorkerEventHandler workerDelegate = GetWorldFromNameWorker;

            workerDelegate.BeginInvoke(worldId, asyncOp, null, null);
        }

        private delegate void GetWorldFromNameWorkerEventHandler(int worldId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetWorldFromNameAysnc request.
    /// </summary>
    public class GetWorldFromNameCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly GwWorld world;

        private readonly int worldId;

        /// <summary>
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="world"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetWorldFromNameCompletedEventArgs(int worldId, GwWorld world, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.worldId = worldId;
            this.world = world;
        }

        /// <summary>
        /// </summary>
        public int WorldId
        {
            get
            {
                RaiseExceptionIfNecessary();

                return worldId;
            }
        }

        /// <summary>
        /// </summary>
        public GwWorld World
        {
            get
            {
                RaiseExceptionIfNecessary();

                return world;
            }
        }
    }
}
