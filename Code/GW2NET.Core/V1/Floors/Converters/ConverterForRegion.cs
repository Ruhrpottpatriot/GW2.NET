// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRegion.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RegionDataContract" /> to objects of type <see cref="Region" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Common.Drawing;
    using GW2NET.Entities.Maps;
    using GW2NET.V1.Floors.Json;

    /// <summary>Converts objects of type <see cref="RegionDataContract"/> to objects of type <see cref="Region"/>.</summary>
    internal sealed class ConverterForRegion : IConverter<RegionDataContract, Region>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IDictionary<string, SubregionDataContract>, IDictionary<int, Subregion>> converterForSubregionKeyValuePair;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegion"/> class.</summary>
        public ConverterForRegion()
            : this(new ConverterForVector2D(), new ConverterForIDictionary<string, SubregionDataContract, int, Subregion>(new ConverterForSubregionKeyValuePair()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegion"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        /// <param name="converterForSubregionKeyValuePair">The converter for <see cref="T:KeyValuePair{int,Subregion}"/>.</param>
        public ConverterForRegion(IConverter<double[], Vector2D> converterForVector2D, IConverter<IDictionary<string, SubregionDataContract>, IDictionary<int, Subregion>> converterForSubregionKeyValuePair)
        {
            Contract.Requires(converterForVector2D != null);
            Contract.Requires(converterForSubregionKeyValuePair != null);
            this.converterForVector2D = converterForVector2D;
            this.converterForSubregionKeyValuePair = converterForSubregionKeyValuePair;
        }

        /// <summary>Converts the given object of type <see cref="RegionDataContract"/> to an object of type <see cref="Region"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Region Convert(RegionDataContract value)
        {
            Contract.Assume(value != null);

            // Create a new region object
            var region = new Region { Name = value.Name };

            // Set the position of the region label
            var labelCoordinates = value.LabelCoordinates;
            if (labelCoordinates != null && labelCoordinates.Length == 2)
            {
                region.LabelCoordinates = this.converterForVector2D.Convert(labelCoordinates);
            }

            // Set the maps
            var subregionDataContracts = value.Maps;
            if (subregionDataContracts != null)
            {
                region.Maps = this.converterForSubregionKeyValuePair.Convert(subregionDataContracts);
            }

            // Return the region object
            return region;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForVector2D != null);
            Contract.Invariant(this.converterForSubregionKeyValuePair != null);
        }
    }
}