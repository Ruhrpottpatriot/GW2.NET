using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2NET.ChatLinks
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    internal struct ChatLinkDataContract
    {
        [FieldOffset(0)]
        internal byte header;

        [FieldOffset(0)]
        internal CoinData CoinData;

        [FieldOffset(0)]
        internal ItemData ItemData;


    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct CoinData
    {
        [FieldOffset(1)]
        internal int Count;
    }

    [StructLayout(LayoutKind.Explicit, Size = 7)]
    internal struct ItemData
    {
        [FieldOffset(1)]
        internal byte count;

        [FieldOffset(2)]
        internal int id;

        [FieldOffset(5)]
        internal byte flags;

        [FieldOffset(6)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        internal int[] modifiers;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct TextData
    {
        [FieldOffset(1)]
        internal int Id;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MapData
    {
        [FieldOffset(1)]
        internal int Id;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MatchData 
    {
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct SkillData
    {
        [FieldOffset(1)]
        internal int Id;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct TraitData
    {
        [FieldOffset(1)]
        internal int Id;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct PlayerData
    {
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct RecipeData
    {
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct SkinData
    {
        [FieldOffset(1)]
        internal int Id;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct OutfitData
    {
        [FieldOffset(1)]
        internal int Id;
    }
}
