// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMapCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MapCollectionDataContract" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V1.Maps.Json;

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
            Contract.Requires(converterForMap != null);
            this.converterForMap = converterForMap;
        }

        /// <summary>Converts the given object of type <see cref="MapCollectionDataContract"/> to an object of type <see cref="ICollection{Map}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<Map> Convert(MapCollectionDataContract value)
        {
            Contract.Assume(value != null);
            var dataContracts = value.Maps;
            if (dataContracts == null)
            {
                return new List<Map>(0);
            }

            var maps = new List<Map>(dataContracts.Count);
            foreach (var kvp in dataContracts)
            {
                var map = this.converterForMap.Convert(kvp.Value);
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForMap != null);
        }
    }
}