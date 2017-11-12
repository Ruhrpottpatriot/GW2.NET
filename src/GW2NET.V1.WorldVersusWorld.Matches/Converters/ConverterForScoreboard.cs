// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForScoreboard.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:int[]" /> to objects of type <see cref="Scoreboard" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.WorldVersusWorld.Matches.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.WorldVersusWorld;

    /// <summary>Converts objects of type <see cref="T:int[]"/> to objects of type <see cref="Scoreboard"/>.</summary>
    internal sealed class ConverterForScoreboard : IConverter<int[], Scoreboard>
    {
        /// <summary>Converts the given object of type <see cref="T:int[]"/> to an object of type <see cref="Scoreboard"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Scoreboard Convert(int[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Length != 3)
            {
                throw new ArgumentException("Precondition: value.Length == 3", "value");
            }

            return new Scoreboard
            {
                Red = value[0],
                Blue = value[1],
                Green = value[2]
            };
        }
    }
}
