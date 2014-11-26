// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Paginator.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for types that implement the <see cref="IPaginator{T}" /> interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace GW2NET.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides static extension methods for types that implement the <see cref="IPaginator{T}"/> interface.</summary>
    public static class Paginator
    {
        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Lazy<ICollectionPage<T>>> FindAllPages<T>(this IPaginator<T> instance, int pageCount)
        {
            Contract.Requires(instance != null);
            Contract.Ensures(Contract.Result<IEnumerable<Lazy<ICollectionPage<T>>>>() != null);
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
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Lazy<ICollectionPage<T>>> FindAllPages<T>(this IPaginator<T> instance, int pageSize, int pageCount)
        {
            Contract.Requires(instance != null);
            Contract.Ensures(Contract.Result<IEnumerable<ICollectionPage<T>>>() != null);
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
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageCount)
        {
            Contract.Requires(instance != null);
            Contract.Ensures(Contract.Result<IEnumerable<Task<ICollectionPage<T>>>>() != null);
            return FindAllPagesAsync(instance, pageCount, CancellationToken.None);
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageCount, CancellationToken cancellationToken)
        {
            Contract.Requires(instance != null);
            Contract.Ensures(Contract.Result<IEnumerable<Task<ICollectionPage<T>>>>() != null);
            for (var pageIndex = 0; pageIndex < pageCount; pageIndex++)
            {
                yield return instance.FindPageAsync(pageIndex, cancellationToken);
            }
        }

        /// <summary>Finds a collection of all pages.</summary>
        /// <param name="instance">The instance of <see cref="IPaginator{T}"/> that provides the pages.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="pageCount">The number of pages to get.</param>
        /// <typeparam name="T">The type of elements on the page.</typeparam>
        /// <returns>A collection of pages.</returns>
        public static IEnumerable<Task<ICollectionPage<T>>> FindAllPagesAsync<T>(this IPaginator<T> instance, int pageSize, int pageCount)
        {
            Contract.Requires(instance != null);
            Contract.Ensures(Contract.Result<IEnumerable<Task<ICollectionPage<T>>>>() != null);
            return FindAllPagesAsync(instance, pageSize, pageCount, CancellationToken.None);
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
            Contract.Requires(instance != null);
            Contract.Ensures(Contract.Result<IEnumerable<Task<ICollectionPage<T>>>>() != null);
            for (var pageIndex = 0; pageIndex < pageCount; pageIndex++)
            {
                yield return instance.FindPageAsync(pageIndex, pageSize, cancellationToken);
            }
        }
    }
}