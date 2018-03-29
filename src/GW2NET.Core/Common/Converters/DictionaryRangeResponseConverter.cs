// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryRangeResponseConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="T:IDictionaryRange&lt;TKey, TValue&gt;"/>.</summary>
    /// <typeparam name="TDTO">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TKey">The type of the key values.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    public sealed class DictionaryRangeResponseConverter<TDTO, TKey, TValue> : IConverter<IResponse<ICollection<TDTO>>, IDictionaryRange<TKey, TValue>>
    {
        private readonly IConverter<TDTO, TValue> dataContractConverter;

        private readonly Func<TValue, TKey> keySelector;

        /// <summary>Initializes a new instance of the <see cref="DictionaryRangeResponseConverter{TDTO,TKey,TValue}"/> class.</summary>
        /// <param name="dataContractConverter">The converter for <typeparamref name="TValue"/>.</param>
        /// <param name="keySelector">The key selector expression.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="dataContractConverter"/> or <paramref name="keySelector"/> is a null reference.</exception>
        public DictionaryRangeResponseConverter(IConverter<TDTO, TValue> dataContractConverter, Func<TValue, TKey> keySelector)
        {
            if (dataContractConverter == null)
            {
                throw new ArgumentNullException("dataContractConverter");
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }

            this.dataContractConverter = dataContractConverter;
            this.keySelector = keySelector;
        }

        /// <inheritdoc />
        IDictionaryRange<TKey, TValue> IConverter<IResponse<ICollection<TDTO>>, IDictionaryRange<TKey, TValue>>.Convert(IResponse<ICollection<TDTO>> value, object state)
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

            foreach (var item in dataContracts.Select(dataContract => this.dataContractConverter.Convert(dataContract, value)))
            {
                range.Add(this.keySelector(item), item);
            }

            return range;
        }
    }
}