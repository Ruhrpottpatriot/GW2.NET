// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionKeyValuePairConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, RegionDataContract}" /> to objects of type <see cref="T:KeyValuePair{int, Region}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="T:KeyValuePair{string, RegionDataContract}"/> to objects of type <see cref="T:KeyValuePair{int, Region}"/>.</summary>
    internal sealed class RegionKeyValuePairConverter : IConverter<KeyValuePair<string, RegionDataContract>, KeyValuePair<int, Region>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<RegionDataContract, Region> converterForRegion;

        /// <summary>Initializes a new instance of the <see cref="RegionKeyValuePairConverter"/> class.</summary>
        public RegionKeyValuePairConverter()
            : this(new RegionConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RegionKeyValuePairConverter"/> class.</summary>
        /// <param name="converterForRegion">The converter for <see cref="Region"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForRegion"/> is a null reference.</exception>
        internal RegionKeyValuePairConverter(IConverter<RegionDataContract, Region> converterForRegion)
        {
            if (converterForRegion == null)
            {
                throw new ArgumentNullException("converterForRegion", "Precondition: converterForRegion != null");
            }

            this.converterForRegion = converterForRegion;
        }

        /// <summary>Converts the given object of type <see cref="T:KeyValuePair{string, RegionDataContract}"/> to an object of type <see cref="T:KeyValuePair{int, Region}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public KeyValuePair<int, Region> Convert(KeyValuePair<string, RegionDataContract> value)
        {
            var key = value.Key;
            var dataContract = value.Value;
            Debug.Assert(key != null, "key != null");
            Debug.Assert(dataContract != null, "dataContract != null");
            int id;
            if (!int.TryParse(key, out id))
            {
                return default(KeyValuePair<int, Region>);
            }

            var region = this.converterForRegion.Convert(dataContract);
            region.RegionId = id;
            return new KeyValuePair<int, Region>(id, region);
        }
    }
}