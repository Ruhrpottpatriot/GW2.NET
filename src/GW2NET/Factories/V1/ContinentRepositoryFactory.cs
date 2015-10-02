// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
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
    using GW2NET.Maps;
    using GW2NET.V1.Continents;
    using GW2NET.V1.Continents.Converters;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ContinentRepositoryFactory
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

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="language">The two-letter language code.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="language"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public IContinentRepository this[string language]
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
        public IContinentRepository this[CultureInfo culture]
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
        public IContinentRepository ForDefaultCulture()
        {
            var size2DConverter = new Size2DConverter();
            var continentConverter = new ContinentConverter(size2DConverter);
            var continentCollectionConverter = new ContinentCollectionConverter(continentConverter);
            return new ContinentRepository(this.serviceClient, continentCollectionConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IContinentRepository ForCulture(CultureInfo culture)
        {
            var size2DConverter = new Size2DConverter();
            var continentConverter = new ContinentConverter(size2DConverter);
            var continentCollectionConverter = new ContinentCollectionConverter(continentConverter);
            IContinentRepository repository = new ContinentRepository(this.serviceClient, continentCollectionConverter);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IContinentRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IContinentRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}