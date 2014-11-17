// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForDynamicEventFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="DynamicEventFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.DynamicEvents;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="DynamicEventFlags"/>.</summary>
    internal sealed class ConverterForDynamicEventFlagCollection : IConverter<ICollection<string>, DynamicEventFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, DynamicEventFlags> converterForDynamicEventFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlagCollection"/> class.</summary>
        public ConverterForDynamicEventFlagCollection()
            : this(new ConverterForDynamicEventFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForDynamicEventFlagCollection"/> class.</summary>
        /// <param name="converterForDynamicEventFlag">The converter for <see cref="DynamicEventFlags"/>.</param>
        public ConverterForDynamicEventFlagCollection(IConverter<string, DynamicEventFlags> converterForDynamicEventFlag)
        {
            Contract.Requires(converterForDynamicEventFlag != null);
            this.converterForDynamicEventFlag = converterForDynamicEventFlag;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="DynamicEventFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public DynamicEventFlags Convert(ICollection<string> value)
        {
            Contract.Assume(value != null);
            var result = default(DynamicEventFlags);
            foreach (var s in value)
            {
                result |= this.converterForDynamicEventFlag.Convert(s);
            }

            return result;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForDynamicEventFlag != null);
        }
    }
}