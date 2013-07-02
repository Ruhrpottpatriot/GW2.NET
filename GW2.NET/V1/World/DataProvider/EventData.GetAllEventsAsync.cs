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
    ///     Delegate for GetAllEventsAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetAllEventsCompletedEventHandler(object sender, GetAllEventsCompletedEventArgs e);

    public partial class EventData
    {
        private SendOrPostCallback onGetAllEventsCompletedDelegate;

        private SendOrPostCallback onGetAllEventsProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetAllEventsAsync request completes.
        /// </summary>
        public event GetAllEventsCompletedEventHandler GetAllEventsCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetAllEventsAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetAllEventsProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllEventsCompletedCallback(object operationState)
        {
            var e = operationState as GetAllEventsCompletedEventArgs;

            OnGetEventCompleted(e);
        }

        private void OnGetEventCompleted(GetAllEventsCompletedEventArgs e)
        {
            if (GetAllEventsCompleted != null)
            {
                GetAllEventsCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllEventsReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetAllEvents(e);
        }

        private void OnProgressChangedGetAllEvents(ProgressChangedEventArgs e)
        {
            if (GetAllEventsProgressChanged != null)
            {
                GetAllEventsProgressChanged(this, e);
            }
        }

        private void GetAllEventsCompletionMethod(IEnumerable<GwEvent> events, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetAllEventsCompletedEventArgs(events, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetAllEventsCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetAllEventsAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="asyncOp"></param>
        private void GetAllEventsWorker(AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<GwEvent> eventsToReturn = new GwEvent[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    eventsToReturn = this.AllEvents;
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetAllEventsProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetAllEventsCompletionMethod(eventsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetAllEvents request. TaskId must be unique.
        /// </summary>
        /// <param name="taskId"></param>
        public virtual void GetAllEventsAsync(object taskId)
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

            GetAllEventsWorkerEventHandler workerDelegate = GetAllEventsWorker;

            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private delegate void GetAllEventsWorkerEventHandler(AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetAllEventsAysnc request.
    /// </summary>
    public class GetAllEventsCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<GwEvent> events;

        /// <summary>
        /// </summary>
        /// <param name="events"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetAllEventsCompletedEventArgs(IEnumerable<GwEvent> events, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.events = events;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<GwEvent> Events
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.events;
            }
        }
    }
}
