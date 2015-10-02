// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentCollectionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContinentCollectionDTO" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Maps;
using GW2NET.V1.Continents.Json;

namespace GW2NET.V1.Continents.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ContinentCollectionDTO"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    public sealed class ContinentCollectionConverter : IConverter<ContinentCollectionDTO, ICollection<Continent>>
    {
        private readonly IConverter<ContinentDTO, Continent> continentConverter;

        /// <summary>Initializes a new instance of the <see cref="ContinentCollectionConverter"/> class.</summary>
        /// <param name="continentConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ContinentCollectionConverter(IConverter<ContinentDTO, Continent> continentConverter)
        {
            if (continentConverter == null)
            {
                throw new ArgumentNullException("continentConverter");
            }

            this.continentConverter = continentConverter;
        }

        /// <inheritdoc />
        public ICollection<Continent> Convert(ContinentCollectionDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var continents = new List<Continent>(value.Continents.Count);
            foreach (var kvp in value.Continents)
            {
                var continent = this.continentConverter.Convert(kvp.Value, state);
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