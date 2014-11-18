// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForLocation.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDataContract" /> to objects of type <see cref="Location" />.
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

    /// <summary>Converts objects of type <see cref="LocationDataContract"/> to objects of type <see cref="Location"/>.</summary>
    internal sealed class ConverterForLocation : IConverter<LocationDataContract, Location>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector3D> converterForVector3D;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<LocationDataContract, Location>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForLocation"/> class.</summary>
        public ConverterForLocation()
            : this(GetKnownTypeConverters(), new ConverterForVector3D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForLocation"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForVector3D">The converter for <see cref="Vector3D"/>.</param>
        public ConverterForLocation(IDictionary<string, IConverter<LocationDataContract, Location>> typeConverters, IConverter<double[], Vector3D> converterForVector3D)
        {
            Contract.Requires(typeConverters != null);
            Contract.Requires(converterForVector3D != null);
            this.typeConverters = typeConverters;
            this.converterForVector3D = converterForVector3D;
        }

        /// <summary>Converts the given object of type <see cref="LocationDataContract"/> to an object of type <see cref="Location"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Location Convert(LocationDataContract value)
        {
            Contract.Assume(value != null);
            Location location;
            IConverter<LocationDataContract, Location> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                location = converter.Convert(value);
            }
            else
            {
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.converterForVector3D != null);
        }
    }
}