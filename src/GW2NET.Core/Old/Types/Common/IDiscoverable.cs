// <copyright file="IDiscoverable.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides the interface for data sources that support enumerating object identifiers.</summary>
    /// <typeparam name="T">The type of the identifiers.</typeparam>
    public interface IDiscoverable<T>
    {
        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>A collection of object identifiers.</returns>
        Task<ICollection<T>> DiscoverAsync();

        /// <summary>Discovers identifiers of objects in the data source.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support the discovery of object identifiers.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>A collection of object identifiers.</returns>
        Task<ICollection<T>> DiscoverAsync(CancellationToken cancellationToken);
    }
}