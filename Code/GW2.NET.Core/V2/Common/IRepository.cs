// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for repositories.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for repositories.</summary>
    /// <typeparam name="TKey">The type of the key values that uniquely identify the entities in the repository.</typeparam>
    /// <typeparam name="TValue">The type of the entities in the repository.</typeparam>
    [ContractClass(typeof(RepositoryContract<,>))]
    public interface IRepository<TKey, TValue> : IPaginator<TValue>
    {
        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        ICollection<TKey> Discover();

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        Task<ICollection<TKey>> DiscoverAsync();

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        Task<ICollection<TKey>> DiscoverAsync(CancellationToken cancellationToken);

        /// <summary>Finds the <see cref="TValue"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="TValue"/> with the specified identifier.</returns>
        TValue Find(TKey identifier);

        /// <summary>Finds every <see cref="TValue"/>.</summary>
        /// <returns>A collection of every <see cref="TValue"/>.</returns>
        IDictionaryRange<TKey, TValue> FindAll();

        /// <summary>Finds every <see cref="TValue"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="TValue"/> with one of the specified identifiers.</returns>
        IDictionaryRange<TKey, TValue> FindAll(ICollection<TKey> identifiers);

        /// <summary>Finds every <see cref="TValue"/>.</summary>
        /// <returns>A collection of every <see cref="TValue"/>.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync();

        /// <summary>Finds every <see cref="TValue"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <see cref="TValue"/>.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(CancellationToken cancellationToken);

        /// <summary>Finds every <see cref="TValue"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <see cref="TValue"/> with one of the specified identifiers.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers);

        /// <summary>Finds every <see cref="TValue"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <see cref="TValue"/> with one of the specified identifiers.</returns>
        Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers, CancellationToken cancellationToken);

        /// <summary>Finds the <see cref="TValue"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <see cref="TValue"/> with the specified identifier.</returns>
        Task<TValue> FindAsync(TKey identifier);

        /// <summary>Finds the <see cref="TValue"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <see cref="TValue"/> with the specified identifier.</returns>
        Task<TValue> FindAsync(TKey identifier, CancellationToken cancellationToken);
    }
}