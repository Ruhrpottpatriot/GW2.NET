// <copyright file="IFindable.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFindable<TKey, TValue>
    {
        /// <summary>Finds the object with the given identifier.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by identifier.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The object with the given identifier, or a null reference.</returns>
        Task<TValue> FindSingleAsync(TKey identifier);

        /// <summary>Finds the object with the given identifier.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by identifier.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The object with the given identifier, or a null reference.</returns>
        Task<TValue> FindSingleAsync(TKey identifier, CancellationToken cancellationToken);

        /// <summary>Finds every object with one of the given identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching for a range of objects.</exception>
        /// <exception cref="ArgumentNullException">The value of <paramref name="identifiers"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The value of <paramref name="identifiers"/> is an empty collection.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of objects with one of the given identifiers.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindMultipleAsync(ICollection<TKey> identifiers);

        /// <summary>Finds every object with one of the given identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching for a range of objects.</exception>
        /// <exception cref="ArgumentNullException">The value of <paramref name="identifiers"/> is a null reference.</exception>
        /// <exception cref="ArgumentException">The value of <paramref name="identifiers"/> is an empty collection.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of objects with one of the given identifiers.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindMultipleAsync(ICollection<TKey> identifiers, CancellationToken cancellationToken);

        /// <summary>Finds every object.</summary>
        /// <exception cref="NotSupportedException">The data source does not support searching for all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of objects.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync();

        /// <summary>Finds every object.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching for all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of objects.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(CancellationToken cancellationToken);
    }
}