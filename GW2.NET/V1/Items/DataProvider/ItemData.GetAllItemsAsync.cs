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
    ///     Delegate for GetAllItemsAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetAllItemsCompletedEventHandler(object sender, GetAllItemsCompletedEventArgs e);

    public partial class ItemData
    {
        private SendOrPostCallback onGetAllItemsCompletedDelegate;

        private SendOrPostCallback onGetAllItemsProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetAllItemsAsync request completes.
        /// </summary>
        public event GetAllItemsCompletedEventHandler GetAllItemsCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetAllItemsAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetAllItemsProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllItemsCompletedCallback(object operationState)
        {
            var e = operationState as GetAllItemsCompletedEventArgs;

            OnGetItemCompleted(e);
        }

        private void OnGetItemCompleted(GetAllItemsCompletedEventArgs e)
        {
            if (GetAllItemsCompleted != null)
            {
                GetAllItemsCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllItemsReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetAllItems(e);
        }

        private void OnProgressChangedGetAllItems(ProgressChangedEventArgs e)
        {
            if (GetAllItemsProgressChanged != null)
            {
                GetAllItemsProgressChanged(this, e);
            }
        }

        private void GetAllItemsCompletionMethod(IEnumerable<Item> items, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetAllItemsCompletedEventArgs(items, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetAllItemsCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetItemAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="asyncOp"></param>
        private void GetAllItemsWorker(AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<Item> itemsToReturn = new Item[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    itemsToReturn = this.AllItems;
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetAllItemsProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetAllItemsCompletionMethod(itemsToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetAllItems request. TaskId must be unique.
        /// </summary>
        /// <param name="taskId"></param>
        public virtual void GetAllItemsAsync(object taskId)
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

            GetAllItemsWorkerEventHandler workerDelegate = GetAllItemsWorker;

            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private delegate void GetAllItemsWorkerEventHandler(AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetAllItemsAysnc request.
    /// </summary>
    public class GetAllItemsCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<Item> items;

        /// <summary>
        /// </summary>
        /// <param name="items"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetAllItemsCompletedEventArgs(IEnumerable<Item> items, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.items = items;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<Item> Items
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.items;
            }
        }
    }
}
