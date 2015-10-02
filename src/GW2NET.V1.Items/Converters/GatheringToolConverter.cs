namespace GW2NET.V1.Items.Converters
{
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    public partial class GatheringToolConverter
    {
        partial void Merge(GatheringTool entity, ItemDTO dto, object state)
        {
            int defaultSkinId;
            if (int.TryParse(dto.DefaultSkin, out defaultSkinId))
            {
                entity.DefaultSkinId = defaultSkinId;
            }
        }
    }
}