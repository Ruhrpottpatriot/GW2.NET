// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForEmblemTransformations.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="EmblemTransformations" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Guilds
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Guilds;

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
        internal ConverterForEmblemTransformations(IConverter<string, EmblemTransformations> converterForEmblemTransformation)
        {
            Contract.Requires(converterForEmblemTransformation != null);
            this.converterForEmblemTransformation = converterForEmblemTransformation;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="EmblemTransformations"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public EmblemTransformations Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            var result = default(EmblemTransformations);
            foreach (var s in value)
            {
                result |= this.converterForEmblemTransformation.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForEmblemTransformation != null);
        }
    }
}