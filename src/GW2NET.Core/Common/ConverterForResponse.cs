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
    using System.Diagnostics;

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
        TValue IConverter<IResponse<TDataContract>, TValue>.Convert(IResponse<TDataContract> value, object state)
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

            var item = this.converterForDataContract.Convert(dataContract, value);


#if (DEBUG)
            // TODO: Refactor data contract converters so that this code can be deleted
            var localizableItem = item as ILocalizable;
            if (localizableItem != null)
            {
                Debug.Assert(Equals(localizableItem.Culture, value.Culture), "Equals(localizableItem.Culture, value.Culture)");
            }

            // TODO: Refactor data contract converters so that this code can be deleted
            var timeSensitiveItem = item as ITimeSensitive;
            if (timeSensitiveItem != null)
            {
                Debug.Assert(timeSensitiveItem.Timestamp == value.Date, "timeSensitiveItem.Timestamp == value.Date");
            }
#endif


            return item;
        }
    }
}