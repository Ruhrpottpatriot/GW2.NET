using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using GW2DotNET.V1.Items.Models.Items;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    ///     Delegate for GetItemFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetItemFromIdCompletedEventHandler(object sender, GetItemFromIdCompletedEventArgs e);

    public partial class ItemData
    {
        private SendOrPostCallback onGetItemFromIdCompletedDelegate;

        private SendOrPostCallback onGetItemFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetItemFromIdAsync request completes.
        /// </summary>
        public event GetItemFromIdCompletedEventHandler GetItemFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetItemFromIdAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetItemFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetItemFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetItemFromIdCompletedEventArgs;

            OnGetItemCompleted(e);
        }

        private void OnGetItemCompleted(GetItemFromIdCompletedEventArgs e)
        {
            if (GetItemFromIdCompleted != null)
            {
                GetItemFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetItemFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetItemFromId(e);
        }

        private void OnProgressChangedGetItemFromId(ProgressChangedEventArgs e)
        {
            if (GetItemFromIdProgressChanged != null)
            {
                GetItemFromIdProgressChanged(this, e);
            }
        }

        private void GetItemFromIdCompletionMethod(int itemId, Item item, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetItemFromIdCompletedEventArgs(itemId, item, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetItemFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetItemAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="asyncOp"></param>
        private void GetItemFromIdWorker(int itemId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var itemToReturn = new Item();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    itemToReturn = this[itemId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetItemFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetItemFromIdCompletionMethod(itemId, itemToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetItemFromId request. TaskId must be unique.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="taskId"></param>
        public virtual void GetItemFromIdAsync(int itemId, object taskId)
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

            GetItemFromIdWorkerEventHandler workerDelegate = GetItemFromIdWorker;

            workerDelegate.BeginInvoke(itemId, asyncOp, null, null);
        }

        private delegate void GetItemFromIdWorkerEventHandler(int itemId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetItemFromIdAysnc request.
    /// </summary>
    public class GetItemFromIdCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly Item item;

        private readonly int itemId;

        /// <summary>
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="item"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetItemFromIdCompletedEventArgs(int itemId, Item item, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.itemId = itemId;
            this.item = item;
        }

        /// <summary>
        /// </summary>
        public int ItemId
        {
            get
            {
                RaiseExceptionIfNecessary();

                return itemId;
            }
        }

        /// <summary>
        /// </summary>
        public Item Item
        {
            get
            {
                RaiseExceptionIfNecessary();

                return item;
            }
        }
    }
}
