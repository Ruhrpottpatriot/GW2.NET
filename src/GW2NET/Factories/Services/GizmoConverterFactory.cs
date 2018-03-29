// <copyright file="GizmoConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.Services
{
    using System.Diagnostics;
    using Common;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;
    using Items.Gizmos;

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
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownGizmoConverter();
            }
        }
    }
}