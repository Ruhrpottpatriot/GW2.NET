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
    using System.Collections.Generic;

    using GW2NET.Colors;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="ColorModelDataContract"/> to objects of type <see cref="ColorPalette"/>.</summary>
    internal sealed class ColorPaletteConverter : IConverter<ColorPaletteDataContract, ColorPalette>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Color> colorConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ColorModelDataContract, ColorModel> colorModelConverter;

        /// <summary>Initializes a new instance of the <see cref="ColorPaletteConverter"/> class.</summary>
        public ColorPaletteConverter()
            : this(new ColorConverter(), new ColorModelConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ColorPaletteConverter"/> class.</summary>
        /// <param name="colorConverter">The converter for <see cref="Color"/>.</param>
        /// <param name="colorModelConverter">The converter for <see cref="ColorModel"/>.</param>
        internal ColorPaletteConverter(IConverter<int[], Color> colorConverter, IConverter<ColorModelDataContract, ColorModel> colorModelConverter)
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
        public ColorPalette Convert(ColorPaletteDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            // Create a new color object
            var colorPalette = new ColorPalette { Name = value.Name };

            // Set the RGB values
            var rgb = value.BaseRgb;
            if (rgb != null && rgb.Length == 3)
            {
                colorPalette.BaseRgb = this.colorConverter.Convert(rgb);
            }

            // Set the color model for cloth
            var cloth = value.Cloth;
            if (cloth != null)
            {
                colorPalette.Cloth = this.colorModelConverter.Convert(cloth);
            }

            // Set the color model for leather
            var leather = value.Leather;
            if (leather != null)
            {
                colorPalette.Leather = this.colorModelConverter.Convert(leather);
            }

            // Set the color model for metal
            var metal = value.Metal;
            if (metal != null)
            {
                colorPalette.Metal = this.colorModelConverter.Convert(metal);
            }

            colorPalette.ItemId = value.ItemId;
            if (value.Categories == null)
            {
                colorPalette.Categories = new List<string>(0);
            }
            else
            {
                var values = new List<string>(value.Categories.Length);
                values.AddRange(value.Categories);
                colorPalette.Categories = values;
            }

            // Return the color object
            return colorPalette;
        }
    }
}
