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
    ///     Delegate for GetColourFromNameAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetColourFromNameCompletedEventHandler(object sender, GetColourFromNameCompletedEventArgs e);

    public partial class ColourData
    {
        private SendOrPostCallback onGetColourFromNameCompletedDelegate;

        private SendOrPostCallback onGetColourFromNameProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetColourAsync request completes.
        /// </summary>
        public event GetColourFromNameCompletedEventHandler GetColourFromNameCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetColourAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetColourFromNameProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetColourFromNameCompletedCallback(object operationState)
        {
            var e = operationState as GetColourFromNameCompletedEventArgs;

            OnGetColourCompleted(e);
        }

        private void OnGetColourCompleted(GetColourFromNameCompletedEventArgs e)
        {
            if (GetColourFromNameCompleted != null)
            {
                GetColourFromNameCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetColourFromNameReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetColourFromName(e);
        }

        private void OnProgressChangedGetColourFromName(ProgressChangedEventArgs e)
        {
            if (GetColourFromNameProgressChanged != null)
            {
                GetColourFromNameProgressChanged(this, e);
            }
        }

        private void GetColourFromNameCompletionMethod(int colourId, GwColour colour, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetColourFromNameCompletedEventArgs(colourId, colour, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetColourFromNameCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetColourAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="colourId"></param>
        /// <param name="asyncOp"></param>
        private void GetColourFromNameWorker(int colourId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var colourToReturn = new GwColour();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    colourToReturn = this[colourId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetColourFromNameProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetColourFromNameCompletionMethod(colourId, colourToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetColour request. TaskId must be unique.
        /// </summary>
        /// <param name="colourId"></param>
        /// <param name="taskId"></param>
        public virtual void GetColourFromNameAsync(int colourId, object taskId)
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

            GetColourFromNameWorkerEventHandler workerDelegate = GetColourFromNameWorker;

            workerDelegate.BeginInvoke(colourId, asyncOp, null, null);
        }

        private delegate void GetColourFromNameWorkerEventHandler(int colourId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetColourFromNameAysnc request.
    /// </summary>
    public class GetColourFromNameCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly GwColour colour;

        private readonly int colourId;

        /// <summary>
        /// </summary>
        /// <param name="colourId"></param>
        /// <param name="colour"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetColourFromNameCompletedEventArgs(int colourId, GwColour colour, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.colourId = colourId;
            this.colour = colour;
        }

        /// <summary>
        /// </summary>
        public int ColourId
        {
            get
            {
                RaiseExceptionIfNecessary();

                return colourId;
            }
        }

        /// <summary>
        /// </summary>
        public GwColour Colour
        {
            get
            {
                RaiseExceptionIfNecessary();

                return colour;
            }
        }
    }
}
