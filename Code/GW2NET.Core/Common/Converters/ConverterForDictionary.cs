// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDictionary.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="IDictionary{TKey,TValue}" /> to objects of type <see cref="IDictionary{TKey, TValue}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IDictionary{TKey,TValue}"/> to objects of type <see cref="IDictionary{TKey, TValue}"/>.</summary>
    /// <typeparam name="TKeyInput">The type of keys in the input dictionary.</typeparam>
    /// <typeparam name="TValueInput">The type of values in the input dictionary.</typeparam>
    /// <typeparam name="TKeyOutput">The type of keys in the output dictionary.</typeparam>
    /// <typeparam name="TValueOutput">The type of values in the output dictionary.</typeparam>
    public sealed class ConverterForIDictionary<TKeyInput, TValueInput, TKeyOutput, TValueOutput> : IConverter<IDictionary<TKeyInput, TValueInput>, IDictionary<TKeyOutput, TValueOutput>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<KeyValuePair<TKeyInput, TValueInput>, KeyValuePair<TKeyOutput, TValueOutput>> converterForKeyValuePair;

        /// <summary>Initializes a new instance of the <see cref="ConverterForIDictionary{TKeyInput,TValueInput,TKeyOutput,TValueOutput}"/> class.</summary>
        /// <param name="converterForKeyValuePair">The converter for <see cref="KeyValuePair{TKey,TValue}"/>.</param>
        public ConverterForIDictionary(IConverter<KeyValuePair<TKeyInput, TValueInput>, KeyValuePair<TKeyOutput, TValueOutput>> converterForKeyValuePair)
        {
            Contract.Requires(converterForKeyValuePair != null);
            this.converterForKeyValuePair = converterForKeyValuePair;
        }

        /// <summary>Converts the given object of type <see cref="IDictionary{TKey, TValue}"/> to an object of type <see cref="IDictionary{TKey, TValue}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public IDictionary<TKeyOutput, TValueOutput> Convert(IDictionary<TKeyInput, TValueInput> value)
        {
            Contract.Assume(value != null);
            var values = new Dictionary<TKeyOutput, TValueOutput>(value.Count) as IDictionary<TKeyOutput, TValueOutput>;
            foreach (var kvp in value.Select(this.converterForKeyValuePair.Convert))
            {
                values.Add(kvp);
            }

            return values;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForKeyValuePair != null);
        }
    }
}