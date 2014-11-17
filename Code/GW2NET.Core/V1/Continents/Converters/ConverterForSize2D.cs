// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSize2D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Size2D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Continents
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Size2D"/>.</summary>
    internal sealed class ConverterForSize2D : IConverter<double[], Size2D>
    {
        /// <summary>Converts the given object of type <see cref="T:double[]"/> to an object of type <see cref="Size2D"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Size2D Convert(double[] value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Length == 2);
            return new Size2D(value[0], value[1]);
        }
    }
}