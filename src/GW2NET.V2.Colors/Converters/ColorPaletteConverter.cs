// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPaletteConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors.Converters
{
    using System;

    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.V2.Colors.Json;

    /// <summary>Converts objects of type <see cref="ColorModelDTO"/> to objects of type <see cref="ColorPalette"/>.</summary>
    public sealed class ColorPaletteConverter : IConverter<ColorPaletteDTO, ColorPalette>
    {
        private readonly IConverter<int[], Color> colorConverter;

        private readonly IConverter<ColorModelDTO, ColorModel> colorModelConverter;

        /// <summary>Initializes a new instance of the <see cref="ColorPaletteConverter"/> class.</summary>
        /// <param name="colorConverter">The converter for <see cref="Color"/>.</param>
        /// <param name="colorModelConverter">The converter for <see cref="ColorModel"/>.</param>
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
        public ColorPalette Convert(ColorPaletteDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }

            return new ColorPalette
            {
                ColorId = value.Id,
                Name = value.Name,
                BaseRgb = this.colorConverter.Convert(value.BaseRgb, value),
                Cloth = this.colorModelConverter.Convert(value.Cloth, value),
                Leather = this.colorModelConverter.Convert(value.Leather, value),
                Metal = this.colorModelConverter.Convert(value.Metal, value),
                Culture = response.Culture
            };
        }
    }
}