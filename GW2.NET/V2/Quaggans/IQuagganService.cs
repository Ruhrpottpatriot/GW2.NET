// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuagganService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the Quaggan service.
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

    /// <summary>Provides the interface for the Quaggan service.</summary>
    [ContractClass(typeof(QuagganServiceContract))]
    public interface IQuagganService
    {
        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan.</returns>
        Quaggan GetQuaggan(string identifier);

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A Quaggan.</returns>
        Task<Quaggan> GetQuagganAsync(string identifier);

        /// <summary>Gets a Quaggan.</summary>
        /// <param name="identifier">An identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A Quaggan.</returns>
        Task<Quaggan> GetQuagganAsync(string identifier, CancellationToken cancellationToken);

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        ICollection<string> GetQuagganIdentifiers();

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        Task<ICollection<string>> GetQuagganIdentifiersAsync();

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        Task<ICollection<string>> GetQuagganIdentifiersAsync(CancellationToken cancellationToken);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <returns>A collection of Quaggans.</returns>
        Subdictionary<string, Quaggan> GetQuaggans();

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <returns>A collection of Quaggans.</returns>
        Task<Subdictionary<string, Quaggan>> GetQuaggansAsync();

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(CancellationToken cancellationToken);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        Subdictionary<string, Quaggan> GetQuaggans(IEnumerable<string> identifiers);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of Quaggans.</returns>
        Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        Task<Subdictionary<string, Quaggan>> GetQuaggansAsync(IEnumerable<string> identifiers, CancellationToken cancellationToken);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        PaginatedCollection<Quaggan> GetQuaggans(int page);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of Quaggans.</returns>
        Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, CancellationToken cancellationToken);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        PaginatedCollection<Quaggan> GetQuaggans(int page, int size);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of Quaggans.</returns>
        Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size);

        /// <summary>Gets a collection of Quaggans.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of Quaggans.</returns>
        Task<PaginatedCollection<Quaggan>> GetQuaggansAsync(int page, int size, CancellationToken cancellationToken);
    }
}