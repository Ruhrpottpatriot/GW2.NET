// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContinentDTO" /> to objects of type <see cref="Continent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Continents.Converters
{
    using System;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Continents.Json;

    /// <summary>Converts objects of type <see cref="ContinentDTO"/> to objects of type <see cref="Continent"/>.</summary>
    public sealed class ContinentConverter : IConverter<ContinentDTO, Continent>
    {
        private readonly IConverter<double[], Size2D> size2DConverter;

        /// <summary>Initializes a new instance of the <see cref="ContinentConverter"/> class.</summary>
        /// <param name="size2DConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContinentConverter(IConverter<double[], Size2D> size2DConverter)
        {
            if (size2DConverter == null)
            {
                throw new ArgumentNullException("size2DConverter");
            }

            this.size2DConverter = size2DConverter;
        }

        /// <inheritdoc />
        public Continent Convert(ContinentDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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
                continent.ContinentDimensions = this.size2DConverter.Convert(dimensions, state);
            }

            return continent;
        }
    }
}