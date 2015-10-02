// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapRepositoryFactory.cs" company="GW2.NET Coding Team">
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
    using GW2NET.V1.Maps;
    using GW2NET.V1.Maps.Converters;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class MapRepositoryFactory
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public MapRepositoryFactory(IServiceClient serviceClient)
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
        public IMapRepository this[string language]
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
        public IMapRepository this[CultureInfo culture]
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
        public IMapRepository ForDefaultCulture()
        {
            var vector2DConverter = new Vector2DConverter();
            var rectangleConverter = new RectangleConverter(vector2DConverter);
            var mapConverter = new MapConverter(rectangleConverter);
            var mapCollectionConverter = new MapCollectionConverter(mapConverter);
            return new MapRepository(this.serviceClient, mapCollectionConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IMapRepository ForCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            IMapRepository repository = this.ForDefaultCulture();
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IMapRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IMapRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}