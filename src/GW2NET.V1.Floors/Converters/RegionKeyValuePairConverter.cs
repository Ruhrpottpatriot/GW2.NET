// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionKeyValuePairConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, RegionDTO}" /> to objects of type <see cref="T:KeyValuePair{int, Region}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Floors.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V1.Floors.Json;

    /// <summary>Converts objects of type <see cref="T:KeyValuePair{string, RegionDTO}"/> to objects of type <see cref="T:KeyValuePair{int, Region}"/>.</summary>
    public sealed class RegionKeyValuePairConverter : IConverter<KeyValuePair<string, RegionDTO>, KeyValuePair<int, Region>>
    {
        private readonly IConverter<RegionDTO, Region> regionConverter;

        /// <summary>Initializes a new instance of the <see cref="RegionKeyValuePairConverter"/> class.</summary>
        /// <param name="regionConverter">The converter for <see cref="Region"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="regionConverter"/> is a null reference.</exception>
        public RegionKeyValuePairConverter(IConverter<RegionDTO, Region> regionConverter)
        {
            if (regionConverter == null)
            {
                throw new ArgumentNullException("regionConverter");
            }

            this.regionConverter = regionConverter;
        }

        /// <inheritdoc />
        public KeyValuePair<int, Region> Convert(KeyValuePair<string, RegionDTO> value, object state)
        {
            var key = value.Key;
            var dto = value.Value;
            Debug.Assert(key != null, "key != null");
            Debug.Assert(dto != null, "dataContract != null");
            int id;
            if (!int.TryParse(key, out id))
            {
                return default(KeyValuePair<int, Region>);
            }

            var region = this.regionConverter.Convert(dto, value);
            region.RegionId = id;
            return new KeyValuePair<int, Region>(id, region);
        }
    }
}