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
    ///     Delegate for GetRecipeFromIdAsync completion event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GetRecipeFromIdCompletedEventHandler(object sender, GetRecipeFromIdCompletedEventArgs e);

    public partial class RecipeData
    {
        private SendOrPostCallback onGetRecipeFromIdCompletedDelegate;

        private SendOrPostCallback onGetRecipeFromIdProgressReportDelegate;

        /// <summary>
        ///     This event fires when a GetRecipeAsync request completes.
        /// </summary>
        public event GetRecipeFromIdCompletedEventHandler GetRecipeFromIdCompleted;

        /// <summary>
        ///     This event fires when the progress of a GetRecipeAsync event is updated.
        /// </summary>
        public event ProgressChangedEventHandler GetRecipeFromIdProgressChanged;

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetRecipeFromIdCompletedCallback(object operationState)
        {
            var e = operationState as GetRecipeFromIdCompletedEventArgs;

            OnGetRecipeCompleted(e);
        }

        private void OnGetRecipeCompleted(GetRecipeFromIdCompletedEventArgs e)
        {
            if (GetRecipeFromIdCompleted != null)
            {
                GetRecipeFromIdCompleted(this, e);
            }
        }

        // This method is invoked via the AsyncOperation object,
        // so it is guaranteed to be executed on the correct thread.
        private void GetRecipeFromIdReportProgressCallback(object state)
        {
            var e = state as ProgressChangedEventArgs;

            OnProgressChangedGetRecipeFromId(e);
        }

        private void OnProgressChangedGetRecipeFromId(ProgressChangedEventArgs e)
        {
            if (GetRecipeFromIdProgressChanged != null)
            {
                GetRecipeFromIdProgressChanged(this, e);
            }
        }

        private void GetRecipeFromIdCompletionMethod(int recipeId, Recipe recipe, Exception exception, bool canceled,
                                              AsyncOperation asyncOp)
        {
            if (!canceled)
            {
                lock (userStateToLifetime.SyncRoot)
                {
                    userStateToLifetime.Remove(asyncOp.UserSuppliedState);
                }
            }

            var e = new GetRecipeFromIdCompletedEventArgs(recipeId, recipe, exception, canceled, asyncOp.UserSuppliedState);

            asyncOp.PostOperationCompleted(onGetRecipeFromIdCompletedDelegate, e);
        }

        /// <summary>
        ///     Performs the actual GetRecipeAsync request. This method
        ///     is exectued on the worker thread.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="asyncOp"></param>
        private void GetRecipeFromIdWorker(int recipeId, AsyncOperation asyncOp)
        {
            Exception e = null;
            var recipeToReturn = new Recipe();

            if (!TaskCanceled(asyncOp.UserSuppliedState))
            {
                try
                {
                    recipeToReturn = this[recipeId];
                    var pe = new ProgressChangedEventArgs(100, asyncOp.UserSuppliedState);
                    asyncOp.Post(onGetRecipeFromIdProgressReportDelegate, pe);
                }
                catch (Exception ex)
                {
                    e = ex;
                }
            }

            GetRecipeFromIdCompletionMethod(recipeId, recipeToReturn, e, TaskCanceled(asyncOp.UserSuppliedState), asyncOp);
        }

        /// <summary>
        ///     Starts an asynchronous GetRecipe request. TaskId must be unique.
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="taskId"></param>
        public virtual void GetRecipeFromIdAsync(int recipeId, object taskId)
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

            GetRecipeFromIdWorkerEventHandler workerDelegate = GetRecipeFromIdWorker;

            workerDelegate.BeginInvoke(recipeId, asyncOp, null, null);
        }

        private delegate void GetRecipeFromIdWorkerEventHandler(int recipeId, AsyncOperation asyncOp);
    }

    /// <summary>
    ///     Holds the results of a GetRecipeFromIdAysnc request.
    /// </summary>
    public class GetRecipeFromIdCompletedEventArgs : AsyncCompletedEventArgs
    {
        private readonly Recipe recipe;

        private readonly int recipeId;

        /// <summary>
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="recipe"></param>
        /// <param name="e"></param>
        /// <param name="canceled"></param>
        /// <param name="state"></param>
        public GetRecipeFromIdCompletedEventArgs(int recipeId, Recipe recipe, Exception e, bool canceled, object state)
            : base(e, canceled, state)
        {
            this.recipeId = recipeId;
            this.recipe = recipe;
        }

        /// <summary>
        /// </summary>
        public int RecipeId
        {
            get
            {
                RaiseExceptionIfNecessary();

                return recipeId;
            }
        }

        /// <summary>
        /// </summary>
        public Recipe Recipe
        {
            get
            {
                RaiseExceptionIfNecessary();

                return recipe;
            }
        }
    }
}
