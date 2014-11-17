// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSubregionKeyValuePair.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, SubregionDataContract}" /> to objects of type <see cref="T:KeyValuePair{int, Subregion}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="T:KeyValuePair{string, SubregionDataContract}"/> to objects of type <see cref="T:KeyValuePair{int, Subregion}"/>.</summary>
    internal sealed class ConverterForSubregionKeyValuePair : IConverter<KeyValuePair<string, SubregionDataContract>, KeyValuePair<int, Subregion>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<SubregionDataContract, Subregion> converterForSubregion;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSubregionKeyValuePair"/> class.</summary>
        public ConverterForSubregionKeyValuePair()
            : this(new ConverterForSubregion())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSubregionKeyValuePair"/> class.</summary>
        /// <param name="converterForSubregion">The converter for <see cref="Subregion"/>.</param>
        public ConverterForSubregionKeyValuePair(IConverter<SubregionDataContract, Subregion> converterForSubregion)
        {
            Contract.Requires(converterForSubregion != null);
            this.converterForSubregion = converterForSubregion;
        }

        /// <summary>Converts the given object of type <see cref="T:KeyValuePair{string, SubregionDataContract}"/> to an object of type <see cref="T:KeyValuePair{int, Subregion}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public KeyValuePair<int, Subregion> Convert(KeyValuePair<string, SubregionDataContract> value)
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
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForSubregion != null);
        }
    }
}