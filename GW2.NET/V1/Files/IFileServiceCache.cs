// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a files service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Files
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Files.Types;

    /// <summary>Provides the interface for a files service cache.</summary>
    public interface IFileServiceCache : IFileService
    {
        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        IEnumerable<Asset> GetFiles(bool allowCache);

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        Task<IEnumerable<Asset>> GetFilesAsync(bool allowCache);

        /// <summary>Gets a collection of commonly requested in-game assets.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of commonly requested in-game assets.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/files">wiki</a> for more information.</remarks>
        Task<IEnumerable<Asset>> GetFilesAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of commonly requested in-game assets.</summary>
        /// <param name="files">A collection of commonly requested in-game assets.</param>
        void SetFiles(IEnumerable<Asset> files);
    }
}