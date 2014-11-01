// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForColorPalette.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ColorDataContract" /> to objects of type <see cref="ColorPalette" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Colors.Json.Converters
{
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Entities.Colors;

    /// <summary>Converts objects of type <see cref="ColorDataContract"/> to objects of type <see cref="ColorPalette"/>.</summary>
    internal sealed class ConverterForColorPalette : IConverter<ColorDataContract, ColorPalette>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Color> converterForColor;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ColorModelDataContract, ColorModel> converterForColorModel;

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPalette"/> class.</summary>
        internal ConverterForColorPalette()
            : this(new ConverterForColor(), new ConverterForColorModel())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForColorPalette"/> class.</summary>
        /// <param name="converterForColor">The converter for <see cref="Color"/>.</param>
        /// <param name="converterForColorModel">The converter for <see cref="ColorModel"/>.</param>
        internal ConverterForColorPalette(IConverter<int[], Color> converterForColor, IConverter<ColorModelDataContract, ColorModel> converterForColorModel)
        {
            Contract.Requires(converterForColor != null);
            Contract.Requires(converterForColorModel != null);
            this.converterForColor = converterForColor;
            this.converterForColorModel = converterForColorModel;
        }

        /// <summary>Converts the given object of type <see cref="ColorDataContract"/> to an object of type <see cref="ColorPalette"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public ColorPalette Convert(ColorDataContract value)
        {
            Contract.Assume(value != null);

            // Create a new color object
            var colorPalette = new ColorPalette { Name = value.Name };

            // Set the base RGB values
            var rgb = value.BaseRgb;
            if (rgb != null && rgb.Length == 3)
            {
                colorPalette.BaseRgb = this.converterForColor.Convert(rgb);
            }

            // Set the color model for cloth
            var cloth = value.Cloth;
            if (cloth != null)
            {
                colorPalette.Cloth = this.converterForColorModel.Convert(cloth);
            }

            // Set the color model for leather
            var leather = value.Leather;
            if (leather != null)
            {
                colorPalette.Leather = this.converterForColorModel.Convert(leather);
            }

            // Set the color model for metal
            var metal = value.Metal;
            if (metal != null)
            {
                colorPalette.Metal = this.converterForColorModel.Convert(metal);
            }

            // Return the color object
            return colorPalette;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForColor != null);
            Contract.Invariant(this.converterForColorModel != null);
        }
    }
}