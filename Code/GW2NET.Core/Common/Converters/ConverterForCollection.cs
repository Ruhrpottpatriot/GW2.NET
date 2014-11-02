// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ICollection{T}" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="ICollection{T}"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    internal sealed class ConverterForCollection<TInput, TOutput> : IConverter<ICollection<TInput>, ICollection<TOutput>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<TInput, TOutput> converterForOutput;

        /// <summary>Initializes a new instance of the <see cref="ConverterForCollection{TInput,TOutput}"/> class.</summary>
        /// <param name="converterForOutput">The converter for <typeparamref name="TOutput"/>.</param>
        internal ConverterForCollection(IConverter<TInput, TOutput> converterForOutput)
        {
            Contract.Requires(converterForOutput != null);
            this.converterForOutput = converterForOutput;
        }

        /// <summary>Converts the given object of type <see cref="ICollection{T}"/> to an object of type <see cref="ICollection{T}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<TOutput> Convert(ICollection<TInput> value)
        {
            Contract.Assume(value != null);
            var values = new List<TOutput>(value.Count);
            values.AddRange(value.Select(this.converterForOutput.Convert));
            return values;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForOutput != null);
        }
    }
}