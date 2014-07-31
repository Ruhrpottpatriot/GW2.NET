// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorServiceContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The color service contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Colors;

    /// <summary>The color service contract.</summary>
    [ContractClassFor(typeof(IColorService))]
    internal abstract class ColorServiceContract : IColorService
    {
        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors()
        {
            Contract.Ensures(Contract.Result<IDictionary<int, ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<IDictionary<int, ColorPalette>>() != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync()
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Contract.Requires(language != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>() != null);
            Contract.Ensures(Contract.Result<Task<IDictionary<int, ColorPalette>>>().Result != null);
            throw new System.NotImplementedException();
        }
    }
}