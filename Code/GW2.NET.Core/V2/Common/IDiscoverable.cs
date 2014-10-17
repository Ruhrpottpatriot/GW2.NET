// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscoverable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for data sources that are discoverable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for data sources that are discoverable.</summary>
    /// <typeparam name="T">The type of the identifiers.</typeparam>
    [ContractClass(typeof(DiscoverableCodeContract<>))]
    public interface IDiscoverable<T>
    {
        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        ICollection<T> Discover();

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        Task<ICollection<T>> DiscoverAsync();

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        Task<ICollection<T>> DiscoverAsync(CancellationToken cancellationToken);
    }
}