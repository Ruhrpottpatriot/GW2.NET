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
    ///     Delegate for GetMapFloorFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetMapFloorFromIdCompletedEventHandler(object sender, GetMapFloorFromIdCompletedEventArgs e);

    public partial class MapFloorData
    {
        private SendOrPostCallback onGetMapFloorFromIdCompletedDelegate;

        private SendOrPostCallback onGetMapFloorFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetMapFloorFromIdAsync request completes.
        /// </summary>
        public event GetMapFloorFromIdCompletedEventHandler GetMapFloorFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetMapFloorFromIdAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetMapFloorFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetMapFloorFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetMapFloorFromIdCompletedEventArgs;

            OnGetMapFloorCompleted(e);
        }

        private void OnGetMapFloorCompleted(GetMapFloorFromIdCompletedEventArgs e)
        {
            if (GetMapFloorFromIdCompleted != null)
            {
                GetMapFloorFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetMapFloorFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetMapFloorFromId(e);
        }

        private void OnProgressChangedGetMapFloorFromId(ProgressChangedEventArgs e)
        {
            if (GetMapFloorFromIdProgressChanged != null)
            {
                GetMapFloorFromIdProgressChanged(this, e);
            }
        }

        private void GetMapFloorFromIdCompletionMethod(int continentId, int floor, MapFloor mapFloor, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetMapFloorFromIdCompletedEventArgs(continentId, floor, mapFloor, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetMapFloorFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetMapFloorFromIdAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="floor"></param>
        /// <param name="asyncOp"></param>
        private void GetMapFloorFromIdWorker(int continentId, int floor, AsyncOperation asyncOp)
        {
            Exception e = null;
            var mapFloorToReturn = new MapFloor();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    mapFloorToReturn = this[continentId, floor];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetMapFloorFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetMapFloorFromIdCompletionMethod(continentId, floor, mapFloorToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetMapFloorFromId request. TaskId must be unique.
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="floor"></param>
        /// <param name="taskId"></param>
        public virtual void GetMapFloorFromIdAsync(int continentId, int floor, object taskId)
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

            GetMapFloorFromIdWorkerEventHandler workerDelegate = GetMapFloorFromIdWorker;

            workerDelegate.BeginInvoke(continentId, floor, asyncOp, null, null);
        }

        private delegate void GetMapFloorFromIdWorkerEventHandler(int continentId, int floor, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetMapFloorFromIdAysnc request.
    /// </summary>
    public class GetMapFloorFromIdCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly MapFloor mapFloor;

        private readonly int floor;

        private readonly int continentId;

        /// <summary>
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="floor"></param>
        /// <param name="mapFloor"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetMapFloorFromIdCompletedEventArgs(int continentId, int floor, MapFloor mapFloor, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.continentId = continentId;
            this.floor = floor;
            this.mapFloor = mapFloor;
        }

        /// <summary>
        /// </summary>
        public int ContinentId
        {
            get
            {
                RaiseExceptionIfNecessary();

                return continentId;
            }
        }

        /// <summary>
        /// </summary>
        public int Floor
        {
            get
            {
                RaiseExceptionIfNecessary();

                return floor;
            }
        }

        /// <summary>
        /// </summary>
        public MapFloor MapFloor
        {
            get
            {
                RaiseExceptionIfNecessary();

                return mapFloor;
            }
        }
    }
}
