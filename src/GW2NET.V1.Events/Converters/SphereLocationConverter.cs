// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SphereLocationConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="LocationDTO" /> to objects of type <see cref="SphereLocation" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Events.Converters
{
    using GW2NET.DynamicEvents;
    using GW2NET.V1.Events.Json;

    public partial class SphereLocationConverter
    {
        partial void Merge(SphereLocation entity, LocationDTO dto, object state)
        {
            entity.Radius = dto.Radius;
            entity.Rotation = dto.Rotation;
        }
    }
}