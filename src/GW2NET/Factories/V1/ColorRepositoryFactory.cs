// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepositoryFactory.cs" company="GW2.NET Coding Team">
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

    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.V1.Colors;
    using GW2NET.V1.Colors.Converters;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ColorRepositoryFactory
    {
        
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public ColorRepositoryFactory(IServiceClient serviceClient)
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
        public IColorRepository this[string language]
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
        public IColorRepository this[CultureInfo culture]
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
        public IColorRepository ForDefaultCulture()
        {
            var colorConverter = new ColorConverter();
            var colorModelConverter = new ColorModelConverter(colorConverter);
            var colorPaletteConverter = new ColorPaletteConverter(colorConverter, colorModelConverter);
            var colorPaletteCollectionConverter = new ColorPaletteCollectionConverter(colorPaletteConverter);
            return new ColorRepository(this.serviceClient, colorPaletteCollectionConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public IColorRepository ForCulture(CultureInfo culture)
        {
            var colorConverter = new ColorConverter();
            var colorModelConverter = new ColorModelConverter(colorConverter);
            var colorPaletteConverter = new ColorPaletteConverter(colorConverter, colorModelConverter);
            var colorPaletteCollectionConverter = new ColorPaletteCollectionConverter(colorPaletteConverter);
            IColorRepository repository = new ColorRepository(this.serviceClient, colorPaletteCollectionConverter);
            repository.Culture = culture;
            return repository;
        }

        /// <summary>Creates an instance for the current system language.</summary>
        /// <returns>A repository.</returns>
        public IColorRepository ForCurrentCulture()
        {
            return this.ForCulture(CultureInfo.CurrentCulture);
        }

        /// <summary>Creates an instance for the current UI language.</summary>
        /// <returns>A repository.</returns>
        public IColorRepository ForCurrentUICulture()
        {
            return this.ForCulture(CultureInfo.CurrentUICulture);
        }
    }
}