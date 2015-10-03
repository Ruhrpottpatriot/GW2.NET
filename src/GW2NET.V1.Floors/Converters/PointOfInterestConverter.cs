// <copyright file="PointOfInterestConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V1.Floors.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Json;

    public partial class PointOfInterestConverter
    {
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        public PointOfInterestConverter(
            ITypeConverterFactory<PointOfInterestDTO, PointOfInterest> converterFactory,
            IConverter<double[], Vector2D> vector2DConverter)
            : this(converterFactory)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter");
            }

            this.vector2DConverter = vector2DConverter;
        }

        partial void Merge(PointOfInterest entity, PointOfInterestDTO dto, object state)
        {
            entity.PointOfInterestId = dto.PointOfInterestId;
            entity.Name = dto.Name;
            entity.Floor = dto.Floor;
            var coordinates = dto.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                entity.Coordinates = this.vector2DConverter.Convert(coordinates, dto);
            }
        }
    }
}