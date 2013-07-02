using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using GW2DotNET.V1.Maps.Models;
using GW2DotNET.V1.World.Models;

namespace GW2DotNET.V1.World.DataProvider
{
    /// <summary>
    ///     Delegate for GetEventsFromMapAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetEventsFromMapCompletedEventHandler(object sender, GetEventsFromMapCompletedEventArgs e);

    public partial class EventData
    {
        private SendOrPostCallback onGetEventsFromMapCompletedDelegate;

        private SendOrPostCallback onGetEventsFromMapProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetEventsFromMapAsync request completes.
        /// </summary>
        public event GetEventsFromMapCompletedEventHandler GetEventsFromMapCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetEventsFromMapAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetEventsFromMapProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetEventsFromMapCompletedCallback(object operationState)
        {
            var e = operationState as GetEventsFromMapCompletedEventArgs;

            OnGetEventsFromMapCompleted(e);
        }

        private void OnGetEventsFromMapCompleted(GetEventsFromMapCompletedEventArgs e)
        {
            if (GetEventsFromMapCompleted != null)
            {
                GetEventsFromMapCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetEventsFromMapReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetEventsFromMap(e);
        }

        private void OnProgressChangedGetEventsFromMap(ProgressChangedEventArgs e)
        {
            if (GetEventsFromMapProgressChanged != null)
            {
                GetEventsFromMapProgressChanged(this, e);
            }
        }

        private void GetEventsFromMapCompletionMethod(Map map, IEnumerable<GwEvent> events, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetEventsFromMapCompletedEventArgs(map, events, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetEventsFromMapCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetEventsFromMapAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="asyncOp"></param>
        private void GetEventsFromMapWorker(Map map, AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<GwEvent> eventsToReturn = new GwEvent[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    eventsToReturn = this[map];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetEventsFromMapProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetEventsFromMapCompletionMethod(map, eventsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetEventsFromMap request. TaskId must be unique.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="taskId"></param>
        public virtual void GetEventsFromMapAsync(Map map, object taskId)
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

            GetEventsFromMapWorkerEventHandler workerDelegate = GetEventsFromMapWorker;

            workerDelegate.BeginInvoke(map, asyncOp, null, null);
        }

        private delegate void GetEventsFromMapWorkerEventHandler(Map map, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetEventsFromMapAysnc request.
    /// </summary>
    public class GetEventsFromMapCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<GwEvent> events;

        private readonly Map map;

        /// <summary>
        /// </summary>
        /// <param name="map"></param>
        /// <param name="events"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetEventsFromMapCompletedEventArgs(Map map, IEnumerable<GwEvent> events, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.map = map;
            this.events = events;
        }

        /// <summary>
        /// </summary>
        public Map Map
        {
            get
            {
                RaiseExceptionIfNecessary();

                return map;
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
