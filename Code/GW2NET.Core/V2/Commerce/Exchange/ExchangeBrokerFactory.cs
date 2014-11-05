// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeBrokerFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides methods for creating broker objects.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Commerce;

    /// <summary>Provides methods for creating broker objects.</summary>
    public sealed class ExchangeBrokerFactory
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ExchangeBrokerFactory"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ExchangeBrokerFactory(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Creates an instance for the given currency.</summary>
        /// <param name="identifier">The identifier (either 'gems' or 'coins').</param>
        /// <returns>A broker.</returns>
        public IBroker<GemQuotation> this[string identifier]
        {
            get
            {
                Contract.Requires(identifier != null);
                return this.ForCurrency(identifier);
            }
        }

        /// <summary>Creates an instance for the given currency.</summary>
        /// <param name="identifier">The identifier (either 'gems' or 'coins').</param>
        /// <returns>A broker.</returns>
        public IBroker<GemQuotation> ForCurrency(string identifier)
        {
            Contract.Requires(identifier != null);
            Contract.Ensures(Contract.Result<IBroker<GemQuotation>>() != null);
            return new ExchangeBroker(this.serviceClient, identifier);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
        }
    }
}