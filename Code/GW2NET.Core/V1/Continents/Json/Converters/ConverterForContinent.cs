// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForContinent.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ContinentDataContract" /> to objects of type <see cref="Continent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Continents.Json.Converters
{
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Entities.Maps;

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
            this.converterForSize2D = converterForSize2D;
        }

        /// <summary>Converts the given object of type <see cref="ContinentDataContract"/> to an object of type <see cref="Continent"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Continent Convert(ContinentDataContract value)
        {
            var continent = new Continent();
            continent.Name = value.Name;
            if (value.ContinentDimensions != null && value.ContinentDimensions.Length == 2)
            {
                continent.ContinentDimensions = this.converterForSize2D.Convert(value.ContinentDimensions);
            }

            continent.MinimumZoom = value.MinimumZoom;
            continent.MaximumZoom = value.MaximumZoom;
            continent.FloorIds = value.Floors;
            return continent;
        }
    }
}