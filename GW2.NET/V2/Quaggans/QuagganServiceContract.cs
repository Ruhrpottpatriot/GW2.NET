// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The quaggan service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Quaggans
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Entities.Quaggans;
    using GW2DotNET.V2.Common;

    /// <summary>The quaggan service contract.</summary>
    [ContractClassFor(typeof(IQuagganService))]
    internal abstract class QuagganServiceContract : IQuagganService
    {
        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan.</returns>
        public Quaggan GetQuaggan(string identifier)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(identifier));
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan.</returns>
        public Task<Quaggan> GetQuagganAsync(string identifier)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(identifier));
            Contract.Ensures(Contract.Result<Task<Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A Quaggan.</returns>
        public Task<Quaggan> GetQuagganAsync(string identifier, CancellationToken cancellationToken)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(identifier));
            Contract.Ensures(Contract.Result<Task<Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<string> GetQuagganIdentifiers()
        {
            Contract.Ensures(Contract.Result<ICollection<string>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> GetQuagganIdentifiersAsync()
        {
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<string>> GetQuagganIdentifiersAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans()
        {
            Contract.Ensures(Contract.Result<Subdictionary<string, Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync()
        {
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Ensures(Contract.Result<Subdictionary<string, Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers, CancellationToken cancellationToken)
        {
            Contract.Requires(identifiers != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page)
        {
            Contract.Ensures(Contract.Result<PaginatedCollection<Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public PaginatedCollection<Quaggan> GetQuaggans(int page, int size)
        {
            Contract.Ensures(Contract.Result<PaginatedCollection<Quaggan>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        public Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<Quaggan>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}