// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericConsumableConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDTO" /> to objects of type <see cref="GenericConsumable" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class GenericConsumableConverter
    {
        partial void Merge(GenericConsumable entity, ItemDTO dto, object state)
        {
            var consumableDto = dto.Consumable;
            if (consumableDto == null)
            {
                return;
            }

            entity.Effect = consumableDto.Description;
            double duration;
            if (double.TryParse(consumableDto.Duration, out duration))
            {
                entity.Duration = TimeSpan.FromMilliseconds(duration);
            }
        }
    }
}