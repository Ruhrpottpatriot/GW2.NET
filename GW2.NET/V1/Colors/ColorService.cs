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
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Colors;
    using GW2DotNET.Common;
    using GW2DotNET.Common.Serializers;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Colors.Contracts;

    /// <summary>Provides the default implementation of the colors service.</summary>
    public class ColorService : IColorService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorService(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors()
        {
            return this.GetColors(CultureInfo.GetCultureInfo("en"));
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors(CultureInfo language)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new ColorRequest { Culture = language };
            var response = this.serviceClient.Send(request, new JsonSerializer<ColorCollectionContract>());
            return MapColorCollectionContract(response.Content, language);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync()
        {
            return this.GetColorsAsync(CancellationToken.None);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CancellationToken cancellationToken)
        {
            return this.GetColorsAsync(CultureInfo.GetCultureInfo("en"), cancellationToken);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language)
        {
            return this.GetColorsAsync(language, CancellationToken.None);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public Task<IDictionary<int, ColorPalette>> GetColorsAsync(CultureInfo language, CancellationToken cancellationToken)
        {
            Preconditions.EnsureNotNull(paramName: "language", value: language);
            var request = new ColorRequest { Culture = language };
            return this.serviceClient.SendAsync(request, new JsonSerializer<ColorCollectionContract>(), cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        return MapColorCollectionContract(response.Content, language);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, ColorPalette> MapColorCollectionContract(ColorCollectionContract content, CultureInfo culture)
        {
            var values = new Dictionary<int, ColorPalette>(content.Colors.Count);
            foreach (var value in content.Colors.Select(contract => MapColorPaletteContract(contract, culture)))
            {
                values.Add(value.ColorId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Color MapColorContract(int[] content)
        {
            return new Color(content[0], content[1], content[2]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ColorModel MapColorModelContract(ColorModelContract content)
        {
            return new ColorModel
                       {
                           Brightness = content.Brightness, 
                           Contrast = content.Contrast, 
                           Hue = content.Hue, 
                           Saturation = content.Saturation, 
                           Lightness = content.Lightness, 
                           Rgb = MapColorContract(content.Rgb)
                       };
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>An entity.</returns>
        private static ColorPalette MapColorPaletteContract(KeyValuePair<string, ColorContract> content, CultureInfo culture)
        {
            return new ColorPalette
                       {
                           ColorId = int.Parse(content.Key), 
                           Name = content.Value.Name, 
                           Language = culture.TwoLetterISOLanguageName, 
                           BaseRgb = MapColorContract(content.Value.BaseRgb), 
                           Cloth = MapColorModelContract(content.Value.Cloth), 
                           Leather = MapColorModelContract(content.Value.Leather), 
                           Metal = MapColorModelContract(content.Value.Metal)
                       };
        }
    }
}