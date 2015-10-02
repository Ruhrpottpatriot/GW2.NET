// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.V2
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.V2.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ItemRepositoryFactory : RepositoryFactoryBase<IItemRepository>
    {

        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public ItemRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IItemRepository ForDefaultCulture()
        {
            var itemConverterFactory = new ItemConverterFactory();
            var itemRarityConverter = new ItemRarityConverter();
            var gameTypeCollectionConverter = new GameTypeCollectionConverter(new GameTypeConverter());
            var itemFlagCollectionConverter = new ItemFlagCollectionConverter(new ItemFlagConverter());
            var itemRestrictionCollectionConverter = new ItemRestrictionCollectionConverter(new ItemRestrictionConverter());
            var itemConverter = new ItemConverter(itemConverterFactory, itemRarityConverter, gameTypeCollectionConverter, itemFlagCollectionConverter, itemRestrictionCollectionConverter );
            var identifiersResponseConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<ItemDTO, Item>(itemConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<ItemDTO, int, Item>(itemConverter, item => item.ItemId);
            var pageResponseConverter = new CollectionPageResponseConverter<ItemDTO, Item>(itemConverter);
            return new ItemRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IItemRepository ForCulture(CultureInfo culture)
        {
            IItemRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }
    }
}