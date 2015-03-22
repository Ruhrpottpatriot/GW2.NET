// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="RegionDataContract" /> to objects of type <see cref="Region" />.
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

    /// <summary>Converts objects of type <see cref="RegionDataContract"/> to objects of type <see cref="Region"/>.</summary>
    internal sealed class RegionConverter : IConverter<RegionDataContract, Region>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IDictionary<string, MapDataContract>, IDictionary<int, Subregion>> mapKeyValuePairConverter;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        /// <summary>Initializes a new instance of the <see cref="RegionConverter"/> class.</summary>
        public RegionConverter()
            : this(new Vector2DConverter(), new ConverterForIDictionary<string, MapDataContract, int, Subregion>(new MapKeyValuePairConverter()))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RegionConverter"/> class.</summary>
        /// <param name="vector2DConverter">The converter for <see cref="Vector2D"/>.</param>
        /// <param name="mapKeyValuePairConverter">The converter for <see cref="T:KeyValuePair{int,Subregion}"/>.</param>
        public RegionConverter(IConverter<double[], Vector2D> vector2DConverter, IConverter<IDictionary<string, MapDataContract>, IDictionary<int, Subregion>> mapKeyValuePairConverter)
        {
            Contract.Requires(vector2DConverter != null);
            Contract.Requires(mapKeyValuePairConverter != null);
            this.vector2DConverter = vector2DConverter;
            this.mapKeyValuePairConverter = mapKeyValuePairConverter;
        }

        /// <summary>Converts the given object of type <see cref="RegionDataContract"/> to an object of type <see cref="Region"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Region Convert(RegionDataContract value)
        {
            Contract.Assume(value != null);

            // Create a new region object
            var region = new Region
                             {
                                 // ReSharper disable once PossibleNullReferenceException
                                 Name = value.Name
                             };

            // Set the position of the region label
            var labelCoordinates = value.LabelCoordinates;
            if (labelCoordinates != null && labelCoordinates.Length == 2)
            {
                region.LabelCoordinates = this.vector2DConverter.Convert(labelCoordinates);
            }

            // Set the maps
            var subregionDataContracts = value.Maps;
            if (subregionDataContracts != null)
            {
                region.Maps = this.mapKeyValuePairConverter.Convert(subregionDataContracts);
            }

            // Return the region object
            return region;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        [SuppressMessage("ReSharper", "UnusedMember.Local", Justification = "Only used when DataContracts are enabled.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.vector2DConverter != null);
            Contract.Invariant(this.mapKeyValuePairConverter != null);
        }
    }
}