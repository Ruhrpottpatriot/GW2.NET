// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForVector2D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Vector2D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Vector2D"/>.</summary>
    internal sealed class ConverterForVector2D : IConverter<double[], Vector2D>
    {
        /// <summary>Converts the given object of type <see cref="T:double[]"/> to an object of type <see cref="Vector2D"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Vector2D Convert(double[] value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Length == 2);
            return new Vector2D(value[0], value[1]);
        }
    }
}