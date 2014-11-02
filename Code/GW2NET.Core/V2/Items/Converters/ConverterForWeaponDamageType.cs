// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWeaponDamageType.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="WeaponDamageType" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Entities.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="WeaponDamageType"/>.</summary>
    internal sealed class ConverterForWeaponDamageType : IConverter<string, WeaponDamageType>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="WeaponDamageType"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public WeaponDamageType Convert(string value)
        {
            WeaponDamageType result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(WeaponDamageType);
        }
    }
}