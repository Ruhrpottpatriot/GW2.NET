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
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
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
            if (converterForInfusionSlotFlagCollection == null)
            {
                throw new ArgumentNullException("converterForInfusionSlotFlagCollection", "Precondition: converterForInfusionSlotFlagCollection != null");
            }

            this.converterForInfusionSlotFlagCollection = converterForInfusionSlotFlagCollection;
        }

        /// <inheritdoc />
        public InfusionSlot Convert(InfusionSlotDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var infusionSlot = new InfusionSlot();
            int itemId;
            if (int.TryParse(value.ItemId, out itemId))
            {
                infusionSlot.ItemId = itemId;
            }

            var flags = value.Flags;
            if (flags != null)
            {
                infusionSlot.Flags = this.converterForInfusionSlotFlagCollection.Convert(flags, state);
            }

            return infusionSlot;
        }
    }
}