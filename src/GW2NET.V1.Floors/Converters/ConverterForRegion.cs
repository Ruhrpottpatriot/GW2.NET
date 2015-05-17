// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRegion.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RegionDataContract" /> to objects of type <see cref="Region" />.
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

    /// <summary>Converts objects of type <see cref="RegionDataContract"/> to objects of type <see cref="Region"/>.</summary>
    internal sealed class ConverterForRegion : IConverter<RegionDataContract, Region>
    {
        private readonly IConverter<IDictionary<string, SubregionDataContract>, IDictionary<int, Subregion>> converterForSubregionKeyValuePair;

        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegion"/> class.</summary>
        public ConverterForRegion()
            : this(new ConverterForVector2D(), new ConverterForIDictionary<string, SubregionDataContract, int, Subregion>(new ConverterForSubregionKeyValuePair()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForRegion"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        /// <param name="converterForSubregionKeyValuePair">The converter for <see cref="T:KeyValuePair{int,Subregion}"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForVector2D"/> or <paramref name="converterForSubregionKeyValuePair"/> is a null reference.</exception>
        public ConverterForRegion(IConverter<double[], Vector2D> converterForVector2D, IConverter<IDictionary<string, SubregionDataContract>, IDictionary<int, Subregion>> converterForSubregionKeyValuePair)
        {
            if (converterForVector2D == null)
            {
                throw new ArgumentNullException("converterForVector2D", "Precondition: converterForVector2D != null");
            }

            if (converterForSubregionKeyValuePair == null)
            {
                throw new ArgumentNullException("converterForSubregionKeyValuePair", "Precondition: converterForSubregionKeyValuePair != null");
            }

            this.converterForVector2D = converterForVector2D;
            this.converterForSubregionKeyValuePair = converterForSubregionKeyValuePair;
        }

        /// <inheritdoc />
        public Region Convert(RegionDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            // Create a new region object
            var region = new Region
            {
                Name = value.Name
            };

            // Set the position of the region label
            var labelCoordinates = value.LabelCoordinates;
            if (labelCoordinates != null && labelCoordinates.Length == 2)
            {
                region.LabelCoordinates = this.converterForVector2D.Convert(labelCoordinates);
            }

            // Set the maps
            var subregionDataContracts = value.Maps;
            if (subregionDataContracts != null)
            {
                region.Maps = this.converterForSubregionKeyValuePair.Convert(subregionDataContracts);
            }

            // Return the region object
            return region;
        }
    }
}