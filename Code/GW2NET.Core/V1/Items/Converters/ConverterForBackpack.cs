// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForBackpack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Backpack" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items.Backpacks;
    using GW2NET.Items.Common;
    using GW2NET.V1.Items.Json;

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
            Contract.Requires(converterForInfusionSlotCollection != null);
            Contract.Requires(converterForInfixUpgrade != null);
            this.converterForInfusionSlotCollection = converterForInfusionSlotCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
        }

        /// <summary>Converts the given object of type <see cref="ItemDataContract"/> to an object of type <see cref="Backpack"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Backpack Convert(ItemDataContract value)
        {
            Contract.Assume(value != null);
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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForInfusionSlotCollection != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
        }
    }
}