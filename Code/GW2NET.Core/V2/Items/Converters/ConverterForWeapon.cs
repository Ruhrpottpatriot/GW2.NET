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
        private readonly IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, WeaponDamageType> converterForWeaponDamageType;

        /// <summary>Initializes a new instance of the <see cref="ConverterForWeapon"/> class.</summary>
        public ConverterForWeapon()
            : this(new ConverterForWeaponDamageType(), new ConverterForCollection<InfusionSlotDataContract, InfusionSlot>(new ConverterForInfusionSlot()), new ConverterForInfixUpgrade())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForWeapon"/> class.</summary>
        /// <param name="converterForWeaponDamageType">The converter for <see cref="WeaponDamageType"/>.</param>
        /// <param name="converterForInfusionSlotCollection">The converter for <see cref="ICollection{InfusionSlot}"/>.</param>
        /// <param name="converterForInfixUpgrade">The converter for <see cref="InfixUpgrade"/>.</param>
        public ConverterForWeapon(IConverter<string, WeaponDamageType> converterForWeaponDamageType, IConverter<ICollection<InfusionSlotDataContract>, ICollection<InfusionSlot>> converterForInfusionSlotCollection, IConverter<InfixUpgradeDataContract, InfixUpgrade> converterForInfixUpgrade)
        {
            Contract.Requires(converterForWeaponDamageType != null);
            Contract.Requires(converterForInfixUpgrade != null);
            Contract.Requires(converterForInfusionSlotCollection != null);
            this.converterForWeaponDamageType = converterForWeaponDamageType;
            this.converterForInfixUpgrade = converterForInfixUpgrade;
            this.converterForInfusionSlotCollection = converterForInfusionSlotCollection;
        }

        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Weapon"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Weapon Convert(DetailsDataContract value)
        {
            Contract.Assume(value != null);
            Weapon weapon;
            switch (value.Type)
            {
                case "Axe":
                    weapon = new Axe();
                    break;
                case "Dagger":
                    weapon = new Dagger();
                    break;
                case "Focus":
                    weapon = new Focus();
                    break;
                case "Greatsword":
                    weapon = new GreatSword();
                    break;
                case "Hammer":
                    weapon = new Hammer();
                    break;
                case "Harpoon":
                    weapon = new Harpoon();
                    break;
                case "LongBow":
                    weapon = new LongBow();
                    break;
                case "Mace":
                    weapon = new Mace();
                    break;
                case "Pistol":
                    weapon = new Pistol();
                    break;
                case "Rifle":
                    weapon = new Rifle();
                    break;
                case "Scepter":
                    weapon = new Scepter();
                    break;
                case "Shield":
                    weapon = new Shield();
                    break;
                case "ShortBow":
                    weapon = new ShortBow();
                    break;
                case "Speargun":
                    weapon = new SpearGun();
                    break;
                case "Sword":
                    weapon = new Sword();
                    break;
                case "Staff":
                    weapon = new Staff();
                    break;
                case "Torch":
                    weapon = new Torch();
                    break;
                case "Trident":
                    weapon = new Trident();
                    break;
                case "Warhorn":
                    weapon = new WarHorn();
                    break;
                case "Toy":
                    weapon = new Toy();
                    break;
                case "TwoHandedToy":
                    weapon = new TwoHandedToy();
                    break;
                case "SmallBundle":
                    weapon = new SmallBundle();
                    break;
                case "LargeBundle":
                    weapon = new LargeBundle();
                    break;
                default:
                    weapon = new UnknownWeapon();
                    break;
            }

            weapon.DamageType = this.converterForWeaponDamageType.Convert(value.DamageType);

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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForWeaponDamageType != null);
            Contract.Invariant(this.converterForInfixUpgrade != null);
            Contract.Invariant(this.converterForInfusionSlotCollection != null);
        }
    }
}