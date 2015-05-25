// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeBroker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a broker that retrieves data from the /v2/commerce/exchange interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.Common;

    /// <summary>Represents a broker that retrieves data from the /v2/commerce/exchange interface.</summary>
    public class ExchangeBroker : IExchangeBroker
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<GemQuotationDataContract>, GemQuotation> converterForResponse;

        /// <summary>The identifier for the broker.</summary>
        private readonly string identifier;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ExchangeBroker"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="identifier">The identifier for the broker (either 'gems' or 'coins').</param>
        public ExchangeBroker(IServiceClient serviceClient, string identifier)
            : this(serviceClient, identifier, new ConverterForGemQuotation())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="ExchangeBroker"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="identifier">The identifier for the broker (either 'gems' or 'coins').</param>
        /// <param name="converterForGemQuotation">The converter <see cref="GemQuotation"/>.</param>
        internal ExchangeBroker(IServiceClient serviceClient, string identifier, IConverter<GemQuotationDataContract, GemQuotation> converterForGemQuotation)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForGemQuotation != null);
            this.serviceClient = serviceClient;
            this.identifier = identifier;
            this.converterForResponse = new ConverterForResponse<GemQuotationDataContract, GemQuotation>(converterForGemQuotation);
        }

        /// <inheritdoc />
        GemQuotation IBroker<GemQuotation>.GetQuotation(long quantity)
        {
            var request = new ExchangeDetailsRequest()
            {
                Identifier = this.identifier, 
                Quantity = quantity
            };
            var response = this.serviceClient.Send<GemQuotationDataContract>(request);
            var value = this.converterForResponse.Convert(response);
            if (value == null)
            {
                return null;
            }

            value.Id = this.identifier;
            value.Send = quantity;
            return value;
        }

        /// <inheritdoc />
        Task<GemQuotation> IBroker<GemQuotation>.GetQuotationAsync(long quantity)
        {
            IExchangeBroker self = this;
            return self.GetQuotationAsync(quantity, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<GemQuotation> IBroker<GemQuotation>.GetQuotationAsync(long quantity, CancellationToken cancellationToken)
        {
            var request = new ExchangeDetailsRequest
            {
                Identifier = this.identifier, 
                Quantity = quantity
            };
            var responseTask = this.serviceClient.SendAsync<GemQuotationDataContract>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, quantity), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private GemQuotation ConvertAsyncResponse(Task<IResponse<GemQuotationDataContract>> task, long quantity)
        {
            Contract.Requires(task != null);
            var value = this.converterForResponse.Convert(task.Result);
            if (value == null)
            {
                return null;
            }

            value.Id = this.identifier;
            value.Send = quantity;
            return value;
        }
    }
}