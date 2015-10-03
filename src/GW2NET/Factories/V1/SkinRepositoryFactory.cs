// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepositoryFactory.cs" company="GW2.NET Coding Team">
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
    using GW2NET.Skins;
    using GW2NET.V1.Skins;
    using GW2NET.V1.Skins.Converters;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class SkinRepositoryFactory
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public SkinRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <returns>A repository.</returns>
        public ISkinRepository this[string language]
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
        /// <returns>A repository.</returns>
        public ISkinRepository this[CultureInfo culture]
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
        public ISkinRepository ForDefaultCulture()
        {
            var skinConverterFactory = new SkinConverterFactory();
            var itemRestrictionCollectionConverter = new ItemRestrictionCollectionConverter(new ItemRestrictionConverter());
            var skinFlagCollectionConverter = new SkinFlagCollectionConverter(new SkinFlagConverter());
            var skinCollectionConverter = new SkinCollectionConverter();
            return new SkinRepository(this.serviceClient, new SkinConverter(skinConverterFactory, itemRestrictionCollectionConverter, skinFlagCollectionConverter), skinCollectionConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public ISkinRepository ForCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            ISkinRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public ISkinRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public ISkinRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}