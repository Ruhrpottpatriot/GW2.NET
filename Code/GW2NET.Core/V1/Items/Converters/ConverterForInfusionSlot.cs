// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForInfusionSlot.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="InfusionSlotDataContract" /> to objects of type <see cref="InfusionSlot" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="InfusionSlotDataContract"/> to objects of type <see cref="InfusionSlot"/>.</summary>
    internal sealed class ConverterForInfusionSlot : IConverter<InfusionSlotDataContract, InfusionSlot>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<string>, InfusionSlotFlags> converterForInfusionSlotFlagCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfusionSlot"/> class.</summary>
        public ConverterForInfusionSlot()
            : this(new ConverterForInfusionSlotFlagCollection())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForInfusionSlot"/> class.</summary>
        /// <param name="converterForInfusionSlotFlagCollection">The converter for <see cref="InfusionSlotFlags"/>.</param>
        public ConverterForInfusionSlot(IConverter<ICollection<string>, InfusionSlotFlags> converterForInfusionSlotFlagCollection)
        {
            Contract.Requires(converterForInfusionSlotFlagCollection != null);
            this.converterForInfusionSlotFlagCollection = converterForInfusionSlotFlagCollection;
        }

        /// <summary>Converts the given object of type <see cref="InfusionSlotDataContract"/> to an object of type <see cref="InfusionSlot"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public InfusionSlot Convert(InfusionSlotDataContract value)
        {
            Contract.Assume(value != null);
            var infusionSlot = new InfusionSlot();
            int itemId;
            if (int.TryParse(value.ItemId, out itemId))
            {
                infusionSlot.ItemId = itemId;
            }

            var flags = value.Flags;
            if (flags != null)
            {
                infusionSlot.Flags = this.converterForInfusionSlotFlagCollection.Convert(flags);
            }

            return infusionSlot;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForInfusionSlotFlagCollection != null);
        }
    }
}