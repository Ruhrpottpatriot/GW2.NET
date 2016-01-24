namespace GW2NET.ChatLinks.Interop
{
    public enum Header : byte
    {
        Unknown = 0,

        Coin = 0x01,

        Item = 0x02,

        Text = 0x03,

        Map = 0x04,

        PvP = 0x05,

        Skill = 0x06,

        Trait = 0x07,

        Recipe = 0x09,

        Skin = 0x0A,

        Outfit = 0x0B
    }
}
