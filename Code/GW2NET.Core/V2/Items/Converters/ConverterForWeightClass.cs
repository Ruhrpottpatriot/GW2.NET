// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForWeightClass.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="WeightClass" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items.Armors;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="WeightClass"/>.</summary>
    internal sealed class ConverterForWeightClass : IConverter<string, WeightClass>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="WeightClass"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public WeightClass Convert(string value)
        {
            WeightClass result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(WeightClass);
        }
    }
}