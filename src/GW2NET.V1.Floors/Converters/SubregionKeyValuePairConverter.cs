// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubregionKeyValuePairConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:KeyValuePair{string, SubregionDTO}" /> to objects of type <see cref="T:KeyValuePair{int, Subregion}" />.
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
    
    /// <summary>Converts objects of type <see cref="T:KeyValuePair{string, SubregionDTO}"/> to objects of type <see cref="T:KeyValuePair{int, Subregion}"/>.</summary>
    public sealed class SubregionKeyValuePairConverter : IConverter<KeyValuePair<string, SubregionDTO>, KeyValuePair<int, Subregion>>
    {
        
        private readonly IConverter<SubregionDTO, Subregion> subregionConverter;

        /// <summary>Initializes a new instance of the <see cref="SubregionKeyValuePairConverter"/> class.</summary>
        /// <param name="subregionConverter">The converter for <see cref="Subregion"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="subregionConverter"/> is a null reference.</exception>
        public SubregionKeyValuePairConverter(IConverter<SubregionDTO, Subregion> subregionConverter)
        {
            if (subregionConverter == null)
            {
                throw new ArgumentNullException("subregionConverter");
            }

            this.subregionConverter = subregionConverter;
        }

        /// <inheritdoc />
        public KeyValuePair<int, Subregion> Convert(KeyValuePair<string, SubregionDTO> value, object state)
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

            var subRegion = this.subregionConverter.Convert(dataContract, state);
            subRegion.MapId = id;
            return new KeyValuePair<int, Subregion>(id, subRegion);
        }
    }
}