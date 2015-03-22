// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryBase.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Guild Wars 2 service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Factories
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;

    /// <summary>Provides access to the Guild Wars 2 service.</summary>
    public abstract class FactoryBase
    {
        /// <summary>Infrastructure. Holds a reference to a service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="FactoryBase"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        protected FactoryBase(IServiceClient serviceClient)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition failed: serviceClient != null");
            }

            Contract.Ensures(this.serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets an instance of a service client.</summary>
        protected IServiceClient ServiceClient
        {
            get
            {
                Contract.Ensures(Contract.Result<IServiceClient>() != null);
                return this.serviceClient;
            }
        }

        [ContractInvariantMethod]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when CodeContracts are enabled.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the CodeContracts for .NET extension")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}