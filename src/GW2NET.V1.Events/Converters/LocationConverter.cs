// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDTO" /> to objects of type <see cref="Location" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events.Json;

    public partial class LocationConverter
    {
        private readonly IConverter<double[], Vector3D> vector3DConverter;

        /// <summary>Initializes a new instance of the <see cref="LocationConverter" /> class.</summary>
        /// <param name="converterFactory"></param>
        /// <param name="vector3DConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LocationConverter(
            ITypeConverterFactory<LocationDTO, Location> converterFactory,
            IConverter<double[], Vector3D> vector3DConverter)
            : this(converterFactory)
        {
            if (vector3DConverter == null)
            {
                throw new ArgumentNullException("vector3DConverter");
            }

            this.vector3DConverter = vector3DConverter;
        }

        partial void Merge(Location entity, LocationDTO dto, object state)
        {
            var center = dto.Center;
            if (center != null && center.Length == 3)
            {
                entity.Center = this.vector3DConverter.Convert(center, dto);
            }
        }
    }
}