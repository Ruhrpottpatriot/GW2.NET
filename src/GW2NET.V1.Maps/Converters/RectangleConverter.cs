// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RectangleConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[][]" /> to objects of type <see cref="Rectangle" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Maps.Converters
{
    using System;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[][]"/> to objects of type <see cref="Rectangle"/>.</summary>
    public sealed class RectangleConverter : IConverter<double[][], Rectangle>
    {
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="RectangleConverter"/> class.</summary>
        /// <param name="vector2DConverter">The converter for <see cref="Vector2D"/>.</param>
        public RectangleConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter");
            }

            this.vector2DConverter = vector2DConverter;
        }

        /// <inheritdoc />
        public Rectangle Convert(double[][] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("Precondition value.Length == 2", "value");
            }

            var nw = default(Vector2D);
            var values1 = value[0];
            if (values1 != null && values1.Length == 2)
            {
                nw = this.vector2DConverter.Convert(values1, state);
            }

            var se = default(Vector2D);
            var values2 = value[1];
            if (values2 != null && values2.Length == 2)
            {
                se = this.vector2DConverter.Convert(values2, state);
            }

            return new Rectangle(nw, se);
        }
    }
}