// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWorldNameServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a world names service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Worlds.Names
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Worlds.Names.Types;

    /// <summary>Provides the interface for a world names service cache.</summary>
    public interface IWorldNameServiceCache : IWorldNameService
    {
        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        IEnumerable<WorldName> GetWorldNames(bool allowCache);

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        IEnumerable<WorldName> GetWorldNames(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<WorldName>> GetWorldNamesAsync(bool allowCache);

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<WorldName>> GetWorldNamesAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<WorldName>> GetWorldNamesAsync(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of worlds and their localized name.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of worlds and their localized name.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/world_names">wiki</a> for more information.</remarks>
        Task<IEnumerable<WorldName>> GetWorldNamesAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of worlds and their localized name.</summary>
        /// <param name="worldNames">A collection of worlds and their localized name.</param>
        /// <param name="language">The language.</param>
        void SetWorldNames(IEnumerable<WorldName> worldNames, CultureInfo language);
    }
}