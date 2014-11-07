// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForColorPaletteCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorCollectionDataContract" /> to objects of type <see cref="ICollection{T}" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Colors.Converters
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Colors;
    using GW2NET.V1.Colors.Json;

    /// <summary>Converts objects of type <see cref="ColorCollectionDataContract"/> to objects of type <see cref="ICollection{T}"/>.</summary>
    internal sealed class ConverterForColorPaletteCollection : IConverter<ColorCollectionDataContract, ICollection<ColorPalette>>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ColorDataContract, ColorPalette> converterForColorPalette;

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPaletteCollection"/> class.</summary>
        internal ConverterForColorPaletteCollection()
            : this(new ConverterForColorPalette())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPaletteCollection"/> class.</summary>
        /// <param name="converterForColorPalette">The converter for <see cref="ColorPalette"/>.</param>
        internal ConverterForColorPaletteCollection(IConverter<ColorDataContract, ColorPalette> converterForColorPalette)
        {
            Contract.Requires(converterForColorPalette != null);
            this.converterForColorPalette = converterForColorPalette;
        }

        /// <summary>Converts the given object of type <see cref="ColorCollectionDataContract"/> to an object of type <see cref="ICollection{ColorPalette}"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ICollection<ColorPalette> Convert(ColorCollectionDataContract value)
        {
            Contract.Assume(value != null);
            Contract.Assume(value.Colors != null);
            var colorPalettes = new List<ColorPalette>(value.Colors.Count);
            foreach (var dataContract in value.Colors)
            {
                var colorPalette = this.converterForColorPalette.Convert(dataContract.Value);
                if (colorPalette == null)
                {
                    continue;
                }

                int id;
                if (int.TryParse(dataContract.Key, out id))
                {
                    colorPalette.ColorId = id;
                }

                colorPalettes.Add(colorPalette);
            }

            return colorPalettes;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForColorPalette != null);
        }
    }
}