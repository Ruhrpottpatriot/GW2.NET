// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatAttributeConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="Json.AttributeDTO" /> to objects of type <see cref="CombatAttribute" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class CombatAttributeConverter
    {
        partial void Merge(CombatAttribute entity, AttributeDTO dto, object state)
        {
            int modifier;
            if (int.TryParse(dto.Modifier, out modifier))
            {
                entity.Modifier = modifier;
            }
        }
    }
}