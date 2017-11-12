// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="TValue" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="TValue"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted value.</typeparam>
    public sealed class ConverterForResponse<TDataContract, TValue> : IConverter<IResponse<TDataContract>, TValue>
    {
        private readonly IConverter<TDataContract, TValue> converterForDataContract;

        /// <summary>Initializes a new instance of the <see cref="ConverterForResponse{TDataContract,TValue}"/> class.</summary>
        /// <param name="converterForDataContract">The converter for <typeparamref name="TDataContract"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForDataContract"/> is a null reference.</exception>
        public ConverterForResponse(IConverter<TDataContract, TValue> converterForDataContract)
        {
            if (converterForDataContract == null)
            {
                throw new ArgumentNullException("converterForDataContract", "Precondition: converterForDataContract != null");
            }

            this.converterForDataContract = converterForDataContract;
        }

        /// <inheritdoc />
        TValue IConverter<IResponse<TDataContract>, TValue>.Convert(IResponse<TDataContract> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var dataContract = value.Content;
            if (object.Equals(dataContract, default(TDataContract)))
            {
                return default(TValue);
            }

            var item = this.converterForDataContract.Convert(dataContract);
            var localizableItem = item as ILocalizable;
            if (localizableItem != null)
            {
                localizableItem.Culture = value.Culture;
            }

            var timeSensitiveItem = item as ITimeSensitive;
            if (timeSensitiveItem != null)
            {
                timeSensitiveItem.Timestamp = value.Date;
            }

            return item;
        }
    }
}
