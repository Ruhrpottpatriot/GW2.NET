// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PolygonLocationConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDTO" /> to objects of type <see cref="PolygonLocation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using System;
    using System.Collections.Generic;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events.Json;

    public partial class PolygonLocationConverter
    {
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="PolygonLocationConverter"/> class.</summary>
        /// <param name="vector2DConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PolygonLocationConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter");
            }

            this.vector2DConverter = vector2DConverter;
        }

        partial void Merge(PolygonLocation entity, LocationDTO dto, object state)
        {
            var zrange = dto.ZRange;
            if (zrange != null && zrange.Length == 2)
            {
                entity.ZRange = this.vector2DConverter.Convert(zrange, dto);
            }

            var points = dto.Points;
            if (points != null)
            {
                entity.Points = new List<Vector2D>(points.Length);
                foreach (var point in points)
                {
                    if (point == null || point.Length != 2)
                    {
                        continue;
                    }

                    entity.Points.Add(this.vector2DConverter.Convert(point, dto));
                }
            }
        }
    }
}