// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RectangleConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[][]" /> to objects of type <see cref="Rectangle" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[][]"/> to objects of type <see cref="Rectangle"/>.</summary>
    internal sealed class RectangleConverter : IConverter<double[][], Rectangle>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> vectorConverter;

        /// <summary>Initializes a new instance of the <see cref="RectangleConverter"/> class.</summary>
        public RectangleConverter()
            : this(new Vector2DConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RectangleConverter"/> class.</summary>
        /// <param name="vectorConverter">The vector converter.</param>
        public RectangleConverter(IConverter<double[], Vector2D> vectorConverter)
        {
            Contract.Requires(vectorConverter != null);
            this.vectorConverter = vectorConverter;
        }

        /// <inheritdoc />
        public Rectangle Convert(double[][] value)
        {
            Contract.Assume(value != null);
            // ReSharper disable once PossibleNullReferenceException
            Contract.Assume(value.Length == 2);

            var vectorNorthWest = default(Vector2D);
            var coordiantes = value[0];
            if (coordiantes != null && coordiantes.Length == 2)
            {
                vectorNorthWest = this.vectorConverter.Convert(coordiantes);
            }

            var vectorSouthEast = default(Vector2D);
            coordiantes = value[1];
            if (coordiantes != null && coordiantes.Length == 2)
            {
                vectorSouthEast = this.vectorConverter.Convert(coordiantes);
            }

            return new Rectangle(vectorNorthWest, vectorSouthEast);
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when CodeContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.vectorConverter != null);
        }
    }
}