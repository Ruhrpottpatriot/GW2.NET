// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Size2DConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Size2D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;

namespace GW2NET.V1.Continents.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Size2D"/>.</summary>
    public sealed class Size2DConverter : IConverter<double[], Size2D>
    {
        /// <inheritdoc />
        public Size2D Convert(double[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("Precondition: value.Length == 2", "value");
            }

            return new Size2D(value[0], value[1]);
        }
    }
}