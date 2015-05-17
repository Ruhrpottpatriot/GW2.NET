// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;

    /// <summary>Converts objects of type <see cref="MapDataContract"/> to objects of type <see cref="Map"/>.</summary>
    internal sealed class MapConverter : IConverter<MapDataContract, Map>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[][], Rectangle> rectangleConverter;

        /// <summary>Initializes a new instance of the <see cref="MapConverter"/> class.</summary>
        public MapConverter()
            : this(new RectangleConverter())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MapConverter"/> class.</summary>
        /// <param name="converterForRectangle">The converter for <see cref="Rectangle"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForRectangle"/> is a null reference.</exception>
        public MapConverter(IConverter<double[][], Rectangle> converterForRectangle)
        {
            if (converterForRectangle == null)
            {
                throw new ArgumentNullException("converterForRectangle", "Precondition: converterForRectangle != null");
            }

            this.rectangleConverter = converterForRectangle;
        }

        /// <inheritdoc />
        public Map Convert(MapDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var map = new Map
            {
                // ReSharper disable once PossibleNullReferenceException
                MapName = value.Name,
                MinimumLevel = value.MinimumLevel,
                MaximumLevel = value.MaximumLevel,
                DefaultFloor = value.DefaultFloor,
                Floors = value.Floors,
                RegionId = value.RegionId,
                RegionName = value.RegionName,
                ContinentId = value.ContinentId,
                ContinentName = value.ContinentName,
                MapId = value.Id
            };

            // Set the dimensions
            var mapRectangle = value.MapRectangle;
            if (mapRectangle != null && mapRectangle.Length == 2)
            {
                var northWest = mapRectangle[0];
                if (northWest != null && northWest.Length == 2)
                {
                    var southEast = mapRectangle[1];
                    if (southEast != null && southEast.Length == 2)
                    {
                        map.MapRectangle = this.rectangleConverter.Convert(mapRectangle);
                    }
                }
            }

            // Set the dimensions of the continent
            var continentRectangle = value.ContinentRectangle;
            if (continentRectangle != null && continentRectangle.Length == 2)
            {
                var northWest = continentRectangle[0];
                if (northWest != null && northWest.Length == 2)
                {
                    var southEast = continentRectangle[1];
                    if (southEast != null && southEast.Length == 2)
                    {
                        map.ContinentRectangle = this.rectangleConverter.Convert(continentRectangle);
                    }
                }
            }

            // Return the map object
            return map;
        }
    }
}