// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginatorContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The code contract class for <see cref="IPaginator{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>The code contract class for <see cref="IPaginator{T}"/>.</summary>
    /// <typeparam name="T">The type of elements</typeparam>
    [ContractClassFor(typeof(IPaginator<>))]
    internal abstract class PaginatorContract<T> : IPaginator<T>
    {
        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<T> GetPage(int page)
        {
            Contract.Requires(page >= 0);
            Contract.Ensures(Contract.Result<ICollectionPage<T>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number and maximum size.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public ICollectionPage<T> GetPage(int page, int pageSize)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<ICollectionPage<T>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<T>> GetPageAsync(int page)
        {
            Contract.Requires(page >= 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<T>> GetPageAsync(int page, CancellationToken cancellationToken)
        {
            Contract.Requires(page >= 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<T>> GetPageAsync(int page, int pageSize)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a page with the specified page number.</summary>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The maximum number of page elements.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The page.</returns>
        public Task<ICollectionPage<T>> GetPageAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(pageSize > 0);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollectionPage<T>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}