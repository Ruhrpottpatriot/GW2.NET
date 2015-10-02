// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V2
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Skins;
    using GW2NET.V2.Skins;
    using GW2NET.V2.Skins.Converters;
    using GW2NET.V2.Skins.Json;

    /// <summary>Provides methods and properties for creating a skin repository.</summary>
    public class SkinRepositoryFactory : RepositoryFactoryBase<ISkinRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public SkinRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ISkinRepository ForDefaultCulture()
        {
            var skinConverterFactory = new SkinConverterFactory();
            var itemRestrictionCollectionConverter = new ItemRestrictionCollectionConverter(new ItemRestrictionConverter());
            var skinFlagCollectionConverter = new SkinFlagCollectionConverter(new SkinFlagConverter());
            var skinConverter = new SkinConverter(skinConverterFactory, itemRestrictionCollectionConverter, skinFlagCollectionConverter);
            var identifiersResponseConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<SkinDTO, Skin>(skinConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<SkinDTO, int, Skin>(skinConverter, skin => skin.SkinId);
            var pageResponseConverter = new CollectionPageResponseConverter<SkinDTO, Skin>(skinConverter);
            return new SkinRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override ISkinRepository ForCulture(CultureInfo culture)
        {
            ISkinRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }
    }
}
