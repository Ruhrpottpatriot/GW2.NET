using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using GW2DotNET.V1.Maps.Models;

namespace GW2DotNET.V1.Maps.DataProvider
{
    /// <summary>
    ///     Delegate for GetMapFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetMapFromIdCompletedEventHandler(object sender, GetMapFromIdCompletedEventArgs e);

    public partial class MapsData
    {
        private SendOrPostCallback onGetMapFromIdCompletedDelegate;

        private SendOrPostCallback onGetMapFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetMapFromIdAsync request completes.
        /// </summary>
        public event GetMapFromIdCompletedEventHandler GetMapFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetMapFromIdAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetMapFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetMapFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetMapFromIdCompletedEventArgs;

            OnGetMapCompleted(e);
        }

        private void OnGetMapCompleted(GetMapFromIdCompletedEventArgs e)
        {
            if (GetMapFromIdCompleted != null)
            {
                GetMapFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetMapFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetMapFromId(e);
        }

        private void OnProgressChangedGetMapFromId(ProgressChangedEventArgs e)
        {
            if (GetMapFromIdProgressChanged != null)
            {
                GetMapFromIdProgressChanged(this, e);
            }
        }

        private void GetMapFromIdCompletionMethod(int mapId, Map map, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetMapFromIdCompletedEventArgs(mapId, map, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetMapFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetMapFromIdAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="asyncOp"></param>
        private void GetMapFromIdWorker(int mapId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var mapToReturn = new Map();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    mapToReturn = this[mapId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetMapFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetMapFromIdCompletionMethod(mapId, mapToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetMapFromId request. TaskId must be unique.
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="taskId"></param>
        public virtual void GetMapFromIdAsync(int mapId, object taskId)
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

            GetMapFromIdWorkerEventHandler workerDelegate = GetMapFromIdWorker;

            workerDelegate.BeginInvoke(mapId, asyncOp, null, null);
        }

        private delegate void GetMapFromIdWorkerEventHandler(int mapId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetMapFromIdAysnc request.
    /// </summary>
    public class GetMapFromIdCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly Map map;

        private readonly int mapId;

        /// <summary>
        /// </summary>
        /// <param name="mapId"></param>
        /// <param name="map"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetMapFromIdCompletedEventArgs(int mapId, Map map, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.mapId = mapId;
            this.map = map;
        }

        /// <summary>
        /// </summary>
        public int MapId
        {
            get
            {
                RaiseExceptionIfNecessary();

                return mapId;
            }
        }

        /// <summary>
        /// </summary>
        public Map Map
        {
            get
            {
                RaiseExceptionIfNecessary();

                return map;
            }
        }
    }
}
