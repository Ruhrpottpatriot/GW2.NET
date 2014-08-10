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
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Colors;
    using GW2DotNET.V1.Colors.Json;

    /// <summary>Provides the default implementation of the colors service.</summary>
    public class ColorService : IColorService
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors()
        {
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetColors(culture);
        }

        /// <summary>Gets a collection of colors and their localized details.</summary>
        /// <param name="language">The language.</param>
        /// <returns>A collection of colors.</returns>
        /// <remarks>See <a href="http://wiki.guildwars2.com/wiki/API:1/colors">wiki</a> for more information.</remarks>
        public IDictionary<int, ColorPalette> GetColors(CultureInfo language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new ColorRequest { Culture = language };
            var response = this.serviceClient.Send<ColorCollectionContract>(request);
            if (response.Content == null || response.Content.Colors == null)
            {
                return new Dictionary<int, ColorPalette>(0);
            }

            var values = ConvertColorCollectionContract(response.Content);
            var twoLetterIsoLanguageName = (response.Culture ?? language).TwoLetterISOLanguageName;
            foreach (var value in values.Values)
            {
                value.Language = twoLetterIsoLanguageName;
            }

            return values;
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
            var culture = new CultureInfo("en");
            Contract.Assume(culture != null);
            return this.GetColorsAsync(culture, cancellationToken);
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
            if (language == null)
            {
                throw new ArgumentNullException(paramName: "language", message: "Precondition failed: language != null");
            }

            Contract.EndContractBlock();

            var request = new ColorRequest { Culture = language };
            return this.serviceClient.SendAsync<ColorCollectionContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new Dictionary<int, ColorPalette>(0);
                        }

                        var values = ConvertColorCollectionContract(response.Content);
                        var twoLetterIsoLanguageName = (response.Culture ?? language).TwoLetterISOLanguageName;
                        foreach (var value in values.Values)
                        {
                            value.Language = twoLetterIsoLanguageName;
                        }

                        return values;
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>A collection of entities.</returns>
        private static IDictionary<int, ColorPalette> ConvertColorCollectionContract(ColorCollectionContract content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Colors != null);
            Contract.Ensures(Contract.Result<IDictionary<int, ColorPalette>>() != null);
            var values = new Dictionary<int, ColorPalette>(content.Colors.Count);
            foreach (var value in content.Colors.Select(ConvertColorPaletteContract))
            {
                Contract.Assume(value != null);
                values.Add(value.ColorId, value);
            }

            return values;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static Color ConvertColorContract(int[] content)
        {
            Contract.Requires(content != null);
            Contract.Requires(content.Length == 3);
            return new Color(content[0], content[1], content[2]);
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ColorModel ConvertColorModelContract(ColorModelContract content)
        {
            Contract.Requires(content != null);
            var value = new ColorModel();
            value.Brightness = content.Brightness;
            value.Contrast = content.Contrast;
            value.Hue = content.Hue;
            value.Saturation = content.Saturation;
            value.Lightness = content.Lightness;
            if (content.Rgb != null && content.Rgb.Length == 3)
            {
                value.Rgb = ConvertColorContract(content.Rgb);
            }

            return value;
        }

        /// <summary>Infrastructure. Converts contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>An entity.</returns>
        private static ColorPalette ConvertColorPaletteContract(KeyValuePair<string, ColorContract> content)
        {
            Contract.Requires(content.Key != null);
            Contract.Requires(content.Value != null);
            Contract.Ensures(Contract.Result<ColorPalette>() != null);

            // Create a new color object
            var value = new ColorPalette();

            // Set the color identifier
            value.ColorId = int.Parse(content.Key);

            // Set the name of the color
            if (content.Value.Name != null)
            {
                value.Name = content.Value.Name;
            }

            // Set the base RGB values
            if (content.Value.BaseRgb != null && content.Value.BaseRgb.Length == 3)
            {
                value.BaseRgb = ConvertColorContract(content.Value.BaseRgb);
            }

            // Set the color model for cloth
            if (content.Value.Cloth != null)
            {
                value.Cloth = ConvertColorModelContract(content.Value.Cloth);
            }

            // Set the color model for leather
            if (content.Value.Leather != null)
            {
                value.Leather = ConvertColorModelContract(content.Value.Leather);
            }

            // Set the color model for metal
            if (content.Value.Metal != null)
            {
                value.Metal = ConvertColorModelContract(content.Value.Metal);
            }

            // Return the color object
            return value;
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}