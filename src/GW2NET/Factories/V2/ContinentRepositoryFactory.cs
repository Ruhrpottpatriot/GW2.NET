// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating a continent repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V2
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Maps;
    using GW2NET.V2.Continents;
    using GW2NET.V2.Continents.Converter;
    using GW2NET.V2.Continents.Json;

    /// <summary>Provides methods for creating a continent repository.</summary>
    public class ContinentRepositoryFactory : RepositoryFactoryBase<IContinentRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ContinentRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public ContinentRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IContinentRepository ForDefaultCulture()
        {
            var continentConverter = new ContinentConverter();
            var identifiersConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<ContinentDTO, Continent>(continentConverter);
            var pageResponseConverter = new CollectionPageResponseConverter<ContinentDTO, Continent>(continentConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<ContinentDTO, int, Continent>(continentConverter, cont => cont.ContinentId);
            return new ContinentRepository(this.serviceClient, identifiersConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public override IContinentRepository ForCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            var continentConverter = new ContinentConverter();
            var identifiersConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<ContinentDTO, Continent>(continentConverter);
            var pageResponseConverter = new CollectionPageResponseConverter<ContinentDTO, Continent>(continentConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<ContinentDTO, int, Continent>(continentConverter, cont => cont.ContinentId);
            IContinentRepository repository = new ContinentRepository(this.serviceClient, identifiersConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
            repository.Culture = culture;
            return repository;
        }
    }
}
