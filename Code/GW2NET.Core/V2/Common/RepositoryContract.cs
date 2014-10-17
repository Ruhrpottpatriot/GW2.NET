// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The code contract class for <see cref="IRepository{TKey,TEntity}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>The code contract class for <see cref="IRepository{TKey,TEntity}"/>.</summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    [ContractClassFor(typeof(IRepository<,>))]
    internal abstract class RepositoryContract<TKey, TValue> : IRepository<TKey, TValue>
    {
        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public abstract ICollection<TKey> Discover();

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public abstract Task<ICollection<TKey>> DiscoverAsync();

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public abstract Task<ICollection<TKey>> DiscoverAsync(CancellationToken cancellationToken);

        /// <summary>Finds the <typeparamref name="TValue"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <typeparamref name="TValue"/> with the specified identifier.</returns>
        public TValue Find(TKey identifier)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Finds every <typeparamref name="TValue"/>.</summary>
        /// <returns>A collection of every <typeparamref name="TValue"/>.</returns>
        public IDictionaryRange<TKey, TValue> FindAll()
        {
            Contract.Ensures(Contract.Result<IDictionaryRange<TKey, TValue>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Finds every <typeparamref name="TValue"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <typeparamref name="TValue"/> with one of the specified identifiers.</returns>
        public IDictionaryRange<TKey, TValue> FindAll(ICollection<TKey> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Requires(identifiers.Count > 0);
            Contract.Ensures(Contract.Result<IDictionaryRange<TKey, TValue>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Finds every <typeparamref name="TValue"/>.</summary>
        /// <returns>A collection of every <typeparamref name="TValue"/>.</returns>
        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Finds every <typeparamref name="TValue"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of every <typeparamref name="TValue"/>.</returns>
        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Finds every <typeparamref name="TValue"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <returns>A collection every <typeparamref name="TValue"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Requires(identifiers.Count > 0);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Finds every <typeparamref name="TValue"/> with one of the specified identifiers.</summary>
        /// <param name="identifiers">The identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection every <typeparamref name="TValue"/> with one of the specified identifiers.</returns>
        public Task<IDictionaryRange<TKey, TValue>> FindAllAsync(ICollection<TKey> identifiers, CancellationToken cancellationToken)
        {
            Contract.Requires(identifiers != null);
            Contract.Requires(identifiers.Count > 0);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionaryRange<TKey, TValue>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Finds the <typeparamref name="TValue"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The <typeparamref name="TValue"/> with the specified identifier.</returns>
        public Task<TValue> FindAsync(TKey identifier)
        {
            Contract.Ensures(Contract.Result<Task>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Finds the <typeparamref name="TValue"/> with the specified identifier.</summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The <typeparamref name="TValue"/> with the specified identifier.</returns>
        public Task<TValue> FindAsync(TKey identifier, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public abstract ICollectionPage<TValue> GetPage(int page);

        /// <summary>Gets a page with the specified page number and maximum size.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public abstract ICollectionPage<TValue> GetPage(int page, int pageSize);

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public abstract Task<ICollectionPage<TValue>> GetPageAsync(int page);

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public abstract Task<ICollectionPage<TValue>> GetPageAsync(int page, CancellationToken cancellationToken);

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public abstract Task<ICollectionPage<TValue>> GetPageAsync(int page, int pageSize);

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public abstract Task<ICollectionPage<TValue>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}