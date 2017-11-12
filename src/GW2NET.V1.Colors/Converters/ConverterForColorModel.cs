// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForColorModel.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorModelDataContract" /> to objects of type <see cref="ColorModel" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Colors;
using GW2NET.Common;
using GW2NET.V1.Colors.Json;

namespace GW2NET.V1.Colors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ColorModelDataContract"/> to objects of type <see cref="ColorModel"/>.</summary>
    internal sealed class ConverterForColorModel : IConverter<ColorModelDataContract, ColorModel>
    {
        private readonly IConverter<int[], Color> converterForColor;

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorModel"/> class.</summary>
        internal ConverterForColorModel()
            : this(new ConverterForColor())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorModel"/> class.</summary>
        /// <param name="converterForColor">The converter for <see cref="Color"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForColor"/> is a null reference.</exception>
        internal ConverterForColorModel(IConverter<int[], Color> converterForColor)
        {
            if (converterForColor == null)
            {
                throw new ArgumentNullException("converterForColor", "Precondition: converterForColor != null");
            }

            this.converterForColor = converterForColor;
        }

        /// <inheritdoc />
        public ColorModel Convert(ColorModelDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
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
                colorModel.Rgb = this.converterForColor.Convert(rgb);
            }

            return colorModel;
        }
    }
}