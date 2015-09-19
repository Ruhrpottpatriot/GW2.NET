namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class GizmoConverterFactory : ITypeConverterFactory<ItemDTO, Gizmo>
    {
        public IConverter<ItemDTO, Gizmo> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Default":
                    return new DefaultGizmoConverter();
                case "ContainerKey":
                    return new ContainerKeyConverter();
                case "RentableContractNpc":
                    return new RentableContractNpcConverter();
                case "UnlimitedConsumable":
                    return new UnlimitedConsumableConverter();
                default:
                    return new UnknownGizmoConverter();
            }
        }
    }
}