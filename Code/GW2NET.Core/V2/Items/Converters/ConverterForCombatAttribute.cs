// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCombatAttribute.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AttributeDataContract" /> to objects of type <see cref="CombatAttribute" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Items;
    using GW2NET.V2.Items.Json;

    /// <summary>Converts objects of type <see cref="AttributeDataContract"/> to objects of type <see cref="CombatAttribute"/>.</summary>
    internal sealed class ConverterForCombatAttribute : IConverter<AttributeDataContract, CombatAttribute>
    {
        /// <summary>Converts the given object of type <see cref="AttributeDataContract"/> to an object of type <see cref="CombatAttribute"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public CombatAttribute Convert(AttributeDataContract value)
        {
            Contract.Assume(value != null);
            switch (value.Attribute)
            {
                case "ConditionDamage":
                    return new ConditionDamageModifier { Modifier = value.Modifier };
                case "CritDamage":
                    return new FerocityModifier { Modifier = value.Modifier };
                case "Healing":
                    return new HealingModifier { Modifier = value.Modifier };
                case "Power":
                    return new PowerModifier { Modifier = value.Modifier };
                case "Precision":
                    return new PrecisionModifier { Modifier = value.Modifier };
                case "Toughness":
                    return new ToughnessModifier { Modifier = value.Modifier };
                case "Vitality":
                    return new VitalityModifier { Modifier = value.Modifier };
                default:
                    return new UnknownModifier { Modifier = value.Modifier };
            }
        }
    }
}