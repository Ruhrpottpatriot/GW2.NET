// <copyright file="ArmorSkinConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.Services
{
    using System.Diagnostics;
    using Common;
    using Converter;
    using Json;
    using Skins;

    public class ArmorSkinConverterFactory : ITypeConverterFactory<SkinDTO, ArmorSkin>
    {
        public IConverter<SkinDTO, ArmorSkin> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Boots":
                    return new BootsSkinConverter();
                case "Coat":
                    return new CoatSkinConverter();
                case "Helm":
                    return new HelmSkinConverter();
                case "Shoulders":
                    return new ShouldersSkinConverter();
                case "Gloves":
                    return new GlovesSkinConverter();
                case "Leggings":
                    return new LeggingsSkinConverter();
                case "HelmAquatic":
                    return new HelmAquaticSkinConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownArmorSkinConverter();
            }
        }
    }
}