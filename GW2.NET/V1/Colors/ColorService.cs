// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the default implementation of the colors service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Colors.Contracts;
    using GW2DotNET.V1.Common;

    /// <summary>Provides the default implementation of the colors service.</summary>
    public class ColorService : ServiceBase, IColorService
    {
        /// <summary>Initializes a new instance of the <see cref="ColorService" /> class.</summary>
        public ColorService()
            : this(new ServiceClient(new Uri(Services.DataServiceUrl)))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorService(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors()
        {
            return this.GetColors(ServiceBase.DefaultLanguage);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IEnumerable<ColorPalette> GetColors(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ColorServiceRequest { Language = language };
            var result = this.Request<ColorCollectionResult>(serviceRequest);

            foreach (var colorPalette in result.Colors.Values)
            {
                // patch missing language information
                colorPalette.Language = language;
            }

            return result.Colors.Values;
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync()
        {
            return this.GetColorsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            return this.GetColorsAsync(ServiceBase.DefaultLanguage, cancellationToken);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language)
        {
            return this.GetColorsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IEnumerable<ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var serviceRequest = new ColorServiceRequest { Language = language };
            var t1 = this.RequestAsync<ColorCollectionResult>(serviceRequest, cancellationToken);
            var t2 = t1.ContinueWith<IEnumerable<ColorPalette>>(
                task =>
                    {
                        foreach (var colorPalette in task.Result.Colors.Values)
                        {
                            // patch missing language information
                            colorPalette.Language = language;
                        }

                        return task.Result.Colors.Values;
                    }, 
                cancellationToken);

            return t2;
        }
    }
}