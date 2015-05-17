// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSize2D.cs" company="GW2.NET Coding Team">
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
    internal sealed class ConverterForSize2D : IConverter<double[], Size2D>
    {
        /// <inheritdoc />
        public Size2D Convert(double[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new Size2D(value[0], value[1]);
        }
    }
}