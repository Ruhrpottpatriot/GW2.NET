// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWeapon.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ItemDataContract" /> to objects of type <see cref="Weapon" />.
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
    /// <summary>Converts objects of type <see cref="ItemDataContract"/> to objects of type <see cref="Weapon"/>.</summary>
    internal sealed class ConverterForWeapon : IConverter<ItemDataContract, Weapon>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, DamageType> converterForDamageType;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<WeaponDataContract, Weapon>> typeConverters;

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
        public ConverterForWeapon(IDictionary<string, IConverter<WeaponDataContract, Weapon>> typeConverters, IConverter<string, DamageType> converterForDamageType, IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
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

        /// <summary>Converts the given object of type <see cref="ItemDataContract"/> to an object of type <see cref="Weapon"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Weapon Convert(ItemDataContract value)
        {
            Contract.Assume(value != null);
            Weapon weapon;
            var weaponDataContract = value.Weapon;

            IConverter<WeaponDataContract, Weapon> converter;
            if (weaponDataContract != null && this.typeConverters.TryGetValue(weaponDataContract.Type, out converter))
            {
                weapon = converter.Convert(weaponDataContract);
            }
            else
            {
                weapon = new UnknownWeapon();
            }

            int defaultSkinId;
            if (int.TryParse(value.DefaultSkin, out defaultSkinId))
            {
                weapon.DefaultSkinId = defaultSkinId;
            }

            if (weaponDataContract == null)
            {
                return weapon;
            }

            weapon.DamageType = this.converterForDamageType.Convert(weaponDataContract.DamageType);

            int minimumPower;
            if (int.TryParse(weaponDataContract.MinimumPower, out minimumPower))
            {
                weapon.MinimumPower = minimumPower;
            }

            int maximumPower;
            if (int.TryParse(weaponDataContract.MaximumPower, out maximumPower))
            {
                weapon.MaximumPower = maximumPower;
            }

            int defense;
            if (int.TryParse(weaponDataContract.Defense, out defense))
            {
                weapon.Defense = defense;
            }

            var infusionSlotDataContracts = weaponDataContract.InfusionSlots;
            if (infusionSlotDataContracts != null)
            {
                weapon.InfusionSlots = this.converterForInfusionSlotCollection.Convert(infusionSlotDataContracts);
            }

            var infixUpgradeDataContract = weaponDataContract.InfixUpgrade;
            if (infixUpgradeDataContract != null)
            {
                weapon.InfixUpgrade = this.converterForInfixUpgrade.Convert(infixUpgradeDataContract);
            }

            int suffixItemId;
            if (int.TryParse(weaponDataContract.SuffixItemId, out suffixItemId))
            {
                weapon.SuffixItemId = suffixItemId;
            }

            int secondarySuffixItemId;
            if (int.TryParse(weaponDataContract.SecondarySuffixItemId, out secondarySuffixItemId))
            {
                weapon.SecondarySuffixItemId = secondarySuffixItemId;
            }

            return weapon;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<WeaponDataContract, Weapon>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<WeaponDataContract, Weapon>>
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