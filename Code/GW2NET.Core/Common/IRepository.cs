// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for data sources.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for data sources.</summary>
    /// <typeparam name="TKey">The type of the key values that uniquely identify the entities in the repository.</typeparam>
    /// <typeparam name="TValue">The type of the entities in the repository.</typeparam>
    [ContractClass(typeof(ContractClassForIRepository<,>))]
    public interface IRepository<TKey, TValue> : IDiscoverable<TKey>, IPaginator<TValue>
    {
        /// <summary>Finds the object of type <typeparamref name="TValue"/> with the identifier of type <typeparamref name="TKey"/>.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <exception cref="NotSupportedException">The data source does not finding individual objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The object with the specified identifier, or a null reference.</returns>
        TValue Find(TKey identifier);

        /// <summary>Finds every object of type <typeparamref name="TValue"/>.</summary>
        /// <exception cref="NotSupportedException">The data source does not finding all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects.</returns>
        IDictionaryRange<TKey, TValue> FindAll();

        /// <summary>Finds every object with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <exception cref="NotSupportedException">The data source does not finding a range of objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects with one of the specified identifiers.</returns>
        IDictionaryRange<TKey, TValue> FindAll(ICollection<TKey> identifiers);

        /// <summary>Finds every object of type <typeparamref name="TValue"/>.</summary>
        /// <exception cref="NotSupportedException">The data source does not finding all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync();

        /// <summary>Finds every object of type <typeparamref name="TValue"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not finding all objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(CancellationToken cancellationToken);

        /// <summary>Finds every object with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <exception cref="NotSupportedException">The data source does not finding a range of objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects with one of the specified identifiers.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers);

        /// <summary>Finds every object with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers of the objects to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not finding a range of objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of objects with one of the specified identifiers.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers, CancellationToken cancellationToken);

        /// <summary>Finds the object of type <typeparamref name="TValue"/> with the identifier of type <typeparamref name="TKey"/>.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <exception cref="NotSupportedException">The data source does not finding individual objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The object with the specified identifier, or a null reference.</returns>
        Task<TValue> FindAsync(TKey identifier);

        /// <summary>Finds the object of type <typeparamref name="TValue"/> with the identifier of type <typeparamref name="TKey"/>.</summary>
        /// <param name="identifier">The identifier of the object to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not finding individual objects.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The object with the specified identifier, or a null reference.</returns>
        Task<TValue> FindAsync(TKey identifier, CancellationToken cancellationToken);
    }
}