namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class ArmorConverterFactory : ITypeConverterFactory<ItemDTO, Armor>
    {
        public IConverter<ItemDTO, Armor> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Boots":
                    return new BootsConverter();
                case "Coat":
                    return new CoatConverter();
                case "Gloves":
                    return new GlovesConverter();
                case "Helm":
                    return new HelmConverter();
                case "HelmAquatic":
                    return new HelmAquaticConverter();
                case "Leggings":
                    return new LeggingsConverter();
                case "Shoulders":
                    return new ShouldersConverter();
                default:
                    return new UnknownArmorConverter();
            }
        }
    }
}