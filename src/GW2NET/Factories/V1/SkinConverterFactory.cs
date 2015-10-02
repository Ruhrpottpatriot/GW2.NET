namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Skins;
    using GW2NET.V1.Skins.Converters;
    using GW2NET.V1.Skins.Json;

    public class SkinConverterFactory : ITypeConverterFactory<SkinDTO, Skin>
    {
        public IConverter<SkinDTO, Skin> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Armor":
                    return new ArmorSkinConverter(new ArmorSkinConverterFactory(), new WeightClassConverter());
                case "Back":
                    return new BackpackSkinConverter();
                case "Weapon":
                    return new WeaponSkinConverter(new WeaponSkinConverterFactory(), new DamageTypeConverter());
                default:
                    return new UnknownSkinConverter();
            }
        }
    }
}