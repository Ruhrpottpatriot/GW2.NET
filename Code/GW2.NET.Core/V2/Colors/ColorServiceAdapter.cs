// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorServiceAdapter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides adapter methods that adapt the /v1 to the /v2 protocol.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V2.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Colors;
    using GW2DotNET.Common;
    using GW2DotNET.V1.Colors;
    using GW2DotNET.V2.Common;

    /// <summary>Provides adapter methods that adapt the /v1 to the /v2 protocol.</summary>
    public class ColorServiceAdapter : IColorService
    {
        /// <summary>Infrastructure. Holds a reference to the /v1/colors service.</summary>
        private readonly V1.Colors.IColorService colorService1;

        /// <summary>Initializes a new instance of the <see cref="ColorServiceAdapter"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorServiceAdapter(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.colorService1 = new ColorService(serviceClient);
        }

        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A color.</returns>
        public ColorPalette GetColor(int identifier)
        {
            return this.colorService1.GetColors()[identifier];
        }

        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <returns>A color.</returns>
        public Task<ColorPalette> GetColorAsync(int identifier)
        {
            return this.colorService1.GetColorsAsync(CancellationToken.None).ContinueWith(task => task.Result[identifier]);
        }

        /// <summary>Gets a color.</summary>
        /// <param name="identifier">An identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A color.</returns>
        public Task<ColorPalette> GetColorAsync(int identifier, CancellationToken cancellationToken)
        {
            return this.colorService1.GetColorsAsync(cancellationToken).ContinueWith(task => task.Result[identifier], cancellationToken);
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public ICollection<int> GetColorIdentifiers()
        {
            return this.colorService1.GetColors().Keys;
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<int>> GetColorIdentifiersAsync()
        {
            return this.GetColorIdentifiersAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of identifiers.</returns>
        public Task<ICollection<int>> GetColorIdentifiersAsync(CancellationToken cancellationToken)
        {
            return this.colorService1.GetColorsAsync(cancellationToken).ContinueWith(task => task.Result.Keys, cancellationToken);
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <returns>A collection of colors.</returns>
        public Subdictionary<int, ColorPalette> GetColors()
        {
            var colors = this.colorService1.GetColors();
            return new Subdictionary<int, ColorPalette>(colors) { PageCount = colors.Count, TotalCount = colors.Count };
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of colors.</returns>
        public Subdictionary<int, ColorPalette> GetColors(ICollection<int> identifiers)
        {
            var colors = this.colorService1.GetColors();
            var values = new Subdictionary<int, ColorPalette> { PageCount = identifiers.Count, TotalCount = colors.Count };
            foreach (var id in identifiers)
            {
                values[id] = colors[id];
            }

            return values;
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of colors.</returns>
        public PaginatedCollection<ColorPalette> GetColors(int page)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of colors.</returns>
        public PaginatedCollection<ColorPalette> GetColors(int page, int size)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync()
        {
            return this.GetColorsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            return this.colorService1.GetColorsAsync(cancellationToken).ContinueWith(
                task =>
                    {
                        var colors = task.Result;
                        return new Subdictionary<int, ColorPalette>(colors) { PageCount = colors.Count, TotalCount = colors.Count };
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync(IEnumerable<int> identifiers)
        {
            return this.GetColorsAsync(identifiers, CancellationToken.None);
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="identifiers">A collection of identifiers.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<Subdictionary<int, ColorPalette>> GetColorsAsync(IEnumerable<int> identifiers, CancellationToken cancellationToken)
        {
            return this.colorService1.GetColorsAsync(cancellationToken).ContinueWith(
                task =>
                    {
                        var colors = task.Result;
                        var values = new Subdictionary<int, ColorPalette>();
                        foreach (var id in identifiers)
                        {
                            values[id] = colors[id];
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets a collection of colors.</summary>
        /// <param name="page">The page number.</param>
        /// <param name="size">The page size.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        public Task<PaginatedCollection<ColorPalette>> GetColorsAsync(int page, int size, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}