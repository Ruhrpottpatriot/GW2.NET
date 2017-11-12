// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForColorPaletteCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorCollectionDataContract" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Colors;
using GW2NET.Common;
using GW2NET.V1.Colors.Json;

namespace GW2NET.V1.Colors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ColorCollectionDataContract"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    internal sealed class ConverterForColorPaletteCollection : IConverter<ColorCollectionDataContract, ICollection<ColorPalette>>
    {
        private readonly IConverter<ColorDataContract, ColorPalette> converterForColorPalette;

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPaletteCollection"/> class.</summary>
        internal ConverterForColorPaletteCollection()
            : this(new ConverterForColorPalette())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPaletteCollection"/> class.</summary>
        /// <param name="converterForColorPalette">The converter for <see cref="ColorPalette"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForColorPalette"/> is a null reference.</exception>
        internal ConverterForColorPaletteCollection(IConverter<ColorDataContract, ColorPalette> converterForColorPalette)
        {
            if (converterForColorPalette == null)
            {
                throw new ArgumentNullException("converterForColorPalette", "Precondition: converterForColorPalette != null");
            }

            this.converterForColorPalette = converterForColorPalette;
        }

        /// <inheritdoc />
        public ICollection<ColorPalette> Convert(ColorCollectionDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var colorPalettes = new List<ColorPalette>(value.Colors.Count);
            foreach (var dataContract in value.Colors)
            {
                var colorPalette = this.converterForColorPalette.Convert(dataContract.Value);
                if (colorPalette == null)
                {
                    continue;
                }

                int id;
                if (int.TryParse(dataContract.Key, out id))
                {
                    colorPalette.ColorId = id;
                }

                colorPalettes.Add(colorPalette);
            }

            return colorPalettes;
        }
    }
}
