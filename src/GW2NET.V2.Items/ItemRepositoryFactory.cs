// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating repository objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Globalization;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Provides methods for creating repository objects.</summary>
    public sealed class ItemRepositoryFactory : RepositoryFactoryBase<IItemRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ItemRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ItemRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IItemRepository ForDefaultCulture()
        {
            return new ItemRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <returns>A repository.</returns>
        public override IItemRepository ForCulture(CultureInfo culture)
        {
            IItemRepository repository = new ItemRepository(this.serviceClient);
            repository.Culture = culture;
            return repository;
        }
    }
}