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
    ///     Delegate for GetEventsFromWorldAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetEventsFromWorldCompletedEventHandler(object sender, GetEventsFromWorldCompletedEventArgs e);

    public partial class EventData
    {
        private SendOrPostCallback onGetEventsFromWorldCompletedDelegate;

        private SendOrPostCallback onGetEventsFromWorldProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetEventsFromWorldAsync request completes.
        /// </summary>
        public event GetEventsFromWorldCompletedEventHandler GetEventsFromWorldCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetEventsFromWorldAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetEventsFromWorldProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetEventsFromWorldCompletedCallback(object operationState)
        {
            var e = operationState as GetEventsFromWorldCompletedEventArgs;

            OnGetEventsFromWorldCompleted(e);
        }

        private void OnGetEventsFromWorldCompleted(GetEventsFromWorldCompletedEventArgs e)
        {
            if (GetEventsFromWorldCompleted != null)
            {
                GetEventsFromWorldCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetEventsFromWorldReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetEventsFromWorld(e);
        }

        private void OnProgressChangedGetEventsFromWorld(ProgressChangedEventArgs e)
        {
            if (GetEventsFromWorldProgressChanged != null)
            {
                GetEventsFromWorldProgressChanged(this, e);
            }
        }

        private void GetEventsFromWorldCompletionMethod(GwWorld world, IEnumerable<GwEvent> events, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetEventsFromWorldCompletedEventArgs(world, events, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetEventsFromWorldCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetEventsFromWorldAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="asyncOp"></param>
        private void GetEventsFromWorldWorker(GwWorld world, AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<GwEvent> eventsToReturn = new GwEvent[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    eventsToReturn = this[world];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetEventsFromWorldProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetEventsFromWorldCompletionMethod(world, eventsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetEventsFromWorld request. TaskId must be unique.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="taskId"></param>
        public virtual void GetEventsFromWorldAsync(GwWorld world, object taskId)
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

            GetEventsFromWorldWorkerEventHandler workerDelegate = GetEventsFromWorldWorker;

            workerDelegate.BeginInvoke(world, asyncOp, null, null);
        }

        private delegate void GetEventsFromWorldWorkerEventHandler(GwWorld world, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetEventsFromWorldAysnc request.
    /// </summary>
    public class GetEventsFromWorldCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<GwEvent> events;

        private readonly GwWorld world;

        /// <summary>
        /// </summary>
        /// <param name="world"></param>
        /// <param name="events"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetEventsFromWorldCompletedEventArgs(GwWorld world, IEnumerable<GwEvent> events, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.world = world;
            this.events = events;
        }

        /// <summary>
        /// </summary>
        public GwWorld World
        {
            get
            {
                RaiseExceptionIfNecessary();

                return world;
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
