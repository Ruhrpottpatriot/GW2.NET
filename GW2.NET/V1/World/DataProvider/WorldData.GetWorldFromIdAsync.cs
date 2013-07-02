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
    ///     Delegate for GetWorldFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetWorldFromIdCompletedEventHandler(object sender, GetWorldFromIdCompletedEventArgs e);

    public partial class WorldData
    {
        private SendOrPostCallback onGetWorldFromIdCompletedDelegate;

        private SendOrPostCallback onGetWorldFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetWorldAsync request completes.
        /// </summary>
        public event GetWorldFromIdCompletedEventHandler GetWorldFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetWorldAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetWorldFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetWorldFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetWorldFromIdCompletedEventArgs;

            OnGetWorldCompleted(e);
        }

        private void OnGetWorldCompleted(GetWorldFromIdCompletedEventArgs e)
        {
            if (GetWorldFromIdCompleted != null)
            {
                GetWorldFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetWorldFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetWorldFromId(e);
        }

        private void OnProgressChangedGetWorldFromId(ProgressChangedEventArgs e)
        {
            if (GetWorldFromIdProgressChanged != null)
            {
                GetWorldFromIdProgressChanged(this, e);
            }
        }

        private void GetWorldFromIdCompletionMethod(int worldId, GwWorld world, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetWorldFromIdCompletedEventArgs(worldId, world, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetWorldFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetWorldAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="asyncOp"></param>
        private void GetWorldFromIdWorker(int worldId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var worldToReturn = new GwWorld();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    worldToReturn = this[worldId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetWorldFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetWorldFromIdCompletionMethod(worldId, worldToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetWorld request. TaskId must be unique.
        /// </summary>
        /// <param name="worldId"></param>
        /// <param name="taskId"></param>
        public virtual void GetWorldFromIdAsync(int worldId, object taskId)
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

            GetWorldFromIdWorkerEventHandler workerDelegate = GetWorldFromIdWorker;

            workerDelegate.BeginInvoke(worldId, asyncOp, null, null);
        }

        private delegate void GetWorldFromIdWorkerEventHandler(int worldId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetWorldFromIdAysnc request.
    /// </summary>
    public class GetWorldFromIdCompletedEventArgs : AsyncCompletedEventArgs
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
        public GetWorldFromIdCompletedEventArgs(int worldId, GwWorld world, Exception e, bool canceled, object state)
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
