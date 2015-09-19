namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.V1.WorldVersusWorld.Matches.Converters;
    using GW2NET.V1.WorldVersusWorld.Matches.Json;
    using GW2NET.WorldVersusWorld;

    public class CompetitiveMapConverterFactory : ITypeConverterFactory<CompetitiveMapDTO, CompetitiveMap>
    {
        public IConverter<CompetitiveMapDTO, CompetitiveMap> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "RedHome":
                    return new RedBorderlandsConverter();
                case "GreenHome":
                    return new GreenBorderlandsConverter();
                case "BlueHome":
                    return new BlueBorderlandsConverter();
                case "Center":
                    return new EternalBattlegroundsConverter();
                default:
                    return new UnknownCompetitiveMapConverter();
            }
        }
    }
}