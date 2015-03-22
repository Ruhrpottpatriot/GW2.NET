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
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

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
        internal RectangleConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            Contract.Requires(vector2DConverter != null);
            this.vector2DConverter = vector2DConverter;
        }

        /// <summary>Converts the given object of type <see cref="T:double[][]"/> to an object of type <see cref="Rectangle"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Rectangle Convert(double[][] value)
        {
            Contract.Assume(value != null);
            // ReSharper disable once PossibleNullReferenceException
            Contract.Assume(value.Length == 2);

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

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when DataContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.vector2DConverter != null);
        }
    }
}