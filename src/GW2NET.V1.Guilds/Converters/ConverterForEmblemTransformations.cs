// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForEmblemTransformations.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="EmblemTransformations" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Guilds;

namespace GW2NET.V1.Guilds.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="EmblemTransformations"/>.</summary>
    internal sealed class ConverterForEmblemTransformations : IConverter<ICollection<string>, EmblemTransformations>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, EmblemTransformations> converterForEmblemTransformation;

        /// <summary>Initializes a new instance of the <see cref="ConverterForEmblemTransformations"/> class.</summary>
        internal ConverterForEmblemTransformations()
            : this(new ConverterForEmblemTransformation())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForEmblemTransformations"/> class.</summary>
        /// <param name="converterForEmblemTransformation">The converter for <see cref="EmblemTransformations"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForEmblemTransformation"/> is a null reference.</exception>
        internal ConverterForEmblemTransformations(IConverter<string, EmblemTransformations> converterForEmblemTransformation)
        {
            if (converterForEmblemTransformation == null)
            {
                throw new ArgumentNullException("converterForEmblemTransformation", "Precondition: converterForEmblemTransformation != null");
            }

            this.converterForEmblemTransformation = converterForEmblemTransformation;
        }

        /// <inheritdoc />
        public EmblemTransformations Convert(ICollection<string> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var result = default(EmblemTransformations);
            foreach (var s in value)
            {
                result |= this.converterForEmblemTransformation.Convert(s);
            }

            return result;
        }
    }
}