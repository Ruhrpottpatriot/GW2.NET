// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForPolygonLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDataContract" /> to objects of type <see cref="PolygonLocation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="LocationDataContract"/> to objects of type <see cref="PolygonLocation"/>.</summary>
    internal sealed class ConverterForPolygonLocation : IConverter<LocationDataContract, PolygonLocation>
    {
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForPolygonLocation"/> class.</summary>
        public ConverterForPolygonLocation()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForPolygonLocation"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForVector2D"/> is a null reference.</exception>
        internal ConverterForPolygonLocation(IConverter<double[], Vector2D> converterForVector2D)
        {
            if (converterForVector2D == null)
            {
                throw new ArgumentNullException("converterForVector2D", "Precondition: converterForVector2D != null");
            }

            this.converterForVector2D = converterForVector2D;
        }

        /// <inheritdoc />
        public PolygonLocation Convert(LocationDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var polygonLocation = new PolygonLocation();

            var zrange = value.ZRange;
            if (zrange != null && zrange.Length == 2)
            {
                polygonLocation.ZRange = this.converterForVector2D.Convert(zrange);
            }

            var points = value.Points;
            if (points != null)
            {
                polygonLocation.Points = new List<Vector2D>(points.Length);
                foreach (var point in points)
                {
                    if (point == null || point.Length != 2)
                    {
                        continue;
                    }

                    polygonLocation.Points.Add(this.converterForVector2D.Convert(point));
                }
            }

            return polygonLocation;
        }
    }
}