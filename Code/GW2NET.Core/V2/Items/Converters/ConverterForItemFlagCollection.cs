// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="ItemFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="ItemFlags"/>.</summary>
    internal sealed class ConverterForItemFlagCollection : IConverter<ICollection<string>, ItemFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, ItemFlags> converterForItemFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemFlagCollection"/> class.</summary>
        internal ConverterForItemFlagCollection()
            : this(new ConverterForItemFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemFlagCollection"/> class.</summary>
        /// <param name="converterForItemFlag">The converter for <see cref="ItemFlags"/>.</param>
        internal ConverterForItemFlagCollection(IConverter<string, ItemFlags> converterForItemFlag)
        {
            Contract.Requires(converterForItemFlag != null);
            this.converterForItemFlag = converterForItemFlag;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="ItemFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ItemFlags Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            var result = default(ItemFlags);
            foreach (var s in value)
            {
                result |= this.converterForItemFlag.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForItemFlag != null);
        }
    }
}