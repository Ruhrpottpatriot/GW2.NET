// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDTO" /> to objects of type <see cref="Food" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class FoodConverter
    {
        partial void Merge(Food entity, ItemDTO dto, object state)
        {
            var consumable = dto.Consumable;
            if (consumable == null)
            {
                return;
            }

            entity.Effect = consumable.Description;
            double duration;
            if (double.TryParse(consumable.Duration, out duration))
            {
                entity.Duration = TimeSpan.FromMilliseconds(duration);
            }
        }
    }
}