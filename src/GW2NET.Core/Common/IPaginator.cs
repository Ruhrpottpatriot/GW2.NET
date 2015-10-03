// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPaginator.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for types that perform pagination.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for types that perform pagination.</summary>
    /// <typeparam name="T">The type of elements on the page.</typeparam>
    public interface IPaginator<T>
    {
        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        ICollectionPage<T> FindPage(int pageIndex);

        /// <summary>Finds the page with the specified page number and maximum size.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0 or <paramref name="pageSize"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        ICollectionPage<T> FindPage(int pageIndex, int pageSize);

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        Task<ICollectionPage<T>> FindPageAsync(int pageIndex);

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The page.</returns>
        Task<ICollectionPage<T>> FindPageAsync(int pageIndex, CancellationToken cancellationToken);

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0 or <paramref name="pageSize"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The page.</returns>
        Task<ICollectionPage<T>> FindPageAsync(int pageIndex, int pageSize);

        /// <summary>Finds the page with the specified page index.</summary>
        /// <param name="pageIndex">The page index to find.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support pagination.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="pageIndex"/> is less than 0 or <paramref name="pageSize"/> is less than 0.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The page.</returns>
        Task<ICollectionPage<T>> FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken);
    }
}