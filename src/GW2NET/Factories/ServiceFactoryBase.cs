// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryBase.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using System;
    using System.Diagnostics;

    using GW2NET.Common;

    /// <summary>Provides access to the Guild Wars 2 service.</summary>
    public abstract class ServiceFactoryBase
    {
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ServiceFactoryBase"/> class.</summary>
        /// <param name="serviceClient"></param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        protected ServiceFactoryBase(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an instance of a service client.</summary>
        protected IServiceClient ServiceClient
        {
            get
            {
                Debug.Assert(this.serviceClient != null, "this.serviceClient != null");
                return this.serviceClient;
            }
        }
    }
}