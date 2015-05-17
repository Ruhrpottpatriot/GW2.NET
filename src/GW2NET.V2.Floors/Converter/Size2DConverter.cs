// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Size2DConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Size2D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Size2D"/>.</summary>
    internal sealed class Size2DConverter : IConverter<double[], Size2D>
    {
        /// <inheritdoc />
        public Size2D Convert(double[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Length == 2)
            {
                throw new ArgumentException("Precondition: value == 2", "value");
            }

            return new Size2D(value[0], value[1]);
        }
    }
}