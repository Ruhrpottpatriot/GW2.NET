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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
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
        public ConverterForCollectionResponse(IConverter<TDataContract, TValue> converterForDataContract)
        {
            Contract.Requires(converterForDataContract != null);
            this.converterForDataContract = converterForDataContract;
        }

        /// <inheritdoc />
        ICollection<TValue> IConverter<IResponse<ICollection<TDataContract>>, ICollection<TValue>>.Convert(IResponse<ICollection<TDataContract>> value)
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

            collection.AddRange(dataContracts.Select(this.converterForDataContract.Convert));

            foreach (var localizableItem in collection.OfType<ILocalizable>())
            {
                localizableItem.Culture = value.Culture;
            }

            foreach (var timeSensitiveItem in collection.OfType<ITimeSensitive>())
            {
                timeSensitiveItem.Timestamp = value.Date;
            }

            return collection;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForDataContract != null);
        }
    }
}