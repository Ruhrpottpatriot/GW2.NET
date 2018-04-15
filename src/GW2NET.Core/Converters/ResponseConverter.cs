// <copyright file="ResponseConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Common.Converters
{
    using System;
    using GW2NET.Converters;

    /// <summary>Converts objects of type <see cref="IApiData{T}"/> to objects of a different type.</summary>
    /// <typeparam name="TDTO">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted value.</typeparam>
    public sealed class ResponseConverter<TDTO, TValue> : IConverter<IApiData<TDTO>, TValue>
    {
        /// <summary>Initializes a new instance of the <see cref="ResponseConverter{TDTO,TValue}"/> class.</summary>
        /// <param name="dataContractConverter">The converter for <typeparamref name="TDTO"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="dataContractConverter"/> is a null reference.</exception>
        public ResponseConverter(IConverter<TDTO, TValue> dataContractConverter)
        {
            this.DataContractConverter = dataContractConverter ?? throw new ArgumentNullException(nameof(dataContractConverter));
        }

        public IConverter<TDTO, TValue> DataContractConverter { get; }

        /// <inheritdoc />
        TValue IConverter<IApiData<TDTO>, TValue>.Convert(IApiData<TDTO> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var dataContract = value.Content;
            if (object.Equals(dataContract, default(TDTO)))
            {
                return default;
            }

            var item = this.DataContractConverter.Convert(dataContract, value);

            return item;
        }
    }
}