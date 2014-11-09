// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWeapon.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Weapon" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Weapon"/>.</summary>
    internal sealed class ConverterForWeapon : IConverter<DetailsDataContract, Weapon>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, DamageType> converterForDamageType;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, Weapon>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForWeapon"/> class.</summary>
        public ConverterForWeapon()
            : this(GetKnownTypeConverters(), new ConverterForDamageType(), new ConverterForCollection<InfusionSlotDataContract, InfusionSlot>(new ConverterForInfusionSlot()), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForWeapon"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForDamageType">The converter for <see cref="DamageType"/>.</param>
        /// <param name="converterForInfusionSlotCollection">The converter for <see cref="ICollection{InfusionSlot}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForWeapon(IDictionary<string, IConverter<DetailsDataContract, Weapon>> typeConverters, IConverter<string, DamageType> converterForDamageType, IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            Contract.Requires(typeConverters != null);
            Contract.Requires(converterForDamageType != null);
            Contract.Requires(converterForInfixUpgrade != null);
            Contract.Requires(converterForInfusionSlotCollection != null);
            this.converterForDamageType = converterForDamageType;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
            this.typeConverters = typeConverters;
            this.converterForInfusionSlotCollection = converterForInfusionSlotCollection;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Weapon"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Weapon Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            Weapon weapon;
            IConverter<DetailsDataContract, Weapon> converter;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                weapon = converter.Convert(value);
            }
            else
            {
                weapon = new UnknownWeapon();
            }

            weapon.DamageType = this.converterForDamageType.Convert(value.DamageType);

            weapon.MinimumPower = value.MinimumPower.GetValueOrDefault();
            weapon.MaximumPower = value.MaximumPower.GetValueOrDefault();
            weapon.Defense = value.Defense.GetValueOrDefault();

            var infusionSlotDataContracts = value.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                weapon.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = value.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                weapon.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            weapon.SuffixItemId = value.SuffixItemId;

            int secondarySuffixItemId;
            if (int.TryParse(value.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                weapon.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return weapon;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, Weapon>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, Weapon>>
            {
                { "Axe", new ConverterForAxe() }, 
                { "Dagger", new ConverterForDagger() }, 
                { "Focus", new ConverterForFocus() }, 
                { "Greatsword", new ConverterForGreatSword() }, 
                { "Hammer", new ConverterForHammer() }, 
                { "Harpoon", new ConverterForHarpoon() }, 
                { "LongBow", new ConverterForLongBow() }, 
                { "Mace", new ConverterForMace() }, 
                { "Pistol", new ConverterForPistol() }, 
                { "Rifle", new ConverterForRifle() }, 
                { "Scepter", new ConverterForScepter() }, 
                { "Shield", new ConverterForShield() }, 
                { "ShortBow", new ConverterForShortBow() }, 
                { "Speargun", new ConverterForSpearGun() }, 
                { "Sword", new ConverterForSword() }, 
                { "Staff", new ConverterForStaff() }, 
                { "Torch", new ConverterForTorch() }, 
                { "Trident", new ConverterForTrident() }, 
                { "Warhorn", new ConverterForWarHorn() }, 
                { "Toy", new ConverterForToy() }, 
                { "TwoHandedToy", new ConverterForTwoHandedToy() }, 
                { "SmallBundle", new ConverterForSmallBundle() }, 
                { "LargeBundle", new ConverterForLargeBundle() }, 
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.converterForDamageType != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
            Contract.Invariant(this.converterForInfusionSlotCollection != null);
        }
    }
}