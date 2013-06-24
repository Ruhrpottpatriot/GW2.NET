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
    ///     Delegate for GetColourFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetColourFromIdCompletedEventHandler(object sender, GetColourFromIdCompletedEventArgs e);

    public partial class ColourData
    {
        private SendOrPostCallback onGetColourFromIdCompletedDelegate;

        private SendOrPostCallback onGetColourFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetColourAsync request completes.
        /// </summary>
        public event GetColourFromIdCompletedEventHandler GetColourFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetColourAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetColourFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetColourFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetColourFromIdCompletedEventArgs;

            OnGetColourCompleted(e);
        }

        private void OnGetColourCompleted(GetColourFromIdCompletedEventArgs e)
        {
            if (GetColourFromIdCompleted != null)
            {
                GetColourFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetColourFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetColourFromId(e);
        }

        private void OnProgressChangedGetColourFromId(ProgressChangedEventArgs e)
        {
            if (GetColourFromIdProgressChanged != null)
            {
                GetColourFromIdProgressChanged(this, e);
            }
        }

        private void GetColourFromIdCompletionMethod(int colourId, GwColour colour, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetColourFromIdCompletedEventArgs(colourId, colour, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetColourFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetColourAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="colourId"></param>
        /// <param name="asyncOp"></param>
        private void GetColourFromIdWorker(int colourId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var colourToReturn = new GwColour();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    colourToReturn = this[colourId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetColourFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetColourFromIdCompletionMethod(colourId, colourToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetColour request. TaskId must be unique.
        /// </summary>
        /// <param name="colourId"></param>
        /// <param name="taskId"></param>
        public virtual void GetColourFromIdAsync(int colourId, object taskId)
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

            GetColourFromIdWorkerEventHandler workerDelegate = GetColourFromIdWorker;

            workerDelegate.BeginInvoke(colourId, asyncOp, null, null);
        }

        private delegate void GetColourFromIdWorkerEventHandler(int colourId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetColourFromIdAysnc request.
    /// </summary>
    public class GetColourFromIdCompletedEventArgs : AsyncCompletedEventArgs
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
        public GetColourFromIdCompletedEventArgs(int colourId, GwColour colour, Exception e, bool canceled, object state)
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
