// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForGameTypeCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="GameTypes" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="GameTypes"/>.</summary>
    internal sealed class ConverterForGameTypeCollection : IConverter<ICollection<string>, GameTypes>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, GameTypes> converterForGameType;

        /// <summary>Initializes a new instance of the <see cref="ConverterForGameTypeCollection"/> class.</summary>
        internal ConverterForGameTypeCollection()
            : this(new ConverterForGameType())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForGameTypeCollection"/> class.</summary>
        /// <param name="converterForGameType">The converter for <see cref="GameTypes"/>.</param>
        internal ConverterForGameTypeCollection(IConverter<string, GameTypes> converterForGameType)
        {
            Contract.Requires(converterForGameType != null);
            this.converterForGameType = converterForGameType;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="GameTypes"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public GameTypes Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            var result = default(GameTypes);
            foreach (var s in value)
            {
                result |= this.converterForGameType.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForGameType != null);
        }
    }
}