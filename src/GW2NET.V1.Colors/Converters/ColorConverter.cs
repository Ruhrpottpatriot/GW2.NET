// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:int[]" /> to objects of type <see cref="Color" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Colors;
using GW2NET.Common;

namespace GW2NET.V1.Colors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:int[]"/> to objects of type <see cref="Color"/>.</summary>
    public sealed class ColorConverter : IConverter<int[], Color>
    {
        /// <inheritdoc />
        public Color Convert(int[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length != 3)
            {
                throw new ArgumentException("Precondition: value.Length == 3", "value");
            }

            return new Color(value[0], value[1], value[2]);
        }
    }
}