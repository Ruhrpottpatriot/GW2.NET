// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSubregionKeyValuePair.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, SubregionDataContract}" /> to objects of type <see cref="T:KeyValuePair{int, Subregion}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    using System;
    using System.Diagnostics;

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
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForSubregion"/> is a null reference.</exception>
        public ConverterForSubregionKeyValuePair(IConverter<SubregionDataContract, Subregion> converterForSubregion)
        {
            if (converterForSubregion == null)
            {
                throw new ArgumentNullException("converterForSubregion", "Precondition: converterForSubregion != null");
            }

            this.converterForSubregion = converterForSubregion;
        }

        /// <inheritdoc />
        public KeyValuePair<int, Subregion> Convert(KeyValuePair<string, SubregionDataContract> value)
        {
            var key = value.Key;
            var dataContract = value.Value;
            Debug.Assert(key != null);
            Debug.Assert(dataContract != null);
            int id;
            if (!int.TryParse(key, out id))
            {
                return default(KeyValuePair<int, Subregion>);
            }

            var subRegion = this.converterForSubregion.Convert(dataContract);
            subRegion.MapId = id;
            return new KeyValuePair<int, Subregion>(id, subRegion);
        }
    }
}
