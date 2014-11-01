// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForResponse.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IResponse{T}" /> to objects of type <see cref="TValue" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="IResponse{T}"/> to objects of type <see cref="TValue"/>.</summary>
    /// <typeparam name="TDataContract">The type of data contracts in the response content.</typeparam>
    /// <typeparam name="TValue">The type of the converted value.</typeparam>
    internal sealed class ConverterForResponse<TDataContract, TValue> : IConverter<IResponse<TDataContract>, TValue>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TDataContract, TValue> converterForDataContract;

        /// <summary>Initializes a new instance of the <see cref="ConverterForResponse{TDataContract,TValue}"/> class.</summary>
        /// <param name="converterForDataContract">The converter for <typeparamref name="TDataContract"/>.</param>
        internal ConverterForResponse(IConverter<TDataContract, TValue> converterForDataContract)
        {
            Contract.Requires(converterForDataContract != null);
            this.converterForDataContract = converterForDataContract;
        }

        /// <inheritdoc />
        TValue IConverter<IResponse<TDataContract>, TValue>.Convert(IResponse<TDataContract> value)
        {
            Contract.Assume(value != null);
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

            return item;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForDataContract != null);
        }
    }
}