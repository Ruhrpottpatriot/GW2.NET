// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRegionKeyValuePair.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, RegionDataContract}" /> to objects of type <see cref="T:KeyValuePair{int, Region}" />.
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

    /// <summary>Converts objects of type <see cref="T:KeyValuePair{string, RegionDataContract}"/> to objects of type <see cref="T:KeyValuePair{int, Region}"/>.</summary>
    internal sealed class ConverterForRegionKeyValuePair : IConverter<KeyValuePair<string, RegionDataContract>, KeyValuePair<int, Region>>
    {
        private readonly IConverter<RegionDataContract, Region> converterForRegion;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegionKeyValuePair"/> class.</summary>
        public ConverterForRegionKeyValuePair()
            : this(new ConverterForRegion())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegionKeyValuePair"/> class.</summary>
        /// <param name="converterForRegion">The converter for <see cref="Region"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForRegion"/> is a null reference.</exception>
        internal ConverterForRegionKeyValuePair(IConverter<RegionDataContract, Region> converterForRegion)
        {
            if (converterForRegion == null)
            {
                throw new ArgumentNullException("converterForRegion", "Precondition: converterForRegion != null");
            }

            this.converterForRegion = converterForRegion;
        }

        /// <inheritdoc />
        public KeyValuePair<int, Region> Convert(KeyValuePair<string, RegionDataContract> value, object state)
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

            var region = this.converterForRegion.Convert(dataContract, state);
            region.RegionId = id;
            return new KeyValuePair<int, Region>(id, region);
        }
    }
}