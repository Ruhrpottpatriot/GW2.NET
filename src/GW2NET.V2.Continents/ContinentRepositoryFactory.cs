// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContinentRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating a continent repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Continents
{
    using System.Diagnostics.Contracts;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Maps;

    /// <summary>Provides methods for creating a continent repository.</summary>
    public class ContinentRepositoryFactory : RepositoryFactoryBase<IContinentRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ContinentRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ContinentRepositoryFactory(IServiceClient serviceClient)
        {
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IContinentRepository ForDefaultCulture()
        {
            Contract.Ensures(Contract.Result<IContinentRepository>() != null);
            return new ContinentRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IContinentRepository ForCulture(CultureInfo culture)
        {
            Contract.Ensures(Contract.Result<IContinentRepository>() != null);
            IContinentRepository repository = new ContinentRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }
    }
}
