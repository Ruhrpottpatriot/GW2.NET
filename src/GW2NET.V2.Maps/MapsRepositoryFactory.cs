// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapsRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods and properties fore creating a map repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps
{
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Maps;
    using GW2NET.V2.Worlds;

    /// <summary>Provides methods and properties fore creating a map repository.</summary>
    public class MapsRepositoryFactory : RepositoryFactoryBase<IMapRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapsRepositoryFactory"/> class.
        /// </summary>
        /// <param name="serviceClient">
        /// The service client.
        /// </param>
        public MapsRepositoryFactory(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IMapRepository ForDefaultCulture()
        {
            Contract.Ensures(Contract.Result<IMapRepository>() != null);
            return new MapRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IMapRepository ForCulture(CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IMapRepository>() != null);
            IMapRepository repository = new MapRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }
    }
}
