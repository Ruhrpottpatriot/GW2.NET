namespace GW2DotNET.MumbleLink
{
    using System;
    using System.Runtime.InteropServices;

    public partial class MumbleLinkFile
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct AvatarDataContract
        {
            internal uint uiVersion;
            internal uint uiTick;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            internal float[] fAvatarPosition;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            internal float[] fAvatarFront;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            internal float[] fAvatarTop;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal string name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            internal float[] fCameraPosition;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            internal float[] fCameraFront;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            internal float[] fCameraTop;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            internal string identity;
            internal uint context_len;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            internal byte[] context;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
            internal string description;
        }

        [StructLayout(LayoutKind.Explicit, Size = 256)]
        internal struct MumbleContext
        {
            [FieldOffset(0)]
            internal SockaddrIn serverAddress;

            [FieldOffset(28)]
            internal uint mapId;

            [FieldOffset(32)]
            internal uint mapType;

            [FieldOffset(36)]
            internal uint shardId;

            [FieldOffset(40)]
            internal uint instance;

            [FieldOffset(44)]
            internal uint buildId;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct SockaddrIn
        {
            internal short sin_family;

            internal ushort sin_port;

            internal InAddr sin_addr;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            internal string sin_zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct InAddr
        {
            internal SUn S_un;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct SUn
        {
            [FieldOffset(0)]
            internal SUnB S_un_b;

            [FieldOffset(0)]
            internal SUnW S_un_w;

            [FieldOffset(0)]
            internal uint S_addr;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SUnB
        {
            internal byte s_b1;

            internal byte s_b2;

            internal byte s_b3;

            internal byte s_b4;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SUnW
        {
            internal ushort s_w1;

            internal ushort s_w2;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct Sockaddr
        {
            internal ushort sa_family;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            internal string sa_data;
        }
    }
}
