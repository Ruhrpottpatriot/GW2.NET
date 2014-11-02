// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRegionKeyValuePair.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, RegionDataContract}" /> to objects of type <see cref="T:KeyValuePair{int, Region}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;
    using GW2NET.V1.Floors.Json;

    /// <summary>Converts objects of type <see cref="T:KeyValuePair{string, RegionDataContract}"/> to objects of type <see cref="T:KeyValuePair{int, Region}"/>.</summary>
    internal sealed class ConverterForRegionKeyValuePair : IConverter<KeyValuePair<string, RegionDataContract>, KeyValuePair<int, Region>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<RegionDataContract, Region> converterForRegion;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegionKeyValuePair"/> class.</summary>
        public ConverterForRegionKeyValuePair()
            : this(new ConverterForRegion())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegionKeyValuePair"/> class.</summary>
        /// <param name="converterForRegion">The converter for <see cref="Region"/>.</param>
        internal ConverterForRegionKeyValuePair(IConverter<RegionDataContract, Region> converterForRegion)
        {
            Contract.Requires(converterForRegion != null);
            this.converterForRegion = converterForRegion;
        }

        /// <summary>Converts the given object of type <see cref="T:KeyValuePair{string, RegionDataContract}"/> to an object of type <see cref="T:KeyValuePair{int, Region}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public KeyValuePair<int, Region> Convert(KeyValuePair<string, RegionDataContract> value)
        {
            var key = value.Key;
            var dataContract = value.Value;
            Contract.Assume(key != null);
            Contract.Assume(dataContract != null);
            int id;
            if (!int.TryParse(key, out id))
            {
                return default(KeyValuePair<int, Region>);
            }

            var region = this.converterForRegion.Convert(dataContract);
            region.RegionId = id;
            return new KeyValuePair<int, Region>(id, region);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForRegion != null);
        }
    }
}