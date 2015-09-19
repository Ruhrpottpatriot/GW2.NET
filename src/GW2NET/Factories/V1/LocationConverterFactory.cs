namespace GW2NET.Factories.V1
{
    using System;

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
                    return new UnknownLocationConverter();
            }
        }
    }
}