namespace GW2NET.ChatLinks.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public class ChatLinkStruct
    {
        [FieldOffset(0)]
        public Header header;

        [FieldOffset(1)]
        public Coin coin;

        [FieldOffset(1)]
        public Item item;

        [FieldOffset(1)]
        public Text text;

        [FieldOffset(1)]
        public Map map;

        [FieldOffset(1)]
        public Skill skill;

        [FieldOffset(1)]
        public Trait trait;

        [FieldOffset(1)]
        public Recipe recipe;

        [FieldOffset(1)]
        public Skin skin;

        [FieldOffset(1)]
        public Outfit outfit;
    }
}
