namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class GatheringToolConverterFactory : ITypeConverterFactory<ItemDTO, GatheringTool>
    {
        public IConverter<ItemDTO, GatheringTool> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Foraging":
                    return new ForagingToolConverter();
                case "Logging":
                    return new LoggingToolConverter();
                case "Mining":
                    return new MiningToolConverter();
                default:
                    return new UnknownGatheringToolConverter();
            }
        }
    }
}