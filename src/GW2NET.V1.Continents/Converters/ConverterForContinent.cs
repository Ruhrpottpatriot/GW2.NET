// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContinent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContinentDataContract" /> to objects of type <see cref="Continent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Continents.Json;

namespace GW2NET.V1.Continents.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ContinentDataContract"/> to objects of type <see cref="Continent"/>.</summary>
    internal sealed class ConverterForContinent : IConverter<ContinentDataContract, Continent>
    {
        private readonly IConverter<double[], Size2D> converterForSize2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinent"/> class.</summary>
        public ConverterForContinent()
            : this(new ConverterForSize2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinent"/> class.</summary>
        /// <param name="converterForSize2D">The converter for <see cref="Size2D"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForSize2D"/> is a null reference.</exception>
        public ConverterForContinent(IConverter<double[], Size2D> converterForSize2D)
        {
            if (converterForSize2D == null)
            {
                throw new ArgumentNullException("converterForSize2D", "Precondition: converterForSize2D != null");
            }

            this.converterForSize2D = converterForSize2D;
        }

        /// <inheritdoc />
        public Continent Convert(ContinentDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var continent = new Continent
            {
                Name = value.Name,
                MinimumZoom = value.MinimumZoom,
                MaximumZoom = value.MaximumZoom,
                FloorIds = value.Floors
            };
            var dimensions = value.ContinentDimensions;
            if (dimensions != null && dimensions.Length == 2)
            {
                continent.ContinentDimensions = this.converterForSize2D.Convert(dimensions);
            }

            return continent;
        }
    }
}
