// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Provides methods and properties for creating a skin repository.</summary>
    public class SkinRepositoryFactory : RepositoryFactoryBase<ISkinRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="SkinRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public SkinRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override ISkinRepository ForDefaultCulture()
        {
            return new SkinRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override ISkinRepository ForCulture(CultureInfo culture)
        {
            ISkinRepository repository = new SkinRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }
    }
}
