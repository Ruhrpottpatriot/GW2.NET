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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Converts objects of type <see cref="ICollection{T}"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    /// <typeparam name="TInput">The type of the input.</typeparam>
    /// <typeparam name="TOutput">The type of the output.</typeparam>
    public sealed class ConverterForCollection<TInput, TOutput> : IConverter<ICollection<TInput>, ICollection<TOutput>>
    {
        private readonly IConverter<TInput, TOutput> converterForOutput;

        /// <summary>Initializes a new instance of the <see cref="ConverterForCollection{TInput,TOutput}"/> class.</summary>
        /// <param name="converterForOutput">The converter for <typeparamref name="TOutput"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="converterForOutput"/> is null.</exception>
        public ConverterForCollection(IConverter<TInput, TOutput> converterForOutput)
        {
            if (converterForOutput == null)
            {
                throw new ArgumentNullException("converterForOutput", "Precondition: converterForOutput != null");
            }

            this.converterForOutput = converterForOutput;
        }

        /// <inheritdoc />
        public ICollection<TOutput> Convert(ICollection<TInput> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var values = new List<TOutput>(value.Count);
            values.AddRange(value.Select(this.converterForOutput.Convert));
            return values;
        }
    }
}
