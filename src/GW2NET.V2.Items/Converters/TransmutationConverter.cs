using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Items;
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
