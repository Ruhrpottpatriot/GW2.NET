// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContinent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContinentDataContract" /> to objects of type <see cref="Continent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Continents.Converters
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V1.Continents.Json;

    /// <summary>Converts objects of type <see cref="ContinentDataContract"/> to objects of type <see cref="Continent"/>.</summary>
    internal sealed class ConverterForContinent : IConverter<ContinentDataContract, Continent>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Size2D> converterForSize2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinent"/> class.</summary>
        public ConverterForContinent()
            : this(new ConverterForSize2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForContinent"/> class.</summary>
        /// <param name="converterForSize2D">The converter for <see cref="Size2D"/>.</param>
        public ConverterForContinent(IConverter<double[], Size2D> converterForSize2D)
        {
            Contract.Requires(converterForSize2D != null);
            this.converterForSize2D = converterForSize2D;
        }

        /// <summary>Converts the given object of type <see cref="ContinentDataContract"/> to an object of type <see cref="Continent"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Continent Convert(ContinentDataContract value)
        {
            Contract.Assume(value != null);
            var continent = new Continent
            {
                Name = value.Name, 
                MinimumZoom = value.MinimumZoom, 
                MaximumZoom = value.MaximumZoom, 
                FloorIds = value.Floors
            };
            var dimensions = value.ContinentDimensions;
            if (dimensions != null && dimensions.Length == 2)
            {
                continent.ContinentDimensions = this.converterForSize2D.Convert(dimensions);
            }

            return continent;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForSize2D != null);
        }
    }
}