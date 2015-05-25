// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForVector3D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Vector3D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;

namespace GW2NET.V1.Events.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Vector3D"/>.</summary>
    internal sealed class ConverterForVector3D : IConverter<double[], Vector3D>
    {
        /// <inheritdoc />
        public Vector3D Convert(double[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Length != 3)
            {
                throw new ArgumentException("Precondition: value.Length == 3", "value");
            }

            return new Vector3D(value[0], value[1], value[2]);
        }
    }
}