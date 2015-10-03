// <copyright file="SkinConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V2
{
    using GW2NET.Common;
    using GW2NET.Skins;
    using GW2NET.V2.Skins.Converters;
    using GW2NET.V2.Skins.Json;

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