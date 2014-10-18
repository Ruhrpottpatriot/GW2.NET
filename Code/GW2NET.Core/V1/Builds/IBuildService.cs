// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBuildService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the build service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Builds
{
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Entities.Builds;

    /// <summary>Provides the interface for the build service.</summary>
    [ContractClass(typeof(ContractClassForIBuildService))]
    public interface IBuildService
    {
        /// <summary>Gets the current game build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Build GetBuild();

        /// <summary>Gets the current build.</summary>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Task<Build> GetBuildAsync();

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Task<Build> GetBuildAsync(CancellationToken cancellationToken);
    }
}