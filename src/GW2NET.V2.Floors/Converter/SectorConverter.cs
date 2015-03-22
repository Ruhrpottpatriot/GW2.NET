// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SectorDataContract" /> to objects of type <see cref="Sector" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="SectorDataContract"/> to objects of type <see cref="Sector"/>.</summary>
    internal sealed class SectorConverter : IConverter<SectorDataContract, Sector>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="SectorConverter"/> class.</summary>
        public SectorConverter()
            : this(new Vector2DConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="SectorConverter"/> class.</summary>
        /// <param name="vector2DConverter">The converter for <see cref="Vector2D"/>.</param>
        public SectorConverter(IConverter<double[], Vector2D> vector2DConverter)
        {
            Contract.Requires(vector2DConverter != null);
            this.vector2DConverter = vector2DConverter;
        }

        /// <summary>Converts the given object of type <see cref="SectorDataContract"/> to an object of type <see cref="Sector"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Sector Convert(SectorDataContract value)
        {
            Contract.Assume(value != null);
            var sector = new Sector
            {
                // ReSharper disable once PossibleNullReferenceException
                SectorId = value.SectorId,
                Name = value.Name,
                Level = value.Level,
            };
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                sector.Coordinates = this.vector2DConverter.Convert(coordinates);
            }

            return sector;
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