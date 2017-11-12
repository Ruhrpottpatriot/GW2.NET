// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="WeaponSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V2.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Items;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="WeaponSkin"/>.</summary>
    internal sealed class WeaponConverter : IConverter<DetailsDataContract, WeaponSkin>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<DetailsDataContract, WeaponSkin>> typeConverters;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, DamageType> damageClassConverter;

        /// <summary>Initializes a new instance of the <see cref="WeaponConverter"/> class.</summary>
        public WeaponConverter()
            : this(GetKnownTypeConverters(), new DamageClassConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WeaponConverter"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForDamageType">The converter for <see cref="DamageType"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="typeConverters"/> or <paramref name="converterForDamageType"/> is a null reference.</exception>
        public WeaponConverter(IDictionary<string, IConverter<DetailsDataContract, WeaponSkin>> typeConverters, IConverter<string, DamageType> converterForDamageType)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            if (converterForDamageType == null)
            {
                throw new ArgumentNullException("converterForDamageType", "Precondition: converterForDamageType != null");
            }

            this.typeConverters = typeConverters;
            this.damageClassConverter = converterForDamageType;
        }

        /// <inheritdoc />
        [SuppressMessage("ReSharper", "PossibleNullReferenceException", Justification = "Contracts make sure taht 'value' is not null.")]
        public WeaponSkin Convert(DetailsDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            IConverter<DetailsDataContract, WeaponSkin> converter;

            WeaponSkin skin;
            if (this.typeConverters.TryGetValue(value.Type, out converter))
            {
                skin = converter.Convert(value);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + value.Type);
                skin = new UnknownWeaponSkin();
            }

            if (skin == null)
            {
                return null;
            }

            var damageClass = value.DamageClass;
            if (damageClass != null)
            {
                skin.DamageType = this.damageClassConverter.Convert(damageClass);
            }

            return skin;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<DetailsDataContract, WeaponSkin>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<DetailsDataContract, WeaponSkin>>
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
    }
}