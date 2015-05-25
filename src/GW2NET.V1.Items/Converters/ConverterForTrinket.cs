// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForTrinket.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Trinket" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Trinket"/>.</summary>
    internal sealed class ConverterForTrinket : IConverter<ItemDataContract, Trinket>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<TrinketDataContract, Trinket>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForTrinket"/> class.</summary>
        public ConverterForTrinket()
            : this(GetKnownTypeConverters(), new ConverterForCollection<InfusionSlotDataContract, InfusionSlot>(new ConverterForInfusionSlot()), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForTrinket"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForInfusionSlotCollection">The converter for <see cref="ICollection{InfusionSlot}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForTrinket(IDictionary<string, IConverter<TrinketDataContract, Trinket>> typeConverters, IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            Contract.Requires(converterForInfusionSlotCollection != null);
            Contract.Requires(converterForInfixUpgrade != null);
            this.converterForInfusionSlotCollection = converterForInfusionSlotCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="ItemDataContract"/> to an object of type <see cref="Trinket"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Trinket Convert(ItemDataContract value)
        {
            Contract.Assume(value != null);
            var trinketDataContract = value.Trinket;
            if (trinketDataContract == null)
            {
                return new UnknownTrinket();
            }

            Trinket trinket;
            IConverter<TrinketDataContract, Trinket> converter;
            if (this.typeConverters.TryGetValue(trinketDataContract.Type, out converter))
            {
                trinket = converter.Convert(trinketDataContract);
            }
            else
            {
                trinket = new UnknownTrinket();
            }

            var infusionSlotDataContracts = trinketDataContract.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                trinket.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = trinketDataContract.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                trinket.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            int suffixItemId;
            if (int.TryParse(trinketDataContract.SuffixItemId, out suffixItemId))
            {
                trinket.SuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(trinketDataContract.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                trinket.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return trinket;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<TrinketDataContract, Trinket>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<TrinketDataContract, Trinket>>
            {
                { "Amulet", new ConverterForAmulet() }, 
                { "Accessory", new ConverterForAccessory() }, 
                { "Ring", new ConverterForRing() }, 
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.converterForInfusionSlotCollection != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
        }
    }
}