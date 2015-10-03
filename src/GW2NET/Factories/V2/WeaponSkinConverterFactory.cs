// <copyright file="WeaponSkinConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Skins;
    using GW2NET.V2.Skins.Converters;
    using GW2NET.V2.Skins.Json;

    public class WeaponSkinConverterFactory : ITypeConverterFactory<SkinDTO, WeaponSkin>
    {
        public IConverter<SkinDTO, WeaponSkin> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Axe":
                    return new AxeSkinConverter();
                case "Dagger":
                    return new DaggerSkinConverter();
                case "Focus":
                    return new FocusSkinConverter();
                case "Greatsword":
                    return new GreatSwordSkinConverter();
                case "Hammer":
                    return new HammerSkinConverter();
                case "Harpoon":
                    return new HarpoonSkinConverter();
                case "LongBow":
                    return new LongBowSkinConverter();
                case "Mace":
                    return new MaceSkinConverter();
                case "Pistol":
                    return new PistolSkinConverter();
                case "Rifle":
                    return new RifleSkinConverter();
                case "Scepter":
                    return new ScepterSkinConverter();
                case "Shield":
                    return new ShieldSkinConverter();
                case "ShortBow":
                    return new ShortBowSkinConverter();
                case "Speargun":
                    return new SpearGunSkinConverter();
                case "Sword":
                    return new SwordSkinConverter();
                case "Staff":
                    return new StaffSkinConverter();
                case "Torch":
                    return new TorchSkinConverter();
                case "Trident":
                    return new TridentSkinConverter();
                case "Warhorn":
                    return new WarHornSkinConverter();
                case "Toy":
                    return new ToySkinConverter();
                case "TwoHandedToy":
                    return new TwoHandedToySkinConverter();
                case "SmallBundle":
                    return new SmallBundleSkinConverter();
                case "LargeBundle":
                    return new LargeBundleSkinConverter();
                default:
                    return new UnknownWeaponSkinConverter();
            }
        }
    }
}