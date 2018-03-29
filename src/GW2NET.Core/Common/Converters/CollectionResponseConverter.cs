// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionResponseConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    /// <typeparam name="TDTO">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    public sealed class CollectionResponseConverter<TDTO, TValue> : IConverter<IResponse<ICollection<TDTO>>, ICollection<TValue>>
    {
        private readonly IConverter<TDTO, TValue> dataContractConverter;

        /// <summary>Initializes a new instance of the <see cref="CollectionResponseConverter{TDTO,TValue}"/> class.</summary>
        /// <param name="dataContractConverter">The converter for <typeparamref name="TDTO"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="dataContractConverter"/> is a null reference.</exception>
        public CollectionResponseConverter(IConverter<TDTO, TValue> dataContractConverter)
        {
            if (dataContractConverter == null)
            {
                throw new ArgumentNullException("dataContractConverter");
            }

            this.dataContractConverter = dataContractConverter;
        }

        /// <inheritdoc />
        ICollection<TValue> IConverter<IResponse<ICollection<TDTO>>, ICollection<TValue>>.Convert(IResponse<ICollection<TDTO>> value, object state)
        {
            if (value == null)
            {
                return null;
            }

            var dataContracts = value.Content;
            if (dataContracts == null)
            {
                return null;
            }

            var collection = new List<TValue>(dataContracts.Count);

            collection.AddRange(dataContracts.Select(value1 => this.dataContractConverter.Convert(value1, state)));

            return collection;
        }
    }
}