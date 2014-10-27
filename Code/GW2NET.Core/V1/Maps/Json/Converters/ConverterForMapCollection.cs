// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMapCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MapCollectionDataContract" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;

    /// <summary>Converts objects of type <see cref="MapCollectionDataContract"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    internal sealed class ConverterForMapCollection : IConverter<MapCollectionDataContract, ICollection<Map>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<MapDataContract, Map> converterForMap;

        /// <summary>Initializes a new instance of the <see cref="ConverterForMapCollection"/> class.</summary>
        public ConverterForMapCollection()
            : this(new ConverterForMap())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForMapCollection"/> class.</summary>
        /// <param name="converterForMap">The converter for <see cref="Map"/>.</param>
        public ConverterForMapCollection(IConverter<MapDataContract, Map> converterForMap)
        {
            this.converterForMap = converterForMap;
        }

        /// <summary>Converts the given object of type <see cref="MapCollectionDataContract"/> to an object of type <see cref="ICollection{Map}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<Map> Convert(MapCollectionDataContract value)
        {
            Contract.Requires(value != null);
            Contract.Requires(value.Maps != null);
            Contract.Ensures(Contract.Result<ICollection<Map>>() != null);
            var maps = new List<Map>(value.Maps.Count);
            foreach (var kvp in value.Maps)
            {
                var map = this.converterForMap.Convert(kvp.Value);
                map.MapId = int.Parse(kvp.Key);
                maps.Add(map);
            }

            return maps;
        }
    }
}