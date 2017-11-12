// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBroker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for agents that provide exchange services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for agents that provide exchange services.</summary>
    /// <typeparam name="TQuotation">The type of quotation.</typeparam>
    public interface IBroker<TQuotation>
    {
        /// <summary>Gets a quotation for the specified number of commodities.</summary>
        /// <param name="quantity">The quantity.</param>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A quotation.</returns>
        TQuotation GetQuotation(long quantity);

        /// <summary>Gets a quotation for the specified number of commodities.</summary>
        /// <param name="quantity">The quantity.</param>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A quotation.</returns>
        Task<TQuotation> GetQuotationAsync(long quantity);

        /// <summary>Gets a quotation for the specified number of commodities.</summary>
        /// <param name="quantity">The quantity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A quotation.</returns>
        Task<TQuotation> GetQuotationAsync(long quantity, CancellationToken cancellationToken);
    }
}
