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
    ///     Delegate for GetAllMapsAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetAllMapsCompletedEventHandler(object sender, GetAllMapsCompletedEventArgs e);

    public partial class MapsData
    {
        private SendOrPostCallback onGetAllMapsCompletedDelegate;

        private SendOrPostCallback onGetAllMapsProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetAllMapsAsync request completes.
        /// </summary>
        public event GetAllMapsCompletedEventHandler GetAllMapsCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetAllMapsAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetAllMapsProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllMapsCompletedCallback(object operationState)
        {
            var e = operationState as GetAllMapsCompletedEventArgs;

            OnGetMapCompleted(e);
        }

        private void OnGetMapCompleted(GetAllMapsCompletedEventArgs e)
        {
            if (GetAllMapsCompleted != null)
            {
                GetAllMapsCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllMapsReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetAllMaps(e);
        }

        private void OnProgressChangedGetAllMaps(ProgressChangedEventArgs e)
        {
            if (GetAllMapsProgressChanged != null)
            {
                GetAllMapsProgressChanged(this, e);
            }
        }

        private void GetAllMapsCompletionMethod(IEnumerable<Map> maps, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetAllMapsCompletedEventArgs(maps, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetAllMapsCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetAllMapsAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="asyncOp"></param>
        private void GetAllMapsWorker(AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<Map> mapsToReturn = new Map[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    mapsToReturn = this.Maps;
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetAllMapsProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetAllMapsCompletionMethod(mapsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetAllMaps request. TaskId must be unique.
        /// </summary>
        /// <param name="taskId"></param>
        public virtual void GetAllMapsAsync(object taskId)
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

            GetAllMapsWorkerEventHandler workerDelegate = GetAllMapsWorker;

            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private delegate void GetAllMapsWorkerEventHandler(AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetAllMapsAysnc request.
    /// </summary>
    public class GetAllMapsCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<Map> maps;

        /// <summary>
        /// </summary>
        /// <param name="maps"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetAllMapsCompletedEventArgs(IEnumerable<Map> maps, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.maps = maps;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<Map> Maps
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.maps;
            }
        }
    }
}
