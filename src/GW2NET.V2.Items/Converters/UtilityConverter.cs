// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilityConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDTO" /> to objects of type <see cref="Utility" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Converters
{
    using System;
    using GW2NET.Items.Consumables;
    using GW2NET.V2.Items.Json;

    public partial class UtilityConverter
    {
        partial void Merge(Utility entity, ItemDTO dto, object state)
        {
            var details = dto.Details;
            if (details == null)
            {
                return;
            }

            var duration = details.Duration;
            if (duration.HasValue)
            {
                entity.Duration = TimeSpan.FromMilliseconds(duration.Value);
            }

            entity.Effect = details.Description;
        }
    }
}