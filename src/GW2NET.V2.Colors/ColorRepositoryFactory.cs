// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorRepositoryFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.V2.Colors.Converters;

    /// <summary>Provides methods and properties for creating a color repository.</summary>
    public sealed class ColorRepositoryFactory : RepositoryFactoryBase<IColorRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IColorRepository ForDefaultCulture()
        {
            return new ColorRepository(this.serviceClient, new ConverterAdapter<ICollection<int>>(), new ColorPaletteConverter(new ColorConverter(), new ColorModelConverter(new ColorConverter())));
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IColorRepository ForCulture(CultureInfo culture)
        {
            IColorRepository repository = new ColorRepository(this.serviceClient, new ConverterAdapter<ICollection<int>>(), new ColorPaletteConverter(new ColorConverter(), new ColorModelConverter(new ColorConverter())));
            repository.Culture = culture;
            return repository;
        }
    }
}
