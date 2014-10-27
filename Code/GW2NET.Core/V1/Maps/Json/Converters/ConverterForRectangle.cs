// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRectangle.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[][]" /> to objects of type <see cref="Rectangle" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

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
            this.converterForVector2D = converterForVector2D;
        }

        /// <summary>Converts the given object of type <see cref="T:double[][]"/> to an object of type <see cref="Rectangle"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Rectangle Convert(double[][] value)
        {
            Contract.Requires(value != null);
            Contract.Requires(value.Length == 2);
            Contract.Requires(value[0] != null);
            Contract.Requires(value[0].Length == 2);
            Contract.Requires(value[1] != null);
            Contract.Requires(value[1].Length == 2);
            var nw = this.converterForVector2D.Convert(value[0]);
            var se = this.converterForVector2D.Convert(value[1]);
            return new Rectangle(nw, se);
        }
    }
}