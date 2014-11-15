// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForArmor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Armor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Entities.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Armor"/>.</summary>
    internal sealed class ConverterForArmor : IConverter<ItemDataContract, Armor>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, WeightClass> converterForWeightClass;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<ArmorDataContract, Armor>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForArmor"/> class.</summary>
        public ConverterForArmor()
            : this(GetKnownTypeConverters(), new ConverterForWeightClass(), new ConverterForCollection<InfusionSlotDataContract, InfusionSlot>(new ConverterForInfusionSlot()), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForArmor"/> class.</summary>
        /// <param name="typeConverters">The type Converters.</param>
        /// <param name="converterForWeightClass">The converter for <see cref="WeightClass"/>.</param>
        /// <param name="converterForInfusionSlotCollection">The converter for <see cref="ICollection{InfusionSlot}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForArmor(IDictionary<string, IConverter<ArmorDataContract, Armor>> typeConverters, IConverter<string, WeightClass> converterForWeightClass, IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            Contract.Requires(converterForWeightClass != null);
            Contract.Requires(converterForInfusionSlotCollection != null);
            Contract.Requires(converterForInfixUpgrade != null);
            this.converterForWeightClass = converterForWeightClass;
            this.converterForInfusionSlotCollection = converterForInfusionSlotCollection;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="ItemDataContract"/> to an object of type <see cref="Armor"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Armor Convert(ItemDataContract value)
        {
            Contract.Assume(value != null);
            Armor armor;
            var armorDataContract = value.Armor;
            IConverter<ArmorDataContract, Armor> converter;
            if (armorDataContract != null && this.typeConverters.TryGetValue(armorDataContract.Type, out converter))
            {
                armor = converter.Convert(armorDataContract);
            }
            else
            {
                armor = new UnknownArmor();
            }

            int defaultSkinId;
            if (int.TryParse(value.DefaultSkin, out defaultSkinId))
            {
                armor.DefaultSkinId = defaultSkinId;
            }

            if (armorDataContract == null)
            {
                return armor;
            }

            armor.WeightClass = this.converterForWeightClass.Convert(armorDataContract.WeightClass);
            int defense;
            if (int.TryParse(armorDataContract.Defense, out defense))
            {
                armor.Defense = defense;
            }

            var infusionSlotDataContracts = armorDataContract.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                armor.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = armorDataContract.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                armor.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            int suffixItemId;
            if (int.TryParse(armorDataContract.SuffixItemId, out suffixItemId))
            {
                armor.SecondarySuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(armorDataContract.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                armor.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return armor;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<ArmorDataContract, Armor>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<ArmorDataContract, Armor>>
            {
                { "Boots", new ConverterForBoots() }, 
                { "Coat", new ConverterForCoat() }, 
                { "Helm", new ConverterForHelm() }, 
                { "Shoulders", new ConverterForShoulders() }, 
                { "Gloves", new ConverterForGloves() }, 
                { "Leggings", new ConverterForLeggings() }, 
                { "HelmAquatic", new ConverterForHelmAquatic() }, 
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForWeightClass != null);
            Contract.Invariant(this.converterForInfusionSlotCollection != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
        }
    }
}