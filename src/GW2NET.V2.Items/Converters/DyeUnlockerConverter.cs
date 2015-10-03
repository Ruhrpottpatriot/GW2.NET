// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DyeUnlockerConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDTO" /> to objects of type <see cref="DyeUnlocker" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Items;
    using GW2NET.V2.Items.Json;

    public partial class DyeUnlockerConverter
    {
        partial void Merge(DyeUnlocker entity, ItemDTO dto, object state)
        {
            var details = dto.Details;
            if (details == null)
            {
                return;
            }

            if (details.ColorId.HasValue)
            {
                entity.ColorId = details.ColorId.Value;
            }
        }
    }
}