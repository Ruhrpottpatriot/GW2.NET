// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRectangle.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[][]" /> to objects of type <see cref="Rectangle" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;

namespace GW2NET.V1.Maps.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="T:double[][]"/> to objects of type <see cref="Rectangle"/>.</summary>
    internal sealed class ConverterForRectangle : IConverter<double[][], Rectangle>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRectangle"/> class.</summary>
        internal ConverterForRectangle()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRectangle"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        internal ConverterForRectangle(IConverter<double[], Vector2D> converterForVector2D)
        {
            if (converterForVector2D == null)
            {
                throw new ArgumentNullException("converterForVector2D", "Precondition: converterForVector2D != null");
            }

            this.converterForVector2D = converterForVector2D;
        }

        /// <inheritdoc />
        public Rectangle Convert(double[][] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("Precondition value.Length == 2", "value");
            }

            var nw = default(Vector2D);
            var values1 = value[0];
            if (values1 != null && values1.Length == 2)
            {
                nw = this.converterForVector2D.Convert(values1, state);
            }

            var se = default(Vector2D);
            var values2 = value[1];
            if (values2 != null && values2.Length == 2)
            {
                se = this.converterForVector2D.Convert(values2, state);
            }

            return new Rectangle(nw, se);
        }
    }
}