// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISkinServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a skins service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Skins
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Common.Caching;

    /// <summary>Provides the interface for a skins service cache.</summary>
    public interface ISkinServiceCache : ISkinService
    {
        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        IEnumerable<int> GetSkins(bool allowCache);

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetSkinsAsync(bool allowCache);

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of skin identifiers.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/skins">wiki</a> for more information.</remarks>
        Task<IEnumerable<int>> GetSkinsAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="skins">A collection of skin identifiers.</param>
        void SetSkins(IEnumerable<int> skins);

        /// <summary>Gets a collection of skin identifiers.</summary>
        /// <param name="skins">A collection of skin identifiers.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetSkins(IEnumerable<int> skins, CacheItemParameters parameters);
    }
}