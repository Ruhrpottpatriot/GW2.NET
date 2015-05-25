// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRectangle.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[][]" /> to objects of type <see cref="Rectangle" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Common.Drawing;

namespace GW2NET.V1.Floors.Converters
{
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
            Contract.Requires(converterForVector2D != null);
            this.converterForVector2D = converterForVector2D;
        }

        /// <summary>Converts the given object of type <see cref="T:double[][]"/> to an object of type <see cref="Rectangle"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Rectangle Convert(double[][] value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Length == 2);

            var nw = default(Vector2D);
            var values1 = value[0];
            if (values1 != null && values1.Length == 2)
            {
                nw = this.converterForVector2D.Convert(values1);
            }

            var se = default(Vector2D);
            var values2 = value[1];
            if (values2 != null && values2.Length == 2)
            {
                se = this.converterForVector2D.Convert(values2);
            }

            return new Rectangle(nw, se);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForVector2D != null);
        }
    }
}