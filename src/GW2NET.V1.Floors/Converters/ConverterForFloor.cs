// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForFloor.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="FloorDataContract" /> to objects of type <see cref="Floor" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using GW2NET.Common;
using GW2NET.Common.Converters;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="FloorDataContract"/> to objects of type <see cref="Floor"/>.</summary>
    internal sealed class ConverterForFloor : IConverter<FloorDataContract, Floor>
    {
        private readonly IConverter<double[][], Rectangle> converterForRectangle;

        private readonly IConverter<IDictionary<string, RegionDataContract>, IDictionary<int, Region>> converterForRegionCollection;

        private readonly IConverter<double[], Size2D> converterForSize2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForFloor"/> class.</summary>
        public ConverterForFloor()
            : this(new ConverterForSize2D(), new ConverterForRectangle(), new ConverterForIDictionary<string, RegionDataContract, int, Region>(new ConverterForRegionKeyValuePair()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForFloor"/> class.</summary>
        /// <param name="converterForSize2D">The converter for <see cref="Size2D"/>.</param>
        /// <param name="converterForRectangle">The converter for <see cref="Rectangle"/>.</param>
        /// <param name="converterForRegionCollection">The converter for <see cref="T:IDictionary{int,Region}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForSize2D"/> or <paramref name="converterForRectangle"/> or <paramref name="converterForRegionCollection"/> is a null reference.</exception>
        public ConverterForFloor(IConverter<double[], Size2D> converterForSize2D, IConverter<double[][], Rectangle> converterForRectangle, IConverter<IDictionary<string, RegionDataContract>, IDictionary<int, Region>> converterForRegionCollection)
        {
            if (converterForSize2D == null)
            {
                throw new ArgumentNullException("converterForSize2D", "Precondition: converterForSize2D != null");
            }

            if (converterForRectangle == null)
            {
                throw new ArgumentNullException("converterForRectangle", "Precondition: converterForRectangle != null");
            }

            if (converterForRegionCollection == null)
            {
                throw new ArgumentNullException("converterForRegionCollection", "Precondition: converterForRegionCollection != null");
            }

            this.converterForSize2D = converterForSize2D;
            this.converterForRectangle = converterForRectangle;
            this.converterForRegionCollection = converterForRegionCollection;
        }

        /// <inheritdoc />
        public Floor Convert(FloorDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            // Create a new floor object
            var floor = new Floor();

            // Set the texture dimensions
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
    }
}