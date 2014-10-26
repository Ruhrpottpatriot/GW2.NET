// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContinentCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContinentCollectionDataContract" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Continents.Json.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Maps;

    /// <summary>Converts objects of type <see cref="ContinentCollectionDataContract"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    internal sealed class ConverterForContinentCollection : IConverter<ContinentCollectionDataContract, ICollection<Continent>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ContinentDataContract, Continent> converterForContinent;

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinentCollection"/> class.</summary>
        internal ConverterForContinentCollection()
            : this(new ConverterForContinent())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinentCollection"/> class.</summary>
        /// <param name="converterForContinent">The converter for <see cref="Continent"/>.</param>
        internal ConverterForContinentCollection(IConverter<ContinentDataContract, Continent> converterForContinent)
        {
            Contract.Requires(converterForContinent != null);
            Contract.Ensures(this.converterForContinent != null);
            this.converterForContinent = converterForContinent;
        }

        /// <summary>Converts the given object of type <see cref="ContinentCollectionDataContract"/> to an object of type <see cref="ICollection{Continent}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<Continent> Convert(ContinentCollectionDataContract value)
        {
            Contract.Requires(value != null && value.Continents != null);
            Contract.Ensures(Contract.Result<ICollection<Continent>>() != null);
            var continents = new List<Continent>(value.Continents.Count);
            foreach (var kvp in value.Continents)
            {
                var continent = this.converterForContinent.Convert(kvp.Value);
                continent.ContinentId = int.Parse(kvp.Key);
                continents.Add(continent);
            }

            return continents;
        }
    }
}