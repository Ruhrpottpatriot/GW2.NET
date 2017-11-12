// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBackpack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Backpack" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Backpack"/>.</summary>
    internal sealed class ConverterForBackpack : IConverter<ItemDataContract, Backpack>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Initializes a new instance of the <see cref="ConverterForBackpack"/> class.</summary>
        public ConverterForBackpack()
            : this(new ConverterForCollection<InfusionSlotDataContract, InfusionSlot>(new ConverterForInfusionSlot()), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForBackpack"/> class.</summary>
        /// <param name="converterForInfusionSlotCollection">The converter for <see cref="ICollection{InfusionSlot}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForBackpack(IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            if (converterForInfusionSlotCollection == null)
            {
                throw new ArgumentNullException("converterForInfusionSlotCollection", "Precondition: converterForInfusionSlotCollection != null");
            }

            if (converterForInfixUpgrade == null)
            {
                throw new ArgumentNullException("converterForInfixUpgrade", "Precondition: converterForInfixUpgrade != null");
            }

            this.converterForInfusionSlotCollection = converterForInfusionSlotCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
        }

        /// <inheritdoc />
        public Backpack Convert(ItemDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var backpack = new Backpack();
            int defaultSkinId;
            if (int.TryParse(value.DefaultSkin, out defaultSkinId))
            {
                backpack.DefaultSkinId = defaultSkinId;
            }

            var backpackDataContract = value.Backpack;
            if (backpackDataContract == null)
            {
                return backpack;
            }

            var infusionSlotDataContracts = backpackDataContract.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                backpack.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = backpackDataContract.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                backpack.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            int suffixItemId;
            if (int.TryParse(backpackDataContract.SuffixItemId, out suffixItemId))
            {
                backpack.SuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(backpackDataContract.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                backpack.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return backpack;
        }
    }
}