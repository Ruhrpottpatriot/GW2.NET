// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapKeyValuePairConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, MapDataContract}" /> to objects of type <see cref="T:KeyValuePair{int, Subregion}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="T:KeyValuePair{string, MapDataContract}"/> to objects of type <see cref="T:KeyValuePair{int, Subregion}"/>.</summary>
    internal sealed class MapKeyValuePairConverter : IConverter<KeyValuePair<string, MapDataContract>, KeyValuePair<int, Subregion>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<MapDataContract, Subregion> converterForSubregion;

        /// <summary>Initializes a new instance of the <see cref="MapKeyValuePairConverter"/> class.</summary>
        public MapKeyValuePairConverter()
            : this(new MapConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapKeyValuePairConverter"/> class.</summary>
        /// <param name="converterForSubregion">The converter for <see cref="MapKeyValuePairConverter"/>.</param>
        public MapKeyValuePairConverter(IConverter<MapDataContract, Subregion> converterForSubregion)
        {
            Contract.Requires(converterForSubregion != null);
            this.converterForSubregion = converterForSubregion;
        }

        /// <summary>Converts the given object of type <see cref="T:KeyValuePair{string, SubregionDataContract}"/> to an object of type <see cref="T:KeyValuePair{int, Subregion}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public KeyValuePair<int, Subregion> Convert(KeyValuePair<string, MapDataContract> value)
        {
            var key = value.Key;
            var dataContract = value.Value;
            Contract.Assume(key != null);
            Contract.Assume(dataContract != null);
            int id;
            if (!int.TryParse(key, out id))
            {
                return default(KeyValuePair<int, Subregion>);
            }

            var subRegion = this.converterForSubregion.Convert(dataContract);
            subRegion.MapId = id;
            return new KeyValuePair<int, Subregion>(id, subRegion);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when DataContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForSubregion != null);
        }
    }
}