// <copyright file="ToolConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V1
{
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Converters;
    using GW2NET.V1.Items.Json;

    public class ToolConverterFactory : ITypeConverterFactory<ItemDTO, Tool>
    {
        public IConverter<ItemDTO, Tool> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Salvage":
                    return new SalvageToolConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownToolConverter();
            }
        }
    }
}