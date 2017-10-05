// <copyright file="ArmorConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V1
{
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class ArmorConverterFactory : ITypeConverterFactory<ItemDTO, Armor>
    {
        public IConverter<ItemDTO, Armor> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Boots":
                    return new BootsConverter();
                case "Coat":
                    return new CoatConverter();
                case "Gloves":
                    return new GlovesConverter();
                case "Helm":
                    return new HelmConverter();
                case "HelmAquatic":
                    return new HelmAquaticConverter();
                case "Leggings":
                    return new LeggingsConverter();
                case "Shoulders":
                    return new ShouldersConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownArmorConverter();
            }
        }
    }
}