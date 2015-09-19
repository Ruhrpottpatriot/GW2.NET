namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Skins;
    using GW2NET.V1.Skins.Converters;
    using GW2NET.V1.Skins.Json;

    public class ArmorSkinConverterFactory : ITypeConverterFactory<SkinDTO, ArmorSkin>
    {
        public IConverter<SkinDTO, ArmorSkin> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Boots":
                    return new BootsSkinConverter();
                case "Coat":
                    return new CoatSkinConverter();
                case "Helm":
                    return new HelmSkinConverter();
                case "Shoulders":
                    return new ShouldersSkinConverter();
                case "Gloves":
                    return new GlovesSkinConverter();
                case "Leggings":
                    return new LeggingsSkinConverter();
                case "HelmAquatic":
                    return new HelmAquaticSkinConverter();
                default:
                    return new UnknownArmorSkinConverter();
            }
        }
    }
}