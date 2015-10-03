// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPaletteConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorDTO" /> to objects of type <see cref="ColorPalette" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Colors.Converters
{
    using System;
    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.V1.Colors.Json;

    /// <summary>Converts objects of type <see cref="ColorDTO"/> to objects of type <see cref="ColorPalette"/>.</summary>
    public sealed class ColorPaletteConverter : IConverter<ColorDTO, ColorPalette>
    {
        private readonly IConverter<int[], Color> colorConverter;

        private readonly IConverter<ColorModelDTO, ColorModel> colorModelConverter;

        /// <summary>Initializes a new instance of the <see cref="ColorPaletteConverter"/> class.</summary>
        /// <param name="colorConverter"></param>
        /// <param name="colorModelConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ColorPaletteConverter(IConverter<int[], Color> colorConverter, IConverter<ColorModelDTO, ColorModel> colorModelConverter)
        {
            if (colorConverter == null)
            {
                throw new ArgumentNullException("colorConverter");
            }

            if (colorModelConverter == null)
            {
                throw new ArgumentNullException("colorModelConverter");
            }

            this.colorConverter = colorConverter;
            this.colorModelConverter = colorModelConverter;
        }

        /// <inheritdoc />
        public ColorPalette Convert(ColorDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // Create a new color object
            var colorPalette = new ColorPalette
            {
                Name = value.Name
            };

            // Set the base RGB values
            var rgb = value.BaseRgb;
            if (rgb != null && rgb.Length == 3)
            {
                colorPalette.BaseRgb = this.colorConverter.Convert(rgb, state);
            }

            // Set the color model for cloth
            var cloth = value.Cloth;
            if (cloth != null)
            {
                colorPalette.Cloth = this.colorModelConverter.Convert(cloth, state);
            }

            // Set the color model for leather
            var leather = value.Leather;
            if (leather != null)
            {
                colorPalette.Leather = this.colorModelConverter.Convert(leather, state);
            }

            // Set the color model for metal
            var metal = value.Metal;
            if (metal != null)
            {
                colorPalette.Metal = this.colorModelConverter.Convert(metal, state);
            }

            // Return the color object
            return colorPalette;
        }
    }
}