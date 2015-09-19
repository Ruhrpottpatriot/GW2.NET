namespace GW2NET.MumbleLink.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [CLSCompliant(false)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
        Justification = "Native types do not follow the same naming conventions.")]
    [StructLayout(LayoutKind.Explicit, Size = 256)]
    public struct MumbleContext
    {
        [FieldOffset(0)]
        public SockaddrIn serverAddress;

        [FieldOffset(28)]
        public uint mapId;

        [FieldOffset(32)]
        public uint mapType;

        [FieldOffset(36)]
        public uint shardId;

        [FieldOffset(40)]
        public uint instance;

        [FieldOffset(44)]
        public uint buildId;
    }
}