// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FloorConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="FloorDataContract" /> to objects of type <see cref="Floor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Floors
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="FloorDataContract"/> to objects of type <see cref="Floor"/>.</summary>
    internal sealed class FloorConverter : IConverter<FloorDataContract, Floor>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[][], Rectangle> converterForRectangle;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IDictionary<string, RegionDataContract>, IDictionary<int, Region>> converterForRegionCollection;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Size2D> converterForSize2D;

        /// <summary>Initializes a new instance of the <see cref="FloorConverter"/> class.</summary>
        public FloorConverter()
            : this(new Size2DConverter(), new RectangleConverter(), new ConverterForIDictionary<string, RegionDataContract, int, Region>(new RegionKeyValuePairConverter()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FloorConverter"/> class.</summary>
        /// <param name="converterForSize2D">The converter for <see cref="Size2D"/>.</param>
        /// <param name="converterForRectangle">The converter for <see cref="Rectangle"/>.</param>
        /// <param name="converterForRegionCollection">The converter for <see cref="T:IDictionary{int,Region}"/>.</param>
        public FloorConverter(IConverter<double[], Size2D> converterForSize2D, IConverter<double[][], Rectangle> converterForRectangle, IConverter<IDictionary<string, RegionDataContract>, IDictionary<int, Region>> converterForRegionCollection)
        {
            Contract.Requires(converterForSize2D != null);
            Contract.Requires(converterForRectangle != null);
            Contract.Requires(converterForRegionCollection != null);
            this.converterForSize2D = converterForSize2D;
            this.converterForRectangle = converterForRectangle;
            this.converterForRegionCollection = converterForRegionCollection;
        }

        /// <summary>Converts the given object of type <see cref="FloorDataContract"/> to an object of type <see cref="Floor"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Floor Convert(FloorDataContract value)
        {
            Contract.Assume(value != null);

            // Create a new floor object
            var floor = new Floor();

            // Set the texture dimensions
            // ReSharper disable once PossibleNullReferenceException
            var textureDimensions = value.TextureDimensions;
            if (textureDimensions != null && textureDimensions.Length == 2)
            {
                floor.TextureDimensions = this.converterForSize2D.Convert(textureDimensions);
            }

            // Set the clamped view dimensions
            var clampedView = value.ClampedView;
            if (clampedView != null && clampedView.Length == 2)
            {
                floor.ClampedView = this.converterForRectangle.Convert(clampedView);
            }

            // Set the regions
            var regionDataContracts = value.Regions;
            if (regionDataContracts != null)
            {
                floor.Regions = this.converterForRegionCollection.Convert(regionDataContracts);
            }

            // Return the floor object
            return floor;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when DataContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.converterForRectangle != null);
            Contract.Invariant(this.converterForRegionCollection != null);
            Contract.Invariant(this.converterForSize2D != null);
        }
    }
}