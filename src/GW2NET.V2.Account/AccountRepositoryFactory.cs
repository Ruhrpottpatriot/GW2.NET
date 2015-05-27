// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountRepositoryFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Accounts
{
    using System;
    using System.Globalization;
    using GW2NET.Accounts;
    using GW2NET.Common;

    /// <summary>Provides methods and properties for creating an account repository.</summary>
    public sealed class AccountRepositoryFactory : RepositoryFactoryBase<IAccountRepository>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="AccountRepositoryFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">Thrown when the service client is null.</exception>
        public AccountRepositoryFactory(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the default language.</summary>
        /// <returns>A repository.</returns>
        public override IAccountRepository ForDefaultCulture()
        {
            return new AccountRepository(this.serviceClient);
        }

        /// <summary>Creates an instance for the given language.</summary>
        /// <param name="culture">The culture.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="culture"/> is a null reference.</exception>
        /// <returns>A repository.</returns>
        public override IAccountRepository ForCulture(CultureInfo culture)
        {
            throw new NotSupportedException("Accounts do not support localized data");
        }
    }
}
