// <copyright file="UpgradeComponentConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V1
{
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class UpgradeComponentConverterFactory : ITypeConverterFactory<ItemDTO, UpgradeComponent>
    {
        public IConverter<ItemDTO, UpgradeComponent> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Default":
                    return new DefaultUpgradeComponentConverter();
                case "Gem":
                    return new GemConverter();
                case "Sigil":
                    return new SigilConverter();
                case "Rune":
                    return new RuneConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownUpgradeComponentConverter();
            }
        }
    }
}