namespace GW2NET.ChatLinks.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Item
    {
        [FieldOffset(0)]
        public byte count;

        [FieldOffset(1)]
        public UInt24 itemId;

        [FieldOffset(4)]
        public ItemModifiers Modifiers;

        [FieldOffset(5)]
        public int modifier1;

        [FieldOffset(9)]
        public int modifier2;

        [FieldOffset(13)]
        public int modifier3;
    }
}
