// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForColorModel.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorModelDataContract" /> to objects of type <see cref="ColorModel" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Colors.Json.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Colors;

    /// <summary>Converts objects of type <see cref="ColorModelDataContract"/> to objects of type <see cref="ColorModel"/>.</summary>
    internal sealed class ConverterForColorModel : IConverter<ColorModelDataContract, ColorModel>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Color> converterForColor;

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorModel"/> class.</summary>
        internal ConverterForColorModel()
            : this(new ConverterForColor())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorModel"/> class.</summary>
        /// <param name="converterForColor">The converter for <see cref="Color"/>.</param>
        internal ConverterForColorModel(IConverter<int[], Color> converterForColor)
        {
            Contract.Requires(converterForColor != null);
            Contract.Ensures(this.converterForColor != null);
            this.converterForColor = converterForColor;
        }

        /// <summary>Converts the given object of type <see cref="ColorModelDataContract"/> to an object of type <see cref="ColorModel"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ColorModel Convert(ColorModelDataContract value)
        {
            Contract.Requires(value != null);
            var colorModel = new ColorModel();
            colorModel.Brightness = value.Brightness;
            colorModel.Contrast = value.Contrast;
            colorModel.Hue = value.Hue;
            colorModel.Saturation = value.Saturation;
            colorModel.Lightness = value.Lightness;
            if (value.Rgb != null && value.Rgb.Length == 3)
            {
                colorModel.Rgb = this.converterForColor.Convert(value.Rgb);
            }

            return colorModel;
        }
    }
}