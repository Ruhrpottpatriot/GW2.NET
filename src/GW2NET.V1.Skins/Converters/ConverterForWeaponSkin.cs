// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWeaponSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDataContract" /> to objects of type <see cref="WeaponSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.Items;
using GW2NET.Skins;
using GW2NET.V1.Skins.Json;

namespace GW2NET.V1.Skins.Converters
{
    /// <summary>Converts objects of type <see cref="SkinDataContract"/> to objects of type <see cref="WeaponSkin"/>.</summary>
    internal sealed class ConverterForWeaponSkin : IConverter<SkinDataContract, WeaponSkin>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, DamageType> converterForDamageType;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<WeaponSkinDataContract, WeaponSkin>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForWeaponSkin"/> class.</summary>
        public ConverterForWeaponSkin()
            : this(GetKnownTypeConverters(), new ConverterForDamageType())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForWeaponSkin"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForDamageType">The converter for <see cref="DamageType"/>.</param>
        public ConverterForWeaponSkin(IDictionary<string, IConverter<WeaponSkinDataContract, WeaponSkin>> typeConverters, IConverter<string, DamageType> converterForDamageType)
        {
            Contract.Requires(typeConverters != null);
            Contract.Requires(converterForDamageType != null);
            this.typeConverters = typeConverters;
            this.converterForDamageType = converterForDamageType;
        }

        /// <summary>Converts the given object of type <see cref="WeaponSkinDataContract"/> to an object of type <see cref="WeaponSkin"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public WeaponSkin Convert(SkinDataContract value)
        {
            Contract.Assume(value != null);
            WeaponSkin weaponSkin;
            var weaponSkinDataContract = value.Weapon;
            IConverter<WeaponSkinDataContract, WeaponSkin> converter;
            if (weaponSkinDataContract != null && this.typeConverters.TryGetValue(weaponSkinDataContract.Type, out converter))
            {
                weaponSkin = converter.Convert(weaponSkinDataContract);
            }
            else
            {
                weaponSkin = new UnknownWeaponSkin();
            }

            if (weaponSkinDataContract == null)
            {
                return weaponSkin;
            }

            var damageType = weaponSkinDataContract.DamageType;
            if (damageType != null)
            {
                weaponSkin.DamageType = this.converterForDamageType.Convert(damageType);
            }

            return weaponSkin;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<WeaponSkinDataContract, WeaponSkin>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<WeaponSkinDataContract, WeaponSkin>>
            {
                { "Axe", new ConverterForObject<AxeSkin>() }, 
                { "Dagger", new ConverterForObject<DaggerSkin>() }, 
                { "Focus", new ConverterForObject<FocusSkin>() }, 
                { "Greatsword", new ConverterForObject<GreatSwordSkin>() }, 
                { "Hammer", new ConverterForObject<HammerSkin>() }, 
                { "Harpoon", new ConverterForObject<HarpoonSkin>() }, 
                { "LongBow", new ConverterForObject<LongBowSkin>() }, 
                { "Mace", new ConverterForObject<MaceSkin>() }, 
                { "Pistol", new ConverterForObject<PistolSkin>() }, 
                { "Rifle", new ConverterForObject<RifleSkin>() }, 
                { "Scepter", new ConverterForObject<ScepterSkin>() }, 
                { "Shield", new ConverterForObject<ShieldSkin>() }, 
                { "ShortBow", new ConverterForObject<ShortBowSkin>() }, 
                { "Speargun", new ConverterForObject<SpearGunSkin>() }, 
                { "Sword", new ConverterForObject<SwordSkin>() }, 
                { "Staff", new ConverterForObject<StaffSkin>() }, 
                { "Torch", new ConverterForObject<TorchSkin>() }, 
                { "Trident", new ConverterForObject<TridentSkin>() }, 
                { "Warhorn", new ConverterForObject<WarHornSkin>() }, 
                { "Toy", new ConverterForObject<ToySkin>() }, 
                { "TwoHandedToy", new ConverterForObject<TwoHandedToySkin>() }, 
                { "SmallBundle", new ConverterForObject<SmallBundleSkin>() }, 
                { "LargeBundle", new ConverterForObject<LargeBundleSkin>() }
            };
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.typeConverters != null);
            Contract.Invariant(this.converterForDamageType != null);
        }
    }
}