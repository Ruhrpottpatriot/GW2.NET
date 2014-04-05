// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBuildServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a build service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Builds
{
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Builds.Types;

    /// <summary>Provides the interface for a build service cache.</summary>
    public interface IBuildServiceCache : IBuildService
    {
        /// <summary>Gets the current game build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Build GetBuild(bool allowCache);

        /// <summary>Gets the current build.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Task<Build> GetBuildAsync(bool allowCache);

        /// <summary>Gets the current build.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>The current game build.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/build">wiki</a> for more information.</remarks>
        Task<Build> GetBuildAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets the current game build.</summary>
        /// <param name="build">The build.</param>
        void SetBuild(Build build);
    }
}