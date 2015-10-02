namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Converters;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    public class MapBonusConverterFactory : ITypeConverterFactory<MapBonusDTO, MapBonus>
    {
        public IConverter<MapBonusDTO, MapBonus> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "bloodlust":
                    return new BloodlustConverter();
                default:
                    return new UnknownMapBonusConverter();
            }
        }
    }
}