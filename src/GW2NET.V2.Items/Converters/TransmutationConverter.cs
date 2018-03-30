// <copyright file="TransmutationConverter.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

using System.Collections.Generic;

namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Items.Consumables;
    using Json;

    public partial class TransmutationConverter
    {
        partial void Merge(Transmutation entity, ItemDTO dto, object state)
        {
            if (dto.Details.Skins == null)
            {
                entity.SkinIds = new List<int>(0);
            }
            else
            {
                var values = new List<int>(dto.Details.Skins.Length);
                values.AddRange(dto.Details.Skins);
                entity.SkinIds = values;
            }
        }
    }
}
