using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using GW2DotNET.V1.Items.Models;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    ///     Delegate for GetAllColoursAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetAllColoursCompletedEventHandler(object sender, GetAllColoursCompletedEventArgs e);

    public partial class ColourData
    {
        private SendOrPostCallback onGetAllColoursCompletedDelegate;

        private SendOrPostCallback onGetAllColoursProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetAllColoursAsync request completes.
        /// </summary>
        public event GetAllColoursCompletedEventHandler GetAllColoursCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetAllColoursAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetAllColoursProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllColoursCompletedCallback(object operationState)
        {
            var e = operationState as GetAllColoursCompletedEventArgs;

            OnGetColourCompleted(e);
        }

        private void OnGetColourCompleted(GetAllColoursCompletedEventArgs e)
        {
            if (GetAllColoursCompleted != null)
            {
                GetAllColoursCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllColoursReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetAllColours(e);
        }

        private void OnProgressChangedGetAllColours(ProgressChangedEventArgs e)
        {
            if (GetAllColoursProgressChanged != null)
            {
                GetAllColoursProgressChanged(this, e);
            }
        }

        private void GetAllColoursCompletionMethod(IEnumerable<GwColour> colours, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetAllColoursCompletedEventArgs(colours, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetAllColoursCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetColourAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="colourId"></param>
        /// <param name="asyncOp"></param>
        private void GetAllColoursWorker(AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<GwColour> coloursToReturn = new GwColour[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    coloursToReturn = this.Colours;
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetAllColoursProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetAllColoursCompletionMethod(coloursToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetAllColours request. TaskId must be unique.
        /// </summary>
        /// <param name="taskId"></param>
        public virtual void GetAllColoursAsync(object taskId)
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

            GetAllColoursWorkerEventHandler workerDelegate = GetAllColoursWorker;

            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private delegate void GetAllColoursWorkerEventHandler(AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetAllColoursAysnc request.
    /// </summary>
    public class GetAllColoursCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<GwColour> colours;

        /// <summary>
        /// </summary>
        /// <param name="colours"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetAllColoursCompletedEventArgs(IEnumerable<GwColour> colours, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.colours = colours;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<GwColour> Colours
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.colours;
            }
        }
    }
}
