// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponseConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="TValue" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of a different type.</summary>
    /// <typeparam name="TDTO">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted value.</typeparam>
    public sealed class ResponseConverter<TDTO, TValue> : IConverter<IResponse<TDTO>, TValue>
    {
        private readonly IConverter<TDTO, TValue> dataContractConverter;

        /// <summary>Initializes a new instance of the <see cref="ResponseConverter{TDTO,TValue}"/> class.</summary>
        /// <param name="dataContractConverter">The converter for <typeparamref name="TDTO"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="dataContractConverter"/> is a null reference.</exception>
        public ResponseConverter(IConverter<TDTO, TValue> dataContractConverter)
        {
            if (dataContractConverter == null)
            {
                throw new ArgumentNullException("dataContractConverter");
            }

            this.dataContractConverter = dataContractConverter;
        }

        /// <inheritdoc />
        TValue IConverter<IResponse<TDTO>, TValue>.Convert(IResponse<TDTO> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var dataContract = value.Content;
            if (object.Equals(dataContract, default(TDTO)))
            {
                return default(TValue);
            }

            var item = this.dataContractConverter.Convert(dataContract, value);

            return item;
        }
    }
}