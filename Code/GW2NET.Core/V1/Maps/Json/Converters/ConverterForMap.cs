// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMap.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="MapDataContract" /> to objects of type <see cref="Map" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Maps.Json.Converters
{
    using System.Diagnostics.Contracts;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Entities.Maps;

    /// <summary>Converts objects of type <see cref="MapDataContract"/> to objects of type <see cref="Map"/>.</summary>
    internal sealed class ConverterForMap : IConverter<MapDataContract, Map>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[][], Rectangle> converterForRectangle;

        /// <summary>Initializes a new instance of the <see cref="ConverterForMap"/> class.</summary>
        public ConverterForMap()
            : this(new ConverterForRectangle())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForMap"/> class.</summary>
        /// <param name="converterForRectangle">The converter for <see cref="Rectangle"/>.</param>
        public ConverterForMap(IConverter<double[][], Rectangle> converterForRectangle)
        {
            this.converterForRectangle = converterForRectangle;
        }

        /// <summary>Converts the given object of type <see cref="MapDataContract"/> to an object of type <see cref="Map"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Map Convert(MapDataContract value)
        {
            Contract.Requires(value != null);
            Contract.Ensures(Contract.Result<Map>() != null);

            // Create a new map object
            var map = new Map();

            // Set the name of the map
            if (value.MapName != null)
            {
                map.MapName = value.MapName;
            }

            // Set the minimum level
            map.MinimumLevel = value.MinimumLevel;

            // Set the maximum level
            map.MaximumLevel = value.MaximumLevel;

            // Set the default floor
            map.DefaultFloor = value.DefaultFloor;

            // Set the available floors
            if (value.Floors != null)
            {
                map.Floors = value.Floors;
            }

            // Set the region identifier
            map.RegionId = value.RegionId;

            // Set the name of the region
            if (value.RegionName != null)
            {
                map.RegionName = value.RegionName;
            }

            // Set the continent identifier
            map.ContinentId = value.ContinentId;

            // Set the name of the continent
            if (value.ContinentName != null)
            {
                map.ContinentName = value.ContinentName;
            }

            // Set the dimensions of the map
            var mapRectangle = value.MapRectangle;
            if (mapRectangle != null && mapRectangle.Length == 2)
            {
                var nw = mapRectangle[0];
                if (nw != null && nw.Length == 2)
                {
                    var se = mapRectangle[1];
                    if (se != null && se.Length == 2)
                    {
                        map.MapRectangle = this.converterForRectangle.Convert(mapRectangle);
                    }
                }
            }

            // Set the dimensions of the continent
            var continentRectangle = value.ContinentRectangle;
            if (continentRectangle != null && continentRectangle.Length == 2)
            {
                var nw = continentRectangle[0];
                if (nw != null && nw.Length == 2)
                {
                    var se = continentRectangle[1];
                    if (se != null && se.Length == 2)
                    {
                        map.ContinentRectangle = this.converterForRectangle.Convert(continentRectangle);
                    }
                }
            }

            // Return the map object
            return map;
        }
    }
}