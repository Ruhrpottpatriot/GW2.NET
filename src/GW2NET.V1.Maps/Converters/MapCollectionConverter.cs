// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MapCollectionDTO" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

using GW2NET.Common;
using GW2NET.Maps;
using GW2NET.V1.Maps.Json;

namespace GW2NET.V1.Maps.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="MapCollectionDTO"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    public sealed class MapCollectionConverter : IConverter<MapCollectionDTO, ICollection<Map>>
    {
        private readonly IConverter<MapDTO, Map> mapConverter;

        /// <summary>Initializes a new instance of the <see cref="MapCollectionConverter"/> class.</summary>
        /// <param name="mapConverter">The converter for <see cref="Map"/>.</param>
        public MapCollectionConverter(IConverter<MapDTO, Map> mapConverter)
        {
            if (mapConverter == null)
            {
                throw new ArgumentNullException("mapConverter");
            }

            this.mapConverter = mapConverter;
        }

        /// <inheritdoc />
        public ICollection<Map> Convert(MapCollectionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var dataContracts = value.Maps;
            if (dataContracts == null)
            {
                return new List<Map>(0);
            }

            var maps = new List<Map>(dataContracts.Count);
            foreach (var kvp in dataContracts)
            {
                var map = this.mapConverter.Convert(kvp.Value, state);
                if (map == null)
                {
                    continue;
                }

                int id;
                if (int.TryParse(kvp.Key, out id))
                {
                    map.MapId = id;
                }

                maps.Add(map);
            }

            return maps;
        }
    }
}