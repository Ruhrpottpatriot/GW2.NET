namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class ToolConverterFactory : ITypeConverterFactory<ItemDTO, Tool>
    {
        public IConverter<ItemDTO, Tool> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Salvage":
                    return new SalvageToolConverter();
                default:
                    return new UnknownToolConverter();
            }
        }
    }
}