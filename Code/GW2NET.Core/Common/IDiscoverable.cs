// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDiscoverable.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for data sources whose contents are enumerable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for data sources whose contents are enumerable.</summary>
    /// <typeparam name="T">The type of the identifiers.</typeparam>
    [ContractClass(typeof(ContractClassForIDiscoverable<>))]
    public interface IDiscoverable<T>
    {
        /// <summary>Discovers valid object identifiers of type <typeparamref name="T"/>.</summary>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers of type <typeparamref name="T"/>.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of valid object identifiers.</returns>
        ICollection<T> Discover();

        /// <summary>Discovers valid object identifiers of type <typeparamref name="T"/>.</summary>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers of type <typeparamref name="T"/>.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of valid object identifiers.</returns>
        Task<ICollection<T>> DiscoverAsync();

        /// <summary>Discovers valid object identifiers of type <typeparamref name="T"/>.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers of type <typeparamref name="T"/>.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of valid object identifiers.</returns>
        Task<ICollection<T>> DiscoverAsync(CancellationToken cancellationToken);
    }
}