// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForInt32.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T" /> to objects of type <see cref="T:int" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Common.Converters
{
    /// <summary>Converts objects of type <see cref="T"/> to objects of type <see cref="T:int"/>.</summary>
    /// <typeparam name="T">The type of values to convert.</typeparam>
    internal sealed class ConverterForInt32<T> : IConverter<T, int>
    {
        /// <summary>Converts the given object of type <see cref="T"/> to an object of type <see cref="T:int"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public int Convert(T value)
        {
            return System.Convert.ToInt32(value);
        }
    }
}