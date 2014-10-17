// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBroker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for agents that provide exchange services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for agents that provide exchange services.</summary>
    /// <typeparam name="T">The type of identifiers that identify commodities.</typeparam>
    /// <typeparam name="TQuote">The type of quote information.</typeparam>
    public interface IBroker<T, TQuote> : IDiscoverable<T>
    {
        /// <summary>Gets a quote for the commodity.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <returns>A quote.</returns>
        TQuote GetQuote(T identifier);

        /// <summary>Gets a quote for the specified number of commodities.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>A quote.</returns>
        TQuote GetQuote(T identifier, long quantity);

        /// <summary>Gets a quote for the commodity.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <returns>A quote.</returns>
        Task<TQuote> GetQuoteAsync(T identifier);

        /// <summary>Gets a quote for the commodity.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A quote.</returns>
        Task<TQuote> GetQuoteAsync(T identifier, CancellationToken cancellationToken);

        /// <summary>Gets a quote for the specified number of commodities.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>A quote.</returns>
        Task<TQuote> GetQuoteAsync(T identifier, long quantity);

        /// <summary>Gets a quote for the specified number of commodities.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A quote.</returns>
        Task<TQuote> GetQuoteAsync(T identifier, long quantity, CancellationToken cancellationToken);
    }
}