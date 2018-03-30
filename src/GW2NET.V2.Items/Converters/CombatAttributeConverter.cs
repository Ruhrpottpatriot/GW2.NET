// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatAttributeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="AttributeDTO" /> to objects of type <see cref="CombatAttribute" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Items.Common;
    using GW2NET.V2.Items.Json;

    public partial class CombatAttributeConverter
    {
        partial void Merge(CombatAttribute entity, AttributeDTO dto, object state)
        {
            entity.Modifier = dto.Modifier;
        }
    }
}