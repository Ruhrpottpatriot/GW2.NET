// <copyright file="ContainerConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V2
{
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class ContainerConverterFactory : ITypeConverterFactory<ItemDTO, Container>
    {
        public IConverter<ItemDTO, Container> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "Default":
                    return new DefaultContainerConverter();
                case "GiftBox":
                    return new GiftBoxConverter();
                case "OpenUI":
                    return new OpenUiContainerConverter();
                case "Immediate":
                    return new ImmediateContainerConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownContainerConverter();
            }
        }
    }
}