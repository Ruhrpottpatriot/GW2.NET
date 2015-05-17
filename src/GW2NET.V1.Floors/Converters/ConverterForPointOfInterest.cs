// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForPointOfInterest.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="PointOfInterestDataContract" /> to objects of type <see cref="PointOfInterest" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="PointOfInterestDataContract"/> to objects of type <see cref="PointOfInterest"/>.</summary>
    internal sealed class ConverterForPointOfInterest : IConverter<PointOfInterestDataContract, PointOfInterest>
    {
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForPointOfInterest"/> class.</summary>
        internal ConverterForPointOfInterest()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForPointOfInterest"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForVector2D"/> is a null reference.</exception>
        internal ConverterForPointOfInterest(IConverter<double[], Vector2D> converterForVector2D)
        {
            if (converterForVector2D == null)
            {
                throw new ArgumentNullException("converterForVector2D", "Precondition: converterForVector2D != null");
            }

            this.converterForVector2D = converterForVector2D;
        }

        /// <inheritdoc />
        public PointOfInterest Convert(PointOfInterestDataContract value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            PointOfInterest pointOfInterest;
            switch (value.Type)
            {
                case "unlock":
                    pointOfInterest = new Dungeon();
                    break;
                case "landmark":
                    pointOfInterest = new Landmark();
                    break;
                case "vista":
                    pointOfInterest = new Vista();
                    break;
                case "waypoint":
                    pointOfInterest = new Waypoint();
                    break;
                default:
                    pointOfInterest = new UnknownPointOfInterest();
                    break;
            }

            pointOfInterest.PointOfInterestId = value.PointOfInterestId;
            pointOfInterest.Name = value.Name;
            pointOfInterest.Floor = value.Floor;
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                pointOfInterest.Coordinates = this.converterForVector2D.Convert(coordinates);
            }

            return pointOfInterest;
        }
    }
}