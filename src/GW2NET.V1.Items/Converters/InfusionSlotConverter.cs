// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InfusionSlotConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="InfusionSlotDTO" /> to objects of type <see cref="InfusionSlot" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="InfusionSlotDTO"/> to objects of type <see cref="InfusionSlot"/>.</summary>
    public sealed class InfusionSlotConverter : IConverter<InfusionSlotDTO, InfusionSlot>
    {
        private readonly IConverter<ICollection<string>, InfusionSlotFlags> infusionSlotFlagCollectionConverter;

        /// <summary>Initializes a new instance of the <see cref="InfusionSlotConverter"/> class.</summary>
        /// <param name="infusionSlotFlagCollectionConverter"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public InfusionSlotConverter(IConverter<ICollection<string>, InfusionSlotFlags> infusionSlotFlagCollectionConverter)
        {
            if (infusionSlotFlagCollectionConverter == null)
            {
                throw new ArgumentNullException("infusionSlotFlagCollectionConverter");
            }

            this.infusionSlotFlagCollectionConverter = infusionSlotFlagCollectionConverter;
        }

        /// <inheritdoc />
        public InfusionSlot Convert(InfusionSlotDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
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
                infusionSlot.Flags = this.infusionSlotFlagCollectionConverter.Convert(flags, value);
            }

            return infusionSlot;
        }
    }
}