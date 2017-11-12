﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCombatAttribute.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AttributeDataContract" /> to objects of type <see cref="CombatAttribute" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="AttributeDataContract"/> to objects of type <see cref="CombatAttribute"/>.</summary>
    internal sealed class ConverterForCombatAttribute : IConverter<AttributeDataContract, CombatAttribute>
    {
        /// <summary>Infrastructure. Holds a reference to a collection of type converters.</summary>
        private readonly IDictionary<string, IConverter<AttributeDataContract, CombatAttribute>> typeConverters;

        /// <summary>Initializes a new instance of the <see cref="ConverterForCombatAttribute"/> class.</summary>
        public ConverterForCombatAttribute()
            : this(GetKnownTypeConverters())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForCombatAttribute"/> class.</summary>
        /// <param name="typeConverters">The type converters.</param>
        public ConverterForCombatAttribute(IDictionary<string, IConverter<AttributeDataContract, CombatAttribute>> typeConverters)
        {
            if (typeConverters == null)
            {
                throw new ArgumentNullException("typeConverters", "Precondition: typeConverters != null");
            }

            this.typeConverters = typeConverters;
        }

        /// <summary>Converts the given object of type <see cref="AttributeDataContract"/> to an object of type <see cref="CombatAttribute"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CombatAttribute Convert(AttributeDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            IConverter<AttributeDataContract, CombatAttribute> converter;
            if (this.typeConverters.TryGetValue(value.Attribute, out converter))
            {
                return converter.Convert(value);
            }

            Debug.Assert(false, "Unknown type discriminator: " + value.Attribute);
            return new UnknownModifier();
        }

        /// <summary>Infrastructure. Gets default type converters for all known types.</summary>
        /// <returns>The type converters.</returns>
        private static IDictionary<string, IConverter<AttributeDataContract, CombatAttribute>> GetKnownTypeConverters()
        {
            return new Dictionary<string, IConverter<AttributeDataContract, CombatAttribute>>
            {
                { "BoonDuration", new ConverterForBoonDurationModifier() },
                { "ConditionDamage", new ConverterForConditionDamageModifier() },
                { "ConditionDuration", new ConverterForConditionDurationModifier() },
                { "CritDamage", new ConverterForFerocityModifier() },
                { "Healing", new ConverterForHealingModifier() },
                { "Power", new ConverterForPowerModifier() },
                { "Precision", new ConverterForPrecisionModifier() },
                { "Toughness", new ConverterForToughnessModifier() },
                { "Vitality", new ConverterForVitalityModifier() }
            };
        }
    }
}