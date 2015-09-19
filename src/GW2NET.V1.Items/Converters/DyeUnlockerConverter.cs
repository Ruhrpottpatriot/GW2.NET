// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DyeUnlockerConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDTO" /> to objects of type <see cref="DyeUnlocker" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class DyeUnlockerConverter 
    {
        partial void Merge(DyeUnlocker entity, ItemDTO dto, object state)
        {
            var consumable = dto.Consumable;
            if (consumable == null)
            {
                return;
            }

            int colorId;
            if (int.TryParse(consumable.ColorId, out colorId))
            {
                entity.ColorId = colorId;
            }
        }
    }
}