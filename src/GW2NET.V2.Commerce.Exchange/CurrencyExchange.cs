// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurrencyExchange.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a currency exchange service that retrieves data from the /v2/commerce/exchange interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.V2.Commerce.Exchange.Json;

    /// <summary>Represents a currency exchange service that retrieves data from the /v2/commerce/exchange interface.</summary>
    public class CurrencyExchange : ICurrencyExchange
    {
        private readonly IServiceClient serviceClient;

        private readonly IConverter<ExchangeDataContract, Exchange> exchangeConverter;

        public CurrencyExchange(IServiceClient serviceClient, IConverter<ExchangeDataContract, Exchange> exchangeConverter)
        {
            if (serviceClient == null)
            {
                throw new ArgumentNullException("serviceClient", "Precondition: serviceClient != null");
            }

            if (exchangeConverter == null)
            {
                throw new ArgumentNullException("exchangeConverter", "Precondition: exchangeConverter != null");
            }

            this.serviceClient = serviceClient;
            this.exchangeConverter = exchangeConverter;
        }

        public Exchange GetCoins(int gems)
        {
            var request = new GemsExchangeRequest
            {
                Quantity = gems
            };

            var response = this.serviceClient.Send<ExchangeDataContract>(request);
            var exchange = this.exchangeConverter.Convert(response.Content, response);

            // Patch the quantity because it is not a property of the response object
            exchange.Send = gems;

            return exchange;
        }

        public Task<Exchange> GetCoinsAsync(int gems)
        {
            return this.GetCoinsAsync(gems, CancellationToken.None);
        }

        public async Task<Exchange> GetCoinsAsync(int gems, CancellationToken cancellationToken)
        { var request = new GemsExchangeRequest
            {
                Quantity = gems
            };

            var response = await this.serviceClient.SendAsync<ExchangeDataContract>(request, cancellationToken).ConfigureAwait(false);
            var exchange = this.exchangeConverter.Convert(response.Content, response);

            // Patch the quantity because it is not a property of the response object
            exchange.Send = gems;

            return exchange;
        }

        public Exchange GetGems(int coins)
        {
            var request = new CoinsExchangeRequest
            {
                Quantity = coins
            };

            var response = this.serviceClient.Send<ExchangeDataContract>(request);
            var exchange = this.exchangeConverter.Convert(response.Content, response);

            // Patch the quantity because it is not a property of the response object
            exchange.Send = coins;

            return exchange;
        }

        public Task<Exchange> GetGemsAsync(int coins)
        {
            return this.GetGemsAsync(coins, CancellationToken.None);
        }

        public async Task<Exchange> GetGemsAsync(int coins, CancellationToken cancellationToken)
        {
            var request = new GemsExchangeRequest
            {
                Quantity = coins
            };
            var response = await this.serviceClient.SendAsync<ExchangeDataContract>(request, cancellationToken).ConfigureAwait(false);
            var exchange = this.exchangeConverter.Convert(response.Content, response);

            // Patch the quantity because it is not a property of the response object
            exchange.Send = coins;

            return exchange;
        }
    }
}