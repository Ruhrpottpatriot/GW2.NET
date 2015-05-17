// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RectangleConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[][]" /> to objects of type <see cref="Rectangle" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[][]"/> to objects of type <see cref="Rectangle"/>.</summary>
    internal sealed class RectangleConverter : IConverter<double[][], Rectangle>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="RectangleConverter"/> class.</summary>
        internal RectangleConverter()
            : this(new Vector2DConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RectangleConverter"/> class.</summary>
        /// <param name="vector2DConverter">The converter for <see cref="RectangleConverter"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="vector2DConverter"/> is a null reference.</exception>
        internal RectangleConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter", "Precondition: vector2DConverter != null");
            }

            this.vector2DConverter = vector2DConverter;
        }

        /// <summary>Converts the given object of type <see cref="T:double[][]"/> to an object of type <see cref="Rectangle"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Rectangle Convert(double[][] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("Precondition: value.Length == 2", "value");
            }

            var northWest = default(Vector2D);
            var first = value[0];
            if (first != null && first.Length == 2)
            {
                northWest = this.vector2DConverter.Convert(first);
            }

            var southEast = default(Vector2D);
            var second = value[1];
            if (second != null && second.Length == 2)
            {
                southEast = this.vector2DConverter.Convert(second);
            }

            return new Rectangle(northWest, southEast);
        }
    }
}