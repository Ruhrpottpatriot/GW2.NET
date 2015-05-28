// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ExchangeDataContract" /> to objects of type <see cref="Exchange" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Commerce.Exchange.Converters
{
    using System;

    using GW2NET.Commerce;
    using GW2NET.Common;
    using GW2NET.V2.Commerce.Exchange.Json;

    /// <summary>Converts objects of type <see cref="ExchangeDataContract"/> to objects of type <see cref="Exchange"/>.</summary>
    public sealed class ExchangeConverter : IConverter<ExchangeDataContract, Exchange>
    {
        /// <inheritdoc />
        public Exchange Convert(ExchangeDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state != null");
            }

            var response = state as IResponse<ExchangeDataContract>;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse<ExchangeDataContract>", "state");
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