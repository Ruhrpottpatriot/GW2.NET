// <copyright file="WeaponConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V2
{
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

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
                case "ToyTwoHanded":
                case "TwoHandedToy":
                    return new TwoHandedToyConverter();
                case "SmallBundle":
                    return new SmallBundleConverter();
                case "LargeBundle":
                    return new LargeBundleConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownWeaponConverter();
            }
        }
    }
}