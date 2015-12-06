// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForArmorSkin.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SkinDataContract" /> to objects of type <see cref="ArmorSkin" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Diagnostics;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.Items;
using GW2NET.Skins;
using GW2NET.V1.Skins.Json;

namespace GW2NET.V1.Skins.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="SkinDataContract"/> to objects of type <see cref="ArmorSkin"/>.</summary>
    internal sealed class ConverterForArmorSkin : IConverter<SkinDataContract, ArmorSkin>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, WeightClass> converterForWeightClass;

        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<ArmorSkinDataContract, ArmorSkin>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForArmorSkin"/> class.</summary>
        public ConverterForArmorSkin()
            : this(GetKnownTypeConverters(), new ConverterForWeightClass())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForArmorSkin"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        /// <param name="converterForWeightClass">The converter for <see cref="WeightClass"/>.</param>
        public ConverterForArmorSkin(IDictionary<string, IConverter<ArmorSkinDataContract, ArmorSkin>> typeConverters, IConverter<string, WeightClass> converterForWeightClass)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            if (converterForWeightClass == null)
            {
                throw new ArgumentNullException("converterForWeightClass", "Precondition: converterForWeightClass != null");
            }

            this.converterForWeightClass = converterForWeightClass;
            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="SkinDataContract"/> to an object of type <see cref="ArmorSkin"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ArmorSkin Convert(SkinDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            ArmorSkin armorSkin;
            var armorSkinDataContract = value.Armor;
            if (armorSkinDataContract == null)
            {
                return new UnknownArmorSkin();
            }

            IConverter<ArmorSkinDataContract, ArmorSkin> converter;
            if (this.typeConverters.TryGetValue(armorSkinDataContract.Type, out converter))
            {
                armorSkin = converter.Convert(armorSkinDataContract);
            }
            else
            {
                Debug.Assert(false, "Unknown type discriminator: " + armorSkinDataContract.Type);
                armorSkin = new UnknownArmorSkin();
            }

            var weightClass = armorSkinDataContract.WeightClass;
            if (weightClass != null)
            {
                armorSkin.WeightClass = this.converterForWeightClass.Convert(weightClass);
            }

            return armorSkin;
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<ArmorSkinDataContract, ArmorSkin>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<ArmorSkinDataContract, ArmorSkin>>
            {
                { "Boots", new ConverterForObject<BootsSkin>() },
                { "Coat", new ConverterForObject<CoatSkin>() },
                { "Helm", new ConverterForObject<HelmSkin>() },
                { "Shoulders", new ConverterForObject<ShouldersSkin>() },
                { "Gloves", new ConverterForObject<GlovesSkin>() },
                { "Leggings", new ConverterForObject<LeggingsSkin>() },
                { "HelmAquatic", new ConverterForObject<HelmAquaticSkin>() },
            };
        }
    }
}