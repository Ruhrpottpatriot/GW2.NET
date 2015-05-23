// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForHealingModifier.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AttributeDataContract" /> to objects of type <see cref="HealingModifier" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="AttributeDataContract"/> to objects of type <see cref="HealingModifier"/>.</summary>
    internal sealed class ConverterForHealingModifier : IConverter<AttributeDataContract, HealingModifier>
    {
        /// <summary>Converts the given object of type <see cref="AttributeDataContract"/> to an object of type <see cref="HealingModifier"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public HealingModifier Convert(AttributeDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new HealingModifier
            {
                Modifier = value.Modifier
            };
        }
    }
}