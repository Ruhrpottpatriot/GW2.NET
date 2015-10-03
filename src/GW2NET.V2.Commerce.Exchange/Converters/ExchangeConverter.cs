// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ExchangeDTO" /> to objects of type <see cref="Exchange" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange.Converters
{
    using System;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.V2.Commerce.Exchange.Json;

    /// <summary>Converts objects of type <see cref="ExchangeDTO"/> to objects of type <see cref="Exchange"/>.</summary>
    public sealed class ExchangeConverter : IConverter<ExchangeDTO, Exchange>
    {
        /// <inheritdoc />
        public Exchange Convert(ExchangeDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is IResponse<ExchangeDTO>");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }

            return new Exchange
            {
                CoinsPerGem = value.CoinsPerGem,
                Receive = value.Quantity,
                Timestamp = response.Date
            };
        }
    }
}