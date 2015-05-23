// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTrinket.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Trinket" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Trinket"/>.</summary>
    internal sealed class ConverterForTrinket : IConverter<DetailsDataContract, Trinket>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Trinket>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForTrinket"/> class.</summary>
        public ConverterForTrinket()
            : this(GetKnownTypeConverters(), new ConverterForCollection<InfusionSlotDataContract, InfusionSlot>(new ConverterForInfusionSlot()), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForTrinket"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForInfusionSlotCollection">The converter for <see cref="ICollection{InfusionSlot}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForTrinket(IDictionary<string, IConverter<DetailsDataContract, Trinket>> typeConverters, IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
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
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Trinket"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Trinket Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            Trinket trinket;
            IConverter<DetailsDataContract, Trinket> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                trinket = converter.Convert(value);
            }
            else
            {
                trinket = new UnknownTrinket();
            }

            var infusionSlotDataContracts = value.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                trinket.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = value.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                trinket.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            trinket.SuffixItemId = value.SuffixItemId;

            int secondarySuffixItemId;
            if (int.TryParse(value.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                trinket.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return trinket;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Trinket>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Trinket>>
            {
                { "Amulet", new ConverterForAmulet() }, 
                { "Accessory", new ConverterForAccessory() }, 
                { "Ring", new ConverterForRing() }, 
            };
        }
    }
}