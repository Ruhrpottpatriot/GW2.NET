// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV2Authorized.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the authorized part of the version 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories.Services
{
    using System;
    using Common;

    /// <summary>Provides access to the authorized part of the version 2 API.</summary>
    public class AuthorizedServices : ServiceFactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="AuthorizedServices"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public AuthorizedServices(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the accounts endpoint.</summary>
        public AccountRepositoryFactory Accounts
        {
            get
            {
                return new AccountRepositoryFactory(this.ServiceClient);
            }
        }
    }
}