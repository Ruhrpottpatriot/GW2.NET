// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IColorServiceCache.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for a colors service cache.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Colors.Contracts;
    using GW2DotNET.V1.Common.Caching;

    /// <summary>Provides the interface for a colors service cache.</summary>
    public interface IColorServiceCache : IColorService
    {
        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        IEnumerable<ColorPalette> GetColors(bool allowCache);

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        IEnumerable<ColorPalette> GetColors(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(bool allowCache);

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken cancellationToken, bool allowCache);

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, bool allowCache);

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <param name="allowCache">Indicates whether cached data is preferred.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken, bool allowCache);

        /// <summary>Sets a collection of colors.</summary>
        /// <param name="colors">A collection of colors.</param>
        /// <param name="language">The language.</param>
        void SetColors(IEnumerable<ColorPalette> colors, CultureInfo language);

        /// <summary>Sets a collection of colors.</summary>
        /// <param name="colors">A collection of colors.</param>
        /// <param name="language">The language.</param>
        /// <param name="parameters">The eviction and expiration details.</param>
        void SetColors(IEnumerable<ColorPalette> colors, CultureInfo language, CacheItemParameters parameters);
    }
}