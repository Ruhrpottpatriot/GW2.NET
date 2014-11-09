// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForVector3D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Vector3D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.DynamicEvents.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Vector3D"/>.</summary>
    internal sealed class ConverterForVector3D : IConverter<double[], Vector3D>
    {
        /// <summary>Converts the given object of type <see cref="T:double[]"/> to an object of type <see cref="Vector3D"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Vector3D Convert(double[] value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Length == 3);
            return new Vector3D(value[0], value[1], value[2]);
        }
    }
}