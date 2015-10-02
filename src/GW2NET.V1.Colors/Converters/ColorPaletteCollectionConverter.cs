// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorPaletteCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorCollectionDTO" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Colors;
using GW2NET.Common;
using GW2NET.V1.Colors.Json;

namespace GW2NET.V1.Colors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ColorCollectionDTO"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    public sealed class ColorPaletteCollectionConverter : IConverter<ColorCollectionDTO, ICollection<ColorPalette>>
    {
        private readonly IConverter<ColorDTO, ColorPalette> colorPaletteConverter;

        /// <summary>Initializes a new instance of the <see cref="ColorPaletteCollectionConverter"/> class.</summary>
        /// <param name="colorPaletteConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ColorPaletteCollectionConverter(IConverter<ColorDTO, ColorPalette> colorPaletteConverter)
        {
            if (colorPaletteConverter == null)
            {
                throw new ArgumentNullException("colorPaletteConverter");
            }

            this.colorPaletteConverter = colorPaletteConverter;
        }

        /// <inheritdoc />
        public ICollection<ColorPalette> Convert(ColorCollectionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var colorPalettes = new List<ColorPalette>(value.Colors.Count);
            foreach (var dataContract in value.Colors)
            {
                var colorPalette = this.colorPaletteConverter.Convert(dataContract.Value, state);
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