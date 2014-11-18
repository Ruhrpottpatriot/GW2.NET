// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForPolygonLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDataContract" /> to objects of type <see cref="PolygonLocation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.DynamicEvents;

    /// <summary>Converts objects of type <see cref="LocationDataContract"/> to objects of type <see cref="PolygonLocation"/>.</summary>
    internal sealed class ConverterForPolygonLocation : IConverter<LocationDataContract, PolygonLocation>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForPolygonLocation"/> class.</summary>
        public ConverterForPolygonLocation()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForPolygonLocation"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        internal ConverterForPolygonLocation(IConverter<double[], Vector2D> converterForVector2D)
        {
            Contract.Requires(converterForVector2D != null);
            this.converterForVector2D = converterForVector2D;
        }

        /// <summary>Converts the given object of type <see cref="LocationDataContract"/> to an object of type <see cref="PolygonLocation"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public PolygonLocation Convert(LocationDataContract value)
        {
            Contract.Assume(value != null);
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForVector2D != null);
        }
    }
}