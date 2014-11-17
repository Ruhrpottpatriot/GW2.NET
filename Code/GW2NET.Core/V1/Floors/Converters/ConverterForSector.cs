// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSector.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SectorDataContract" /> to objects of type <see cref="Sector" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="SectorDataContract"/> to objects of type <see cref="Sector"/>.</summary>
    internal sealed class ConverterForSector : IConverter<SectorDataContract, Sector>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSector"/> class.</summary>
        public ConverterForSector()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSector"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        public ConverterForSector(IConverter<double[], Vector2D> converterForVector2D)
        {
            Contract.Requires(converterForVector2D != null);
            this.converterForVector2D = converterForVector2D;
        }

        /// <summary>Converts the given object of type <see cref="SectorDataContract"/> to an object of type <see cref="Sector"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Sector Convert(SectorDataContract value)
        {
            Contract.Assume(value != null);
            var sector = new Sector
            {
                SectorId = value.SectorId, 
                Name = value.Name, 
                Level = value.Level, 
            };
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                sector.Coordinates = this.converterForVector2D.Convert(coordinates);
            }

            return sector;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForVector2D != null);
        }
    }
}