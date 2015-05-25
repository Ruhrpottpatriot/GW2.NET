// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContinentCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContinentCollectionDataContract" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Maps;
using GW2NET.V1.Continents.Json;

namespace GW2NET.V1.Continents.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ContinentCollectionDataContract"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    internal sealed class ConverterForContinentCollection : IConverter<ContinentCollectionDataContract, ICollection<Continent>>
    {
        private readonly IConverter<ContinentDataContract, Continent> converterForContinent;

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinentCollection"/> class.</summary>
        internal ConverterForContinentCollection()
            : this(new ConverterForContinent())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinentCollection"/> class.</summary>
        /// <param name="converterForContinent">The converter for <see cref="Continent"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForContinent"/> is a null reference.</exception>
        internal ConverterForContinentCollection(IConverter<ContinentDataContract, Continent> converterForContinent)
        {
            if (converterForContinent == null)
            {
                throw new ArgumentNullException("converterForContinent", "Precondition: converterForContinent != null");
            }

            this.converterForContinent = converterForContinent;
        }

        /// <inheritdoc />
        public ICollection<Continent> Convert(ContinentCollectionDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var continents = new List<Continent>(value.Continents.Count);
            foreach (var kvp in value.Continents)
            {
                var continent = this.converterForContinent.Convert(kvp.Value, state);
                if (continent == null)
                {
                    continue;
                }

                int id;
                if (int.TryParse(kvp.Key, out id))
                {
                    continent.ContinentId = id;
                }

                continents.Add(continent);
            }

            return continents;
        }
    }
}