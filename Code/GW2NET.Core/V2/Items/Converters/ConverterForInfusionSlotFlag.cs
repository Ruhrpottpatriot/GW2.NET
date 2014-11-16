// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForInfusionSlotFlag.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="InfusionSlotFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items.Common;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="InfusionSlotFlags"/>.</summary>
    internal sealed class ConverterForInfusionSlotFlag : IConverter<string, InfusionSlotFlags>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="InfusionSlotFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public InfusionSlotFlags Convert(string value)
        {
            InfusionSlotFlags result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(InfusionSlotFlags);
        }
    }
}