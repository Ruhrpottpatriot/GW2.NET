// <copyright file="LocationConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V1
{
    using System;
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Common.Drawing;
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events.Converters;
    using GW2NET.V1.Events.Json;

    public class LocationConverterFactory : ITypeConverterFactory<LocationDTO, Location>
    {
        private readonly IConverter<double[], Vector2D> vector2DConverter;

        public LocationConverterFactory(IConverter<double[], Vector2D> vector2DConverter)
        {
            if (vector2DConverter == null)
            {
                throw new ArgumentNullException("vector2DConverter");
            }

            this.vector2DConverter = vector2DConverter;
        }

        public IConverter<LocationDTO, Location> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "sphere":
                    return new SphereLocationConverter();
                case "cylinder":
                    return new CylinderLocationConverter();
                case "poly":
                    return new PolygonLocationConverter(this.vector2DConverter);
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownLocationConverter();
            }
        }
    }
}