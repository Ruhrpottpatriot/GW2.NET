using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2NET.V2.Items.Converters
{
    using GW2NET.Items;
    using Json;

    public partial class MiniatureConverter
    {
        partial void Merge(Miniature entity, ItemDTO dto, object state)
        {
            entity.MiniatureId = dto.Details.MiniPetId;
        }
    }
}
