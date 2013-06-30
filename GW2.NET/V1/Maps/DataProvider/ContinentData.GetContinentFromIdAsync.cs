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
    ///     Delegate for GetContinentFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetContinentFromIdCompletedEventHandler(object sender, GetContinentFromIdCompletedEventArgs e);

    public partial class ContinentData
    {
        private SendOrPostCallback onGetContinentFromIdCompletedDelegate;

        private SendOrPostCallback onGetContinentFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetContinentFromIdAsync request completes.
        /// </summary>
        public event GetContinentFromIdCompletedEventHandler GetContinentFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetContinentFromIdAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetContinentFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetContinentFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetContinentFromIdCompletedEventArgs;

            OnGetContinentCompleted(e);
        }

        private void OnGetContinentCompleted(GetContinentFromIdCompletedEventArgs e)
        {
            if (GetContinentFromIdCompleted != null)
            {
                GetContinentFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetContinentFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetContinentFromId(e);
        }

        private void OnProgressChangedGetContinentFromId(ProgressChangedEventArgs e)
        {
            if (GetContinentFromIdProgressChanged != null)
            {
                GetContinentFromIdProgressChanged(this, e);
            }
        }

        private void GetContinentFromIdCompletionMethod(int continentId, Continent continent, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetContinentFromIdCompletedEventArgs(continentId, continent, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetContinentFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetContinentFromIdAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="asyncOp"></param>
        private void GetContinentFromIdWorker(int continentId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var continentToReturn = new Continent();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    continentToReturn = this[continentId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetContinentFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetContinentFromIdCompletionMethod(continentId, continentToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetContinentFromId request. TaskId must be unique.
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="taskId"></param>
        public virtual void GetContinentFromIdAsync(int continentId, object taskId)
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

            GetContinentFromIdWorkerEventHandler workerDelegate = GetContinentFromIdWorker;

            workerDelegate.BeginInvoke(continentId, asyncOp, null, null);
        }

        private delegate void GetContinentFromIdWorkerEventHandler(int continentId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetContinentFromIdAysnc request.
    /// </summary>
    public class GetContinentFromIdCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly Continent continent;

        private readonly int continentId;

        /// <summary>
        /// </summary>
        /// <param name="continentId"></param>
        /// <param name="continent"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetContinentFromIdCompletedEventArgs(int continentId, Continent continent, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.continentId = continentId;
            this.continent = continent;
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
        public Continent Continent
        {
            get
            {
                RaiseExceptionIfNecessary();

                return continent;
            }
        }
    }
}
