// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories.V1
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items;
    using GW2NET.V1.Items.Converters;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ItemRepositoryFactory
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public ItemRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="language"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IItemRepository this[string language]
        {
            get
            {
                if (language == null)
                {
                    throw new ArgumentNullException("language");
                }

                return this.ForCulture(new CultureInfo(language));
            }
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IItemRepository this[CultureInfo culture]
        {
            get
            {
                if (culture == null)
                {
                    throw new ArgumentNullException("culture");
                }

                return this.ForCulture(culture);
            }
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public IItemRepository ForDefaultCulture()
        {
            var itemCollectionConverter = new ItemCollectionConverter();
            var itemConverterFactory = new ItemConverterFactory();
            var itemRarityConverter = new ItemRarityConverter();
            var gameTypeCollectionConverter = new GameTypeCollectionConverter(new GameTypeConverter());
            var itemFlagCollectionConverter = new ItemFlagCollectionConverter(new ItemFlagConverter());
            var itemRestrictionConverter = new ItemRestrictionConverter();
            var itemRestrictionCollectionConverter = new ItemRestrictionCollectionConverter(itemRestrictionConverter);
            var itemConverter = new ItemConverter(itemConverterFactory, itemRarityConverter, gameTypeCollectionConverter, itemFlagCollectionConverter, itemRestrictionCollectionConverter);
            return new ItemRepository(this.serviceClient, itemCollectionConverter, itemConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IItemRepository ForCulture(CultureInfo culture)
        {
            IItemRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IItemRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IItemRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}