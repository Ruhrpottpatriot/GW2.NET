// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Paginator.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for types that implement the <see cref="IPaginator{T}" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.V2.Common;

    /// <summary>Provides static extension methods for types that implement the <see cref="IPaginator{T}"/> interface.</summary>
    public static class Paginator
    {
        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<ICollectionPage<T>> FindAllPages<T>(this IPaginator<T> instance)
        {
            var page = instance.FindPage(0);
            if (page != null)
            {
                yield return page;
                for (var pageIndex = 1; pageIndex < page.PageCount; pageIndex++)
                {
                    yield return instance.FindPage(pageIndex);
                }
            }
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<ICollectionPage<T>> FindAllPages<T>(this IPaginator<T> instance, int pageSize)
        {
            var page = instance.FindPage(0, pageSize);
            if (page != null)
            {
                yield return page;
                for (var pageIndex = 1; pageIndex < page.PageCount; pageIndex++)
                {
                    yield return instance.FindPage(pageIndex, pageSize);
                }
            }
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance)
        {
            return FindAllPagesAsync(instance, CancellationToken.None);
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, CancellationToken cancellationToken)
        {
            var page = instance.FindPage(0);
            if (page != null)
            {
                var tcs = new TaskCompletionSource<ICollectionPage<T>>();
                tcs.SetResult(page);
                yield return tcs.Task;
                for (var pageIndex = 1; pageIndex < page.PageCount; pageIndex++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }

                    yield return instance.FindPageAsync(pageIndex, cancellationToken);
                }
            }
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageSize)
        {
            return FindAllPagesAsync(instance, pageSize, CancellationToken.None);
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageSize, CancellationToken cancellationToken)
        {
            var page = instance.FindPage(0, pageSize);
            if (page != null)
            {
                var tcs = new TaskCompletionSource<ICollectionPage<T>>();
                tcs.SetResult(page);
                yield return tcs.Task;
                for (var pageIndex = 1; pageIndex < page.PageCount; pageIndex++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }

                    yield return instance.FindPageAsync(pageIndex, pageSize, cancellationToken);
                }
            }
        }
    }
}