// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForColorPalette.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorDataContract" /> to objects of type <see cref="ColorPalette" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Colors;
using GW2NET.Common;
using GW2NET.V1.Colors.Json;

namespace GW2NET.V1.Colors.Converters
{
    using System;
    using System.Collections.Generic;

    /// <summary>Converts objects of type <see cref="ColorDataContract"/> to objects of type <see cref="ColorPalette"/>.</summary>
    internal sealed class ConverterForColorPalette : IConverter<ColorDataContract, ColorPalette>
    {
        private readonly IConverter<int[], Color> converterForColor;

        private readonly IConverter<ColorModelDataContract, ColorModel> converterForColorModel;

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPalette"/> class.</summary>
        internal ConverterForColorPalette()
            : this(new ConverterForColor(), new ConverterForColorModel())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPalette"/> class.</summary>
        /// <param name="converterForColor">The converter for <see cref="Color"/>.</param>
        /// <param name="converterForColorModel">The converter for <see cref="ColorModel"/>.</param>
        internal ConverterForColorPalette(IConverter<int[], Color> converterForColor, IConverter<ColorModelDataContract, ColorModel> converterForColorModel)
        {
            if (converterForColor == null)
            {
                throw new ArgumentNullException("converterForColor", "Precondition: converterForColor != null");
            }

            if (converterForColorModel == null)
            {
                throw new ArgumentNullException("converterForColorModel", "Precondition: converterForColorModel != null");
            }

            this.converterForColor = converterForColor;
            this.converterForColorModel = converterForColorModel;
        }

        /// <inheritdoc />
        public ColorPalette Convert(ColorDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
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
                colorPalette.BaseRgb = this.converterForColor.Convert(rgb);
            }

            // Set the color model for cloth
            var cloth = value.Cloth;
            if (cloth != null)
            {
                colorPalette.Cloth = this.converterForColorModel.Convert(cloth);
            }

            // Set the color model for leather
            var leather = value.Leather;
            if (leather != null)
            {
                colorPalette.Leather = this.converterForColorModel.Convert(leather);
            }

            // Set the color model for metal
            var metal = value.Metal;
            if (metal != null)
            {
                colorPalette.Metal = this.converterForColorModel.Convert(metal);
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