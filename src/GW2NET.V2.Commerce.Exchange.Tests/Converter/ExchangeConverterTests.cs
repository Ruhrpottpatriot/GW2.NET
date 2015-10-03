// <copyright file="ExchangeConverterTests.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.V2.Commerce.Exchange.Converter
{
    using System;

    using GW2NET.Common;
    using GW2NET.V2.Commerce.Exchange.Converters;
    using GW2NET.V2.Commerce.Exchange.Json;

    using Xunit;

    public class ExchangeConverterTests
    {
        private readonly ExchangeConverter exchangeConverter = new ExchangeConverter();

        [Theory]
        [InlineData(1785, 56, "Thu, 28 May 2015 12:07:07 GMT")]
        [InlineData(1076, 107676780, "Thu, 28 May 2015 12:13:46 GMT")]
        public void CanConvert(int coinsPerGem, int quantity, DateTime date)
        {
            var value = new ExchangeDTO
            {
                CoinsPerGem = coinsPerGem,
                Quantity = quantity
            };

            var state = new Response<ExchangeDTO>
            {
                Content = value,
                Date = date
            };

            // MEMO: property 'result.Send' is not tested, because it is not included in the data contract
            var result = this.exchangeConverter.Convert(value, state);
            Assert.NotNull(result);
            Assert.Equal(coinsPerGem, result.CoinsPerGem);
            Assert.Equal(quantity, result.Receive);
            Assert.Equal(date, result.Timestamp);
        }
    }
}
