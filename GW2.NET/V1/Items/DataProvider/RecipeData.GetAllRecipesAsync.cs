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
    ///     Delegate for GetAllRecipesAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetAllRecipesCompletedEventHandler(object sender, GetAllRecipesCompletedEventArgs e);

    public partial class RecipeData
    {
        private SendOrPostCallback onGetAllRecipesCompletedDelegate;

        private SendOrPostCallback onGetAllRecipesProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetAllRecipesAsync request completes.
        /// </summary>
        public event GetAllRecipesCompletedEventHandler GetAllRecipesCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetAllRecipesAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetAllRecipesProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllRecipesCompletedCallback(object operationState)
        {
            var e = operationState as GetAllRecipesCompletedEventArgs;

            OnGetRecipeCompleted(e);
        }

        private void OnGetRecipeCompleted(GetAllRecipesCompletedEventArgs e)
        {
            if (GetAllRecipesCompleted != null)
            {
                GetAllRecipesCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetAllRecipesReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetAllRecipes(e);
        }

        private void OnProgressChangedGetAllRecipes(ProgressChangedEventArgs e)
        {
            if (GetAllRecipesProgressChanged != null)
            {
                GetAllRecipesProgressChanged(this, e);
            }
        }

        private void GetAllRecipesCompletionMethod(IEnumerable<Recipe> recipes, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetAllRecipesCompletedEventArgs(recipes, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetAllRecipesCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetRecipeAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="asyncOp"></param>
        private void GetAllRecipesWorker(AsyncOperation asyncOp)
        {
            Exception e = null;
            IEnumerable<Recipe> recipesToReturn = new Recipe[0];

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    recipesToReturn = this.Recipes;
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetAllRecipesProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetAllRecipesCompletionMethod(recipesToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetAllRecipes request. TaskId must be unique.
        /// </summary>
        /// <param name="taskId"></param>
        public virtual void GetAllRecipesAsync(object taskId)
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

            GetAllRecipesWorkerEventHandler workerDelegate = GetAllRecipesWorker;

            workerDelegate.BeginInvoke(asyncOp, null, null);
        }

        private delegate void GetAllRecipesWorkerEventHandler(AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetAllRecipesAysnc request.
    /// </summary>
    public class GetAllRecipesCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly IEnumerable<Recipe> recipes;

        /// <summary>
        /// </summary>
        /// <param name="recipes"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetAllRecipesCompletedEventArgs(IEnumerable<Recipe> recipes, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.recipes = recipes;
        }

        /// <summary>
        /// </summary>
        public IEnumerable<Recipe> Recipes
        {
            get
            {
                RaiseExceptionIfNecessary();

                return this.recipes;
            }
        }
    }
}
