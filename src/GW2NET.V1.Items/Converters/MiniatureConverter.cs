using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET.V1.Items.Converters
{
    using GW2NET.Items;
    using Json;

    public partial class MiniatureConverter
    {
        partial void Merge(Miniature entity, ItemDTO dto, object state)
        {
            if (dto.MiniPet != null)
            {
                entity.MiniatureId = dto.MiniPet.MiniPetId;
            }
        }
    }
}
