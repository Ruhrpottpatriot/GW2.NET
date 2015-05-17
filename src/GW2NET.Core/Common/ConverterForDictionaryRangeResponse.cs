// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDictionaryRangeResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TKey">The type of the key values.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    public sealed class ConverterForDictionaryRangeResponse<TDataContract, TKey, TValue> : IConverter<IResponse<ICollection<TDataContract>>, IDictionaryRange<TKey, TValue>>
    {
        private readonly IConverter<TDataContract, TValue> converterForDataContract;

        private readonly Func<TValue, TKey> keySelector;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDictionaryRangeResponse{TDataContract,TKey,TValue}"/> class.</summary>
        /// <param name="converterForDataContract">The converter for <typeparamref name="TValue"/>.</param>
        /// <param name="keySelector">The key selector expression.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForDataContract"/> or <paramref name="keySelector"/> is a null reference.</exception>
        public ConverterForDictionaryRangeResponse(IConverter<TDataContract, TValue> converterForDataContract, Func<TValue, TKey> keySelector)
        {
            if (converterForDataContract == null)
            {
                throw new ArgumentNullException("converterForDataContract", "Precondition: converterForDataContract != null");
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector", "Precondition: keySelector != null");
            }

            this.converterForDataContract = converterForDataContract;
            this.keySelector = keySelector;
        }

        /// <inheritdoc />
        IDictionaryRange<TKey, TValue> IConverter<IResponse<ICollection<TDataContract>>, IDictionaryRange<TKey, TValue>>.Convert(IResponse<ICollection<TDataContract>> value)
        {
            if (value == null)
            {
                return new DictionaryRange<TKey, TValue>(0);
            }

            var dataContracts = value.Content;
            if (dataContracts == null)
            {
                return new DictionaryRange<TKey, TValue>(0);
            }

            var range = new DictionaryRange<TKey, TValue>(dataContracts.Count)
            {
                SubtotalCount = value.GetResultCount(),
                TotalCount = value.GetResultTotal()
            };

            foreach (var item in dataContracts.Select(this.converterForDataContract.Convert))
            {
                range.Add(this.keySelector(item), item);
            }

            foreach (var localizableItem in range.Values.OfType<ILocalizable>())
            {
                localizableItem.Culture = value.Culture;
            }

            foreach (var timeSensitiveItem in range.Values.OfType<ITimeSensitive>())
            {
                timeSensitiveItem.Timestamp = value.Date;
            }

            return range;
        }
    }
}