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
    ///     Delegate for GetAllContinentsAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetAllContinentsCompletedEventHandler(object sender, GetAllContinentsCompletedEventArgs e);

    public partial class ContinentData
    {
        private SendOrPostCallback onGetAllContinentsCompletedDelegate;

        private SendOrPostCallback onGetAllContinentsProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetAllContinentsAsync request completes.
        /// </summary>
        public event GetAllContinentsCompletedEventHandler GetAllContinentsCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetAllContinentsAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetAllContinentsProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllContinentsCompletedCallback(object operationState)
        {
            var e = operationState as GetAllContinentsCompletedEventArgs;

            OnGetContinentCompleted(e);
        }

        private void OnGetContinentCompleted(GetAllContinentsCompletedEventArgs e)
        {
            if (GetAllContinentsCompleted != null)
            {
                GetAllContinentsCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllContinentsReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetAllContinents(e);
        }

        private void OnProgressChangedGetAllContinents(ProgressChangedEventArgs e)
        {
            if (GetAllContinentsProgressChanged != null)
            {
                GetAllContinentsProgressChanged(this, e);
            }
        }

        private void GetAllContinentsCompletionMethod(IEnumerable<Continent> continents, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetAllContinentsCompletedEventArgs(continents, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetAllContinentsCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetAllContinentsAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="asyncOp"></param>
        private void GetAllContinentsWorker(AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<Continent> continentsToReturn = new Continent[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    continentsToReturn = this.Continents;
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetAllContinentsProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetAllContinentsCompletionMethod(continentsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetAllContinents request. TaskId must be unique.
        /// </summary>
        /// <param name="taskId"></param>
        public virtual void GetAllContinentsAsync(object taskId)
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

            GetAllContinentsWorkerEventHandler workerDelegate = GetAllContinentsWorker;

            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private delegate void GetAllContinentsWorkerEventHandler(AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetAllContinentsAysnc request.
    /// </summary>
    public class GetAllContinentsCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<Continent> continents;

        /// <summary>
        /// </summary>
        /// <param name="continents"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetAllContinentsCompletedEventArgs(IEnumerable<Continent> continents, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.continents = continents;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<Continent> Continents
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.continents;
            }
        }
    }
}
