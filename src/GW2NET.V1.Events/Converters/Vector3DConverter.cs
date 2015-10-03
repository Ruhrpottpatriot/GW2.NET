// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vector3DConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Vector3D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using System;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Vector3D"/>.</summary>
    public sealed class Vector3DConverter : IConverter<double[], Vector3D>
    {
        /// <inheritdoc />
        public Vector3D Convert(double[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length != 3)
            {
                throw new ArgumentException("Precondition: value.Length == 3", "value");
            }

            return new Vector3D(value[0], value[1], value[2]);
        }
    }
}