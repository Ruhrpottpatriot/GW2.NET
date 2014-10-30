// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDictionaryRangeResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TKey">The type of the key values.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    internal sealed class ConverterForDictionaryRangeResponse<TDataContract, TKey, TValue> : IConverter<IResponse<ICollection<TDataContract>>, IDictionaryRange<TKey, TValue>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TDataContract, TValue> converterForDataContract;

        /// <summary>Infrastructure. Holds a reference to a key selector expression.</summary>
        private readonly Func<TValue, TKey> keySelector;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDictionaryRangeResponse{TDataContract,TKey,TValue}"/> class.</summary>
        /// <param name="converterForDataContract">The converter for <typeparamref name="TValue"/>.</param>
        /// <param name="keySelector">The key selector expression.</param>
        internal ConverterForDictionaryRangeResponse(IConverter<TDataContract, TValue> converterForDataContract, Func<TValue, TKey> keySelector)
        {
            this.converterForDataContract = converterForDataContract;
            this.keySelector = keySelector;
        }

        /// <inheritdoc />
        IDictionaryRange<TKey, TValue> IConverter<IResponse<ICollection<TDataContract>>, IDictionaryRange<TKey, TValue>>.Convert(IResponse<ICollection<TDataContract>> value)
        {
            var dataContracts = value.Content;
            if (dataContracts == null)
            {
                return new DictionaryRange<TKey, TValue>(0);
            }

            var range = new DictionaryRange<TKey, TValue>(dataContracts.Count) { SubtotalCount = value.GetResultCount(), TotalCount = value.GetResultTotal() };

            foreach (var item in dataContracts.Select(this.converterForDataContract.Convert))
            {
                range.Add(this.keySelector(item), item);
            }

            foreach (var localizableItem in range.Values.OfType<ILocalizable>())
            {
                localizableItem.Culture = value.Culture;
            }

            return range;
        }
    }
}