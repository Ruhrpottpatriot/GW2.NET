// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type  to objects of type .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors
{
    using System.Diagnostics.Contracts;

    using GW2NET.Colors;
    using GW2NET.Common;

    /// <summary>Converts objects of type <see cref="T:int[]"/> to objects of type <see cref="Color"/>.</summary>
    internal sealed class ColorConverter : IConverter<int[], Color>
    {
        /// <summary>Converts the given object of type <see cref="T:int[]"/> to an object of type <see cref="Color"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Color Convert(int[] value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Length == 3);
            return new Color(value[0], value[1], value[2]);
        }
    }
}