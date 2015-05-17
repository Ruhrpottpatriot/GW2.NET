// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods and properties for creating a map repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Provides methods and properties for creating a map repository.</summary>
    public class MapsRepositoryFactory : RepositoryFactoryBase<IMapRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="MapsRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public MapsRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IMapRepository ForDefaultCulture()
        {
            return new MapRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IMapRepository ForCulture(CultureInfo culture)
        {
            IMapRepository repository = new MapRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }
    }
}
