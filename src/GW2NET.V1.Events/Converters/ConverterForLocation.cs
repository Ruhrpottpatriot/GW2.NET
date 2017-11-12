// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDataContract" /> to objects of type <see cref="Location" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.DynamicEvents;
using GW2NET.V1.Events.Json;

namespace GW2NET.V1.Events.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="LocationDataContract"/> to objects of type <see cref="Location"/>.</summary>
    internal sealed class ConverterForLocation : IConverter<LocationDataContract, Location>
    {
        private readonly IConverter<double[], Vector3D> converterForVector3D;

        private readonly IDictionary<string, IConverter<LocationDataContract, Location>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForLocation"/> class.</summary>
        public ConverterForLocation()
            : this(GetKnownTypeConverters(), new ConverterForVector3D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForLocation"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForVector3D">The converter for <see cref="Vector3D"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="typeConverters"/> or <paramref name="converterForVector3D"/> is a null reference.</exception>
        public ConverterForLocation(IDictionary<string, IConverter<LocationDataContract, Location>> typeConverters, IConverter<double[], Vector3D> converterForVector3D)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            if (converterForVector3D == null)
            {
                throw new ArgumentNullException("converterForVector3D", "Precondition: converterForVector3D != null");
            }

            this.typeConverters = typeConverters;
            this.converterForVector3D = converterForVector3D;
        }

        /// <inheritdoc />
        public Location Convert(LocationDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            Location location;
            IConverter<LocationDataContract, Location> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                location = converter.Convert(value);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + value.Type);
                location = new UnknownLocation();
            }

            var center = value.Center;
            if (center != null && center.Length == 3)
            {
                location.Center = this.converterForVector3D.Convert(center);
            }

            return location;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<LocationDataContract, Location>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<LocationDataContract, Location>>
            {
                { "sphere", new ConverterForSphereLocation() },
                { "cylinder", new ConverterForCylinderLocation() },
                { "poly", new ConverterForPolygonLocation() }
            };
        }
    }
}
