// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForInfusionSlot.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="InfusionSlotDataContract" /> to objects of type <see cref="InfusionSlot" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

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
            if (converterForInfusionSlotFlagCollection == null)
            {
                throw new ArgumentNullException("converterForInfusionSlotFlagCollection", "Precondition: converterForInfusionSlotFlagCollection != null");
            }

            this.converterForInfusionSlotFlagCollection = converterForInfusionSlotFlagCollection;
        }

        /// <summary>Converts the given object of type <see cref="InfusionSlotDataContract"/> to an object of type <see cref="InfusionSlot"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public InfusionSlot Convert(InfusionSlotDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var infusionSlot = new InfusionSlot
            {
                ItemId = value.ItemId
            };
            var flags = value.Flags;
            if (flags != null)
            {
                infusionSlot.Flags = this.converterForInfusionSlotFlagCollection.Convert(flags);
            }

            return infusionSlot;
        }
    }
}