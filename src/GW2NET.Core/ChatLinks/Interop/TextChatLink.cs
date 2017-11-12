namespace GW2NET.ChatLinks.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Text
    {
        [FieldOffset(0)]
        public int dialogId;
    }
}
