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
    ///     Delegate for GetEventsFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetEventsFromIdCompletedEventHandler(object sender, GetEventsFromIdCompletedEventArgs e);

    public partial class EventData
    {
        private SendOrPostCallback onGetEventsFromIdCompletedDelegate;

        private SendOrPostCallback onGetEventsFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetEventsFromIdAsync request completes.
        /// </summary>
        public event GetEventsFromIdCompletedEventHandler GetEventsFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetEventsFromIdAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetEventsFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetEventsFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetEventsFromIdCompletedEventArgs;

            OnGetEventsFromIdCompleted(e);
        }

        private void OnGetEventsFromIdCompleted(GetEventsFromIdCompletedEventArgs e)
        {
            if (GetEventsFromIdCompleted != null)
            {
                GetEventsFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetEventsFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetEventsFromId(e);
        }

        private void OnProgressChangedGetEventsFromId(ProgressChangedEventArgs e)
        {
            if (GetEventsFromIdProgressChanged != null)
            {
                GetEventsFromIdProgressChanged(this, e);
            }
        }

        private void GetEventsFromIdCompletionMethod(Guid id, IEnumerable<GwEvent> events, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetEventsFromIdCompletedEventArgs(id, events, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetEventsFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetEventsFromIdAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asyncOp"></param>
        private void GetEventsFromIdWorker(Guid id, AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<GwEvent> eventsToReturn = new GwEvent[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    eventsToReturn = this[id];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetEventsFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetEventsFromIdCompletionMethod(id, eventsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetEventsFromId request. TaskId must be unique.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskId"></param>
        public virtual void GetEventsFromIdAsync(Guid id, object taskId)
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

            GetEventsFromIdWorkerEventHandler workerDelegate = GetEventsFromIdWorker;

            workerDelegate.BeginInvoke(id, asyncOp, null, null);
        }

        private delegate void GetEventsFromIdWorkerEventHandler(Guid id, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetEventsFromIdAysnc request.
    /// </summary>
    public class GetEventsFromIdCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<GwEvent> events;

        private readonly Guid id;

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="events"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetEventsFromIdCompletedEventArgs(Guid id, IEnumerable<GwEvent> events, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.id = id;
            this.events = events;
        }

        /// <summary>
        /// </summary>
        public Guid Id
        {
            get
            {
                RaiseExceptionIfNecessary();

                return id;
            }
        }

        /// <summary>
        /// </summary>
        public IEnumerable<GwEvent> Events
        {
            get
            {
                RaiseExceptionIfNecessary();

                return events;
            }
        }
    }
}
