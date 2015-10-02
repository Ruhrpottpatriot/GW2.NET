namespace GW2NET.Factories.V1
{
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class WeaponConverterFactory : ITypeConverterFactory<ItemDTO, Weapon>
    {
        public IConverter<ItemDTO, Weapon> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Axe":
                    return new AxeConverter();
                case "Dagger":
                    return new DaggerConverter();
                case "Focus":
                    return new FocusConverter();
                case "Greatsword":
                    return new GreatSwordConverter();
                case "Hammer":
                    return new HammerConverter();
                case "Harpoon":
                    return new HarpoonConverter();
                case "LongBow":
                    return new LongBowConverter();
                case "Mace":
                    return new MaceConverter();
                case "Pistol":
                    return new PistolConverter();
                case "Rifle":
                    return new RifleConverter();
                case "Scepter":
                    return new ScepterConverter();
                case "Shield":
                    return new ShieldConverter();
                case "ShortBow":
                    return new ShortBowConverter();
                case "Speargun":
                    return new SpearGunConverter();
                case "Sword":
                    return new SwordConverter();
                case "Staff":
                    return new StaffConverter();
                case "Torch":
                    return new TorchConverter();
                case "Trident":
                    return new TridentConverter();
                case "Warhorn":
                    return new WarHornConverter();
                case "Toy":
                    return new ToyConverter();
                case "TwoHandedToy":
                    return new TwoHandedToyConverter();
                case "SmallBundle":
                    return new SmallBundleConverter();
                case "LargeBundle":
                    return new LargeBundleConverter();
                default:
                    return new UnknownWeaponConverter();
            }
        }
    }
}