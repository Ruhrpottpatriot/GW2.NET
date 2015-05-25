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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="IDictionary{TKey,TValue}"/> to objects of type <see cref="IDictionary{TKey, TValue}"/>.</summary>
    /// <typeparam name="TKeyInput">The type of keys in the input dictionary.</typeparam>
    /// <typeparam name="TValueInput">The type of values in the input dictionary.</typeparam>
    /// <typeparam name="TKeyOutput">The type of keys in the output dictionary.</typeparam>
    /// <typeparam name="TValueOutput">The type of values in the output dictionary.</typeparam>
    public sealed class ConverterForIDictionary<TKeyInput, TValueInput, TKeyOutput, TValueOutput> : IConverter<IDictionary<TKeyInput, TValueInput>, IDictionary<TKeyOutput, TValueOutput>>
    {
        private readonly IConverter<KeyValuePair<TKeyInput, TValueInput>, KeyValuePair<TKeyOutput, TValueOutput>> converterForKeyValuePair;

        /// <summary>Initializes a new instance of the <see cref="ConverterForIDictionary{TKeyInput,TValueInput,TKeyOutput,TValueOutput}"/> class.</summary>
        /// <param name="converterForKeyValuePair">The converter for <see cref="KeyValuePair{TKey,TValue}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="converterForKeyValuePair"/> is null.</exception>
        public ConverterForIDictionary(IConverter<KeyValuePair<TKeyInput, TValueInput>, KeyValuePair<TKeyOutput, TValueOutput>> converterForKeyValuePair)
        {
            if (converterForKeyValuePair == null)
            {
                throw new ArgumentNullException("converterForKeyValuePair", "Precondition: converterForKeyValuePair != null");
            }

            this.converterForKeyValuePair = converterForKeyValuePair;
        }

        /// <inheritdoc />
        public IDictionary<TKeyOutput, TValueOutput> Convert(IDictionary<TKeyInput, TValueInput> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var values = new Dictionary<TKeyOutput, TValueOutput>(value.Count) as IDictionary<TKeyOutput, TValueOutput>;
            foreach (var kvp in value.Select(value1 => this.converterForKeyValuePair.Convert(value1, state)))
            {
                values.Add(kvp);
            }

            return values;
        }
    }
}