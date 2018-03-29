// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods and properties for creating a map repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Common;
    using Common.Converters;
    using GW2NET.V2.Maps;
    using GW2NET.V2.Maps.Converter;
    using GW2NET.V2.Maps.Json;
    using Maps;

    /// <summary>Provides methods and properties for creating a map repository.</summary>
    public class MapsRepositoryFactory : RepositoryFactoryBase<IMapRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapsRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public MapsRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IMapRepository ForDefaultCulture()
        {
            var rectangleConverter = new RectangleConverter(new Vector2DConverter());
            var mapConverter = new MapConverter(rectangleConverter);
            var identifiersResponseConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<MapDTO, Map>(mapConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<MapDTO, int, Map>(mapConverter, map => map.MapId);
            var pageResponseConverter = new CollectionPageResponseConverter<MapDTO, Map>(mapConverter);
            return new MapRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IMapRepository ForCulture(CultureInfo culture)
        {
            IMapRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }
    }
}
