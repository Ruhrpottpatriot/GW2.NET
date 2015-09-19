// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Maps.Converter
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.Maps;
    using GW2NET.V2.Maps.Json;

    /// <summary>Converts objects of type <see cref="MapDTO"/> to objects of type <see cref="Map"/>.</summary>
    public sealed class MapConverter : IConverter<MapDTO, Map>
    {
        private readonly IConverter<double[][], Rectangle> rectangleConverter;

        /// <summary>Initializes a new instance of the <see cref="MapConverter"/> class.</summary>
        /// <param name="rectangleConverter">The converter for <see cref="Rectangle"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="rectangleConverter"/> is a null reference.</exception>
        public MapConverter(IConverter<double[][], Rectangle> rectangleConverter)
        {
            if (rectangleConverter == null)
            {
                throw new ArgumentNullException("rectangleConverter");
            }

            this.rectangleConverter = rectangleConverter;
        }

        /// <inheritdoc />
        public Map Convert(MapDTO value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state", "Precondition: state is IResponse");
            }

            var response = state as IResponse;
            if (response == null)
            {
                throw new ArgumentException("Precondition: state is IResponse", "state");
            }

            var map = new Map
            {
                Culture = response.Culture,
                MapName = value.Name,
                MinimumLevel = value.MinimumLevel,
                MaximumLevel = value.MaximumLevel,
                DefaultFloor = value.DefaultFloor,
                Floors = value.Floors,
                RegionId = value.RegionId,
                RegionName = value.RegionName,
                ContinentId = value.ContinentId,
                ContinentName = value.ContinentName,
                MapId = value.Id,
            };

            var mapRectangle = value.MapRectangle;
            if (mapRectangle != null && mapRectangle.Length == 2)
            {
                var northWest = mapRectangle[0];
                if (northWest != null && northWest.Length == 2)
                {
                    var southEast = mapRectangle[1];
                    if (southEast != null && southEast.Length == 2)
                    {
                        map.MapRectangle = this.rectangleConverter.Convert(mapRectangle, state);
                    }
                }
            }

            var continentRectangle = value.ContinentRectangle;
            if (continentRectangle != null && continentRectangle.Length == 2)
            {
                var northWest = continentRectangle[0];
                if (northWest != null && northWest.Length == 2)
                {
                    var southEast = continentRectangle[1];
                    if (southEast != null && southEast.Length == 2)
                    {
                        map.ContinentRectangle = this.rectangleConverter.Convert(continentRectangle, state);
                    }
                }
            }

            return map;
        }
    }
}