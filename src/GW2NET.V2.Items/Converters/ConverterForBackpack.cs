// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBackpack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Backpack" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Backpack"/>.</summary>
    internal sealed class ConverterForBackpack : IConverter<DetailsDataContract, Backpack>
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

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Backpack"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Backpack Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var backpack = new Backpack();

            var infusionSlotDataContracts = value.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                backpack.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = value.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                backpack.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            backpack.SuffixItemId = value.SuffixItemId;

            int secondarySuffixItemId;
            if (int.TryParse(value.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                backpack.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return backpack;
        }
    }
}