namespace GW2NET.ChatLinks.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Trait
    {
        [FieldOffset(0)]
        public int traitId;
    }
}
