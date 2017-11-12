namespace GW2NET.ChatLinks.Interop
{
    using System;

    [Flags]
    public enum ItemModifiers : byte
    {
        None = 0,

        SuffixItem = 0x40,

        SecondarySuffixItem = 0x60,

        Skin = 0x80
    }
}
