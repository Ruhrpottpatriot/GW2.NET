namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class TrinketConverterFactory : ITypeConverterFactory<ItemDTO, Trinket>
    {
        public IConverter<ItemDTO, Trinket> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Amulet":
                    return new AmuletConverter();
                case "Accessory":
                    return new AccessoryConverter();
                case "Ring":
                    return new RingConverter();
                default:
                    return new UnknownTrinketConverter();
            }
        }
    }
}