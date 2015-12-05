using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET.V1.Items.Converters
{
    using GW2NET.Items;
    using Json;

    public partial class TransmutationConverter
    {
        partial void Merge(Transmutation entity, ItemDTO dto, object state)
        {
            if (dto.Consumable.Skins == null)
            {
                entity.SkinIds = new List<int>(0);
            }
            else
            {
                var values = new List<int>(dto.Consumable.Skins.Length);
                values.AddRange(dto.Consumable.Skins);
                entity.SkinIds = values;
            }
        }
    }
}
