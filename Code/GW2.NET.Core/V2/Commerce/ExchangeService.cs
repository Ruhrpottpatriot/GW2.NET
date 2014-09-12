// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeService.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the Trading Post exchange service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V2.Commerce
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2DotNET.Common;
    using GW2DotNET.Entities.Commerce;
    using GW2DotNET.V2.Commerce.Json;
    using GW2DotNET.V2.Common;

    /// <summary>Provides access to the Trading Post exchange service.</summary>
    /// <remarks>See: <a href="http://wiki.guildwars2.com/wiki/API:2/commerce/exchange">wiki</a></remarks>  
    public class ExchangeService : IBroker<string, ExchangeQuote>
    {
        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ExchangeService"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ExchangeService(IServiceClient serviceClient)
        {
            Contract.Requires(serviceClient != null);
            this.serviceClient = serviceClient;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public ICollection<string> Discover()
        {
            var request = new ExchangeDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            if (response.Content == null)
            {
                return new List<string>(0);
            }

            return response.Content;
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<string>> DiscoverAsync()
        {
            return this.DiscoverAsync(CancellationToken.None);
        }

        /// <summary>Gets the discovered identifiers.</summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A collection of discovered identifiers.</returns>
        public Task<ICollection<string>> DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new ExchangeDiscoveryRequest();
            return this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return new List<string>(0);
                        }

                        return response.Content;
                    }, 
                cancellationToken);
        }

        /// <summary>Gets a quote for the specified number of commodities.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>A quote.</returns>
        public ExchangeQuote GetQuote(string identifier, int quantity)
        {
            var request = new ExchangeDetailsRequest() { Identifier = identifier, Quantity = quantity };
            var response = this.serviceClient.Send<ExchangeQuoteDataContract>(request);
            if (response.Content == null)
            {
                return null;
            }

            return ConvertExchangeRateDataContract(response.Content);
        }

        /// <summary>Gets a quote for the specified number of commodities.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>A quote.</returns>
        public Task<ExchangeQuote> GetQuoteAsync(string identifier, int quantity)
        {
            return this.GetQuoteAsync(identifier, quantity, CancellationToken.None);
        }

        /// <summary>Gets a quote for the specified number of commodities.</summary>
        /// <param name="identifier">The identifier that identifies the commodity.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> that provides cancellation support.</param>
        /// <returns>A quote.</returns>
        public Task<ExchangeQuote> GetQuoteAsync(string identifier, int quantity, CancellationToken cancellationToken)
        {
            var request = new ExchangeDetailsRequest { Identifier = identifier, Quantity = quantity };
            return this.serviceClient.SendAsync<ExchangeQuoteDataContract>(request, cancellationToken).ContinueWith(
                task =>
                    {
                        var response = task.Result;
                        if (response.Content == null)
                        {
                            return null;
                        }

                        return ConvertExchangeRateDataContract(response.Content);
                    }, 
                cancellationToken);
        }

        /// <summary>Infrastructure. Converts data contracts to entities.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The entity.</returns>
        private static ExchangeQuote ConvertExchangeRateDataContract(ExchangeQuoteDataContract content)
        {
            return new ExchangeQuote { CoinsPerGem = content.CoinsPerGem, Quantity = content.Quantity };
        }
    }
}