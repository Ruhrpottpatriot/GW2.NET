// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IColorService.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the colors service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.V1.Colors.Types;

    /// <summary>Provides the interface for the colors service.</summary>
    public interface IColorService
    {
        /// <summary>Gets the collection of colors in the game.</summary>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        IEnumerable<ColorPalette> GetColors();

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="language">The language.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        IEnumerable<ColorPalette> GetColors(CultureInfo language);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync();

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken cancellationToken);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="language">The language.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language);

        /// <summary>Gets the collection of colors in the game.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>The collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken);
    }
}