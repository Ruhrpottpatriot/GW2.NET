// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorRepositoryFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.V2
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V2.Colors;
    using GW2NET.V2.Colors.Converters;
    using GW2NET.V2.Colors.Json;

    /// <summary>Provides methods and properties for creating a color repository.</summary>
    public sealed class ColorRepositoryFactory : RepositoryFactoryBase<IColorRepository>
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient"></param>
        public ColorRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IColorRepository ForDefaultCulture()
        {
            var colorConverter = new ColorConverter();
            var colorModelConverter = new ColorModelConverter(colorConverter);
            var colorPaletteConverter = new ColorPaletteConverter(colorConverter, colorModelConverter);
            var identifiersResponseConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<ColorPaletteDTO, ColorPalette>(colorPaletteConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<ColorPaletteDTO, int, ColorPalette>(colorPaletteConverter, color => color.ColorId);
            var pageResponseConverter = new CollectionPageResponseConverter<ColorPaletteDTO, ColorPalette>(colorPaletteConverter);
            return new ColorRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IColorRepository ForCulture(CultureInfo culture)
        {
            var colorConverter = new ColorConverter();
            var colorModelConverter = new ColorModelConverter(colorConverter);
            var colorPaletteConverter = new ColorPaletteConverter(colorConverter, colorModelConverter);
            var identifiersResponseConverter = new ResponseConverter<ICollection<int>, ICollection<int>>(new ConverterAdapter<ICollection<int>>());
            var responseConverter = new ResponseConverter<ColorPaletteDTO, ColorPalette>(colorPaletteConverter);
            var bulkResponseConverter = new DictionaryRangeResponseConverter<ColorPaletteDTO, int, ColorPalette>(colorPaletteConverter, color => color.ColorId);
            var pageResponseConverter = new CollectionPageResponseConverter<ColorPaletteDTO, ColorPalette>(colorPaletteConverter);
            IColorRepository repository = new ColorRepository(this.serviceClient, identifiersResponseConverter, responseConverter, bulkResponseConverter, pageResponseConverter);
            repository.Culture = culture;
            return repository;
        }
    }
}
