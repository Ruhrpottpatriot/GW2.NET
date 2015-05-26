// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPaletteConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors
{
    using System;

    using GW2NET.Colors;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="ColorModelDataContract"/> to objects of type <see cref="ColorPalette"/>.</summary>
    public sealed class ColorPaletteConverter : IConverter<ColorPaletteDataContract, ColorPalette>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Color> colorConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ColorModelDataContract, ColorModel> colorModelConverter;

        /// <summary>Initializes a new instance of the <see cref="ColorPaletteConverter"/> class.</summary>
        /// <param name="colorConverter">The converter for <see cref="Color"/>.</param>
        /// <param name="colorModelConverter">The converter for <see cref="ColorModel"/>.</param>
        public ColorPaletteConverter(IConverter<int[], Color> colorConverter, IConverter<ColorModelDataContract, ColorModel> colorModelConverter)
        {
            if (colorConverter == null)
            {
                throw new ArgumentNullException("colorConverter", "Precondition: colorConverter != null");
            }

            if (colorModelConverter == null)
            {
                throw new ArgumentNullException("colorModelConverter", "Precondition: colorModelConverter != null");
            }

            this.colorConverter = colorConverter;
            this.colorModelConverter = colorModelConverter;
        }

        /// <inheritdoc />
        public ColorPalette Convert(ColorPaletteDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state != null");
            }

            var response = state as IResponse<ColorPaletteDataContract>;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse<ColorPaletteDataContract>", "state");
            }

            return new ColorPalette
            {
                ColorId = value.Id,
                Name = value.Name,
                BaseRgb = this.colorConverter.Convert(value.BaseRgb, state),
                Cloth = this.colorModelConverter.Convert(value.Cloth, state),
                Leather = this.colorModelConverter.Convert(value.Leather, state),
                Metal = this.colorModelConverter.Convert(value.Metal, state),
                Culture = response.Culture
            };
        }
    }
}