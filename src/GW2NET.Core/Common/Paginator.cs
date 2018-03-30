// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Paginator.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for types that implement the <see cref="IPaginator{T}" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides static extension methods for types that implement the <see cref="IPaginator{T}"/> interface.</summary>
    public static class Paginator
    {
        static Paginator()
        {
            MaxRetryCount = 3;
        }

        /// <summary>Gets or sets the maximum number of retry attempts per page. The default value is 3.</summary>
        public static int MaxRetryCount { get; set; }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="instance"/> is a null reference.</exception>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Lazy<ICollectionPage<T>>> FindAllPages<T>(this IPaginator<T> instance, int pageCount)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            for (var pageIndex = 0; pageIndex < pageCount; pageIndex++)
            {
                var page = pageIndex;
                yield return new Lazy<ICollectionPage<T>>(() => instance.FindPage(page));
            }
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="instance"/> is a null reference.</exception>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Lazy<ICollectionPage<T>>> FindAllPages<T>(this IPaginator<T> instance, int pageSize, int pageCount)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            for (var pageIndex = 0; pageIndex < pageCount; pageIndex++)
            {
                var page = pageIndex;
                yield return new Lazy<ICollectionPage<T>>(() => instance.FindPage(page, pageSize));
            }
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <exception cref="ArgumentNullException">The value of <paramref name="instance"/> is a null reference.</exception>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageCount)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            return Interleaved(FindAllPagesAsyncImpl(instance, pageCount, CancellationToken.None));
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageCount, CancellationToken cancellationToken)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            return Interleaved(FindAllPagesAsyncImpl(instance, pageCount, cancellationToken));
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageSize, int pageCount)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            return Interleaved(FindAllPagesAsyncImpl(instance, pageSize, pageCount, CancellationToken.None));
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageSize, int pageCount, CancellationToken cancellationToken)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            return Interleaved(FindAllPagesAsyncImpl(instance, pageSize, pageCount, cancellationToken));
        }

        private static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsyncImpl<T>(
            IPaginator<T> instance,
            int pageCount,
            CancellationToken cancellationToken)
        {
            Debug.Assert(instance != null, "instance != null");
            for (var pageIndex = 0; pageIndex < pageCount; pageIndex++)
            {
                yield return RetryOnFault(() => instance.FindPageAsync(pageIndex, cancellationToken), MaxRetryCount);
            }
        }

        private static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsyncImpl<T>(
            IPaginator<T> instance,
            int pageSize,
            int pageCount,
            CancellationToken cancellationToken)
        {
            Debug.Assert(instance != null, "instance != null");
            for (var pageIndex = 0; pageIndex < pageCount; pageIndex++)
            {
                yield return RetryOnFault(() => instance.FindPageAsync(pageIndex, pageSize, cancellationToken), MaxRetryCount);
            }
        }

        private static async Task<T> RetryOnFault<T>(Func<Task<T>> function, int maxTries)
        {
            if (maxTries <= 0)
            {
                var task = function();
                if (task == null)
                {
                    return default(T);
                }

                return await task.ConfigureAwait(false);
            }

            for (int i = 0; i < maxTries; i++)
            {
                var task = function();
                if (task == null)
                {
                    continue;
                }

                try
                {
                    return await task.ConfigureAwait(false);
                }
                catch
                {
                    if (i == maxTries - 1)
                    {
                        throw;
                    }
                }
            }

            return default(T);
        }

        private static IEnumerable<Task<T>> Interleaved<T>(IEnumerable<Task<T>> tasks)
        {
            var inputTasks = tasks.ToList();
            var sources = (from _ in Enumerable.Range(0, inputTasks.Count)
                           select new TaskCompletionSource<T>()).ToList();
            int nextTaskIndex = -1;
            foreach (var inputTask in inputTasks)
            {
                inputTask.ContinueWith(completed =>
                {
                    var source = sources[Interlocked.Increment(ref nextTaskIndex)];
                    if (completed.IsFaulted)
                        source.TrySetException(completed.Exception.InnerExceptions);
                    else if (completed.IsCanceled)
                        source.TrySetCanceled();
                    else
                        source.TrySetResult(completed.Result);
                }, CancellationToken.None,
                   TaskContinuationOptions.ExecuteSynchronously,
                   TaskScheduler.Default);
            }
            return from source in sources
                   select source.Task;
        }
    }
}