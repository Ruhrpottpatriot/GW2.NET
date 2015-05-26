// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCollectionResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted values.</typeparam>
    public sealed class ConverterForCollectionResponse<TDataContract, TValue> : IConverter<IResponse<ICollection<TDataContract>>, ICollection<TValue>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TDataContract, TValue> converterForDataContract;

        /// <summary>Initializes a new instance of the <see cref="ConverterForCollectionResponse{TDataContract,TValue}"/> class.</summary>
        /// <param name="converterForDataContract">The converter for <typeparamref name="TDataContract"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForDataContract"/> is a null reference.</exception>
        public ConverterForCollectionResponse(IConverter<TDataContract, TValue> converterForDataContract)
        {
            if (converterForDataContract == null)
            {
                throw new ArgumentNullException("converterForDataContract", "Precondition: converterForDataContract != null");
            }

            this.converterForDataContract = converterForDataContract;
        }

        /// <inheritdoc />
        ICollection<TValue> IConverter<IResponse<ICollection<TDataContract>>, ICollection<TValue>>.Convert(IResponse<ICollection<TDataContract>> value, object state)
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

            collection.AddRange(dataContracts.Select(value1 => this.converterForDataContract.Convert(value1, state)));

#if (DEBUG)
            // TODO: Refactor data contract converters so that this code can be deleted
            foreach (var localizableItem in collection.OfType<ILocalizable>())
            {
                Debug.Assert(Equals(localizableItem.Culture, value.Culture), "Equals(localizableItem.Culture, value.Culture)");
            }


            // TODO: Refactor data contract converters so that this code can be deleted
            foreach (var timeSensitiveItem in collection.OfType<ITimeSensitive>())
            {
                Debug.Assert(timeSensitiveItem.Timestamp == value.Date, "timeSensitiveItem.Timestamp == value.Date");
            }
#endif

            return collection;
        }
    }
}