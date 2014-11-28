// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForInfusionSlotFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="InfusionSlotFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="InfusionSlotFlags"/>.</summary>
    internal sealed class ConverterForInfusionSlotFlagCollection : IConverter<ICollection<string>, InfusionSlotFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, InfusionSlotFlags> converterForInfusionSlotFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfusionSlotFlagCollection"/> class.</summary>
        internal ConverterForInfusionSlotFlagCollection()
            : this(new ConverterForInfusionSlotFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfusionSlotFlagCollection"/> class.</summary>
        /// <param name="converterForInfusionSlotFlag">The converter for <see cref="InfusionSlotFlags"/>.</param>
        internal ConverterForInfusionSlotFlagCollection(IConverter<string, InfusionSlotFlags> converterForInfusionSlotFlag)
        {
            Contract.Requires(converterForInfusionSlotFlag != null);
            this.converterForInfusionSlotFlag = converterForInfusionSlotFlag;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="InfusionSlotFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public InfusionSlotFlags Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            var result = default(InfusionSlotFlags);
            foreach (var s in value)
            {
                result |= this.converterForInfusionSlotFlag.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForInfusionSlotFlag != null);
        }
    }
}