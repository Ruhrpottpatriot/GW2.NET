// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuagganService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for the Quaggan service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Colors
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Colors;
    using GW2DotNET.V2.Common;

    /// <summary>Provides the interface for the Quaggan service.</summary>
    [ContractClass(typeof(ColorServiceContract))]
    public interface IColorService
    {
        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A color.</returns>
        ColorPalette GetColor(int identifier);

        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A color.</returns>
        Task<ColorPalette> GetColorAsync(int identifier);

        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A color.</returns>
        Task<ColorPalette> GetColorAsync(int identifier, CancellationToken cancellationToken);

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        ICollection<int> GetColorIdentifiers();

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        Task<ICollection<int>> GetColorIdentifiersAsync();

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        Task<ICollection<int>> GetColorIdentifiersAsync(CancellationToken cancellationToken);

        /// <summary>Gets a collection of colors.</summary>
        /// <returns>A collection of colors.</returns>
        Subdictionary<int, ColorPalette> GetColors();

        /// <summary>Gets a collection of colors.</summary>
        /// <returns>A collection of colors.</returns>
        Task<Subdictionary<int, ColorPalette>> GetColorsAsync();

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        Task<Subdictionary<int, ColorPalette>> GetColorsAsync(CancellationToken cancellationToken);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of colors.</returns>
        Subdictionary<int, ColorPalette> GetColors(ICollection<int> identifiers);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of colors.</returns>
        Task<Subdictionary<int, ColorPalette>> GetColorsAsync(IEnumerable<int> identifiers);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        Task<Subdictionary<int, ColorPalette>> GetColorsAsync(IEnumerable<int> identifiers, CancellationToken cancellationToken);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of colors.</returns>
        PaginatedCollection<ColorPalette> GetColors(int page);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of colors.</returns>
        Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, CancellationToken cancellationToken);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of colors.</returns>
        PaginatedCollection<ColorPalette> GetColors(int page, int size);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of colors.</returns>
        Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, int size);

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, int size, CancellationToken cancellationToken);
    }
}