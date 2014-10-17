// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPaletteServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The ColorPalette service contract.
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

    /// <summary>The color service contract.</summary>
    [ContractClassFor(typeof(IColorService))]
    internal abstract class ColorServiceContract : IColorService
    {
        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A color.</returns>
        public ColorPalette GetColor(int identifier)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A color.</returns>
        public Task<ColorPalette> GetColorAsync(int identifier)
        {
            Contract.Ensures(Contract.Result<Task<ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A color.</returns>
        public Task<ColorPalette> GetColorAsync(int identifier, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<int> GetColorIdentifiers()
        {
            Contract.Ensures(Contract.Result<ICollection<string>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<int>> GetColorIdentifiersAsync()
        {
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<int>> GetColorIdentifiersAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>() != null);
            Contract.Ensures(Contract.Result<Task<ICollection<string>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <returns>A collection of colors.</returns>
        public Subdictionary<int, ColorPalette> GetColors()
        {
            Contract.Ensures(Contract.Result<Subdictionary<string, ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync()
        {
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of colors.</returns>
        public Subdictionary<int, ColorPalette> GetColors(ICollection<int> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Ensures(Contract.Result<Subdictionary<string, ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync(IEnumerable<int> identifiers)
        {
            Contract.Requires(identifiers != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync(IEnumerable<int> identifiers, CancellationToken cancellationToken)
        {
            Contract.Requires(identifiers != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<Subdictionary<string, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of colors.</returns>
        public PaginatedCollection<ColorPalette> GetColors(int page)
        {
            Contract.Ensures(Contract.Result<PaginatedCollection<ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of colors.</returns>
        public PaginatedCollection<ColorPalette> GetColors(int page, int size)
        {
            Contract.Ensures(Contract.Result<PaginatedCollection<ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, int size)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, int size, CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<PaginatedCollection<ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}