// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModelConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorModelDTO" /> to objects of type <see cref="ColorModel" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Colors.Converters
{
    using System;
    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.V1.Colors.Json;

    /// <summary>Converts objects of type <see cref="ColorModelDTO"/> to objects of type <see cref="ColorModel"/>.</summary>
    public sealed class ColorModelConverter : IConverter<ColorModelDTO, ColorModel>
    {
        private readonly IConverter<int[], Color> colorConverter;

        /// <summary>Initializes a new instance of the <see cref="ColorModelConverter"/> class.</summary>
        /// <param name="colorConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ColorModelConverter(IConverter<int[], Color> colorConverter)
        {
            if (colorConverter == null)
            {
                throw new ArgumentNullException("colorConverter");
            }

            this.colorConverter = colorConverter;
        }

        /// <inheritdoc />
        public ColorModel Convert(ColorModelDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var colorModel = new ColorModel
            {
                Brightness = value.Brightness,
                Contrast = value.Contrast,
                Hue = value.Hue,
                Saturation = value.Saturation,
                Lightness = value.Lightness
            };
            var rgb = value.Rgb;
            if (rgb != null && rgb.Length == 3)
            {
                colorModel.Rgb = this.colorConverter.Convert(rgb, state);
            }

            return colorModel;
        }
    }
}