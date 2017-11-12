// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGuildRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for repositories that provide guild details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Guilds
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;

    /// <summary>Provides the interface for repositories that provide guild details.</summary>
    public interface IGuildRepository : IRepository<Guid, Guild>
    {
        /// <summary>Finds the <see cref="Guild"/> with the given name.</summary>
        /// <param name="name">The name of the <see cref="Guild"/> to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by name.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The <see cref="Guid"/> with the given name, or a null reference.</returns>
        Guild FindByName(string name);

        /// <summary>Finds the <see cref="Guild"/> with the given name.</summary>
        /// <param name="name">The name of the <see cref="Guild"/> to find.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by name.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <returns>The <see cref="Guid"/> with the given name, or a null reference.</returns>
        Task<Guild> FindByNameAsync(string name);

        /// <summary>Finds the <see cref="Guild"/> with the given name.</summary>
        /// <param name="name">The name of the <see cref="Guild"/> to find.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="NotSupportedException">The data source does not support searching by name.</exception>
        /// <exception cref="ServiceException">An error occurred while retrieving data from the data source.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The <see cref="Guid"/> with the given name, or a null reference.</returns>
        Task<Guild> FindByNameAsync(string name, CancellationToken cancellationToken);
    }
}
