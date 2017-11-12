// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET
{
    using System;
    using System.Diagnostics;

    using GW2NET.Common;

    /// <summary>Provides access to the Guild Wars 2 service.</summary>
    public abstract class ServiceFactory
    {
        /// <summary>Infrastructure. Holds a reference to a service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ServiceFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ServiceFactory(IServiceClient serviceClient)
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
