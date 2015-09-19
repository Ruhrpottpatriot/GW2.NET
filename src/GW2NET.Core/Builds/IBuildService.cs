// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the build service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Builds
{
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;

    /// <summary>Provides the interface for the build service.</summary>
    public interface IBuildService
    {
        /// <summary>Gets the current game build.</summary>
        /// <exception cref="ServiceException">An error occurred while retrieving the current game build.</exception>
        /// <returns>The current game build.</returns>
        Build GetBuild();

        /// <summary>Gets the current build.</summary>
        /// <exception cref="ServiceException">An error occurred while retrieving the current game build.</exception>
        /// <returns>The current game build.</returns>
        Task<Build> GetBuildAsync();

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <exception cref="ServiceException">An error occurred while retrieving the current game build.</exception>
        /// <exception cref="TaskCanceledException">A task was canceled.</exception>
        /// <returns>The current game build.</returns>
        Task<Build> GetBuildAsync(CancellationToken cancellationToken);
    }
}