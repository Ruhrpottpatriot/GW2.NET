// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RegionDTO" /> to objects of type <see cref="Region" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Floors.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Json;

    /// <summary>Converts objects of type <see cref="RegionDTO"/> to objects of type <see cref="Region"/>.</summary>
    public sealed class RegionConverter : IConverter<RegionDTO, Region>
    {
        private readonly IConverter<IDictionary<string, SubregionDTO>, IDictionary<int, Subregion>> subregionKeyValuePairConverter;

        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="RegionConverter"/> class.</summary>
        /// <param name="vector2DConverter">The converter for <see cref="Vector2D"/>.</param>
        /// <param name="subregionKeyValuePairConverter">The converter for <see cref="T:KeyValuePair{int,Subregion}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="vector2DConverter"/> or <paramref name="subregionKeyValuePairConverter"/> is a null reference.</exception>
        public RegionConverter(IConverter<double[], Vector2D> vector2DConverter, IConverter<IDictionary<string, SubregionDTO>, IDictionary<int, Subregion>> subregionKeyValuePairConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter");
            }

            if (subregionKeyValuePairConverter == null)
            {
                throw new ArgumentNullException("subregionKeyValuePairConverter");
            }

            this.vector2DConverter = vector2DConverter;
            this.subregionKeyValuePairConverter = subregionKeyValuePairConverter;
        }

        /// <inheritdoc />
        public Region Convert(RegionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            // Create a new region object
            var region = new Region
            {
                Name = value.Name
            };

            // Set the position of the region label
            var labelCoordinates = value.LabelCoordinates;
            if (labelCoordinates != null && labelCoordinates.Length == 2)
            {
                region.LabelCoordinates = this.vector2DConverter.Convert(labelCoordinates, value);
            }

            // Set the maps
            var subregions = value.Maps;
            if (subregions != null)
            {
                region.Maps = this.subregionKeyValuePairConverter.Convert(subregions, value);
            }

            // Return the region object
            return region;
        }
    }
}