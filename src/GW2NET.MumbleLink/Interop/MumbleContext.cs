namespace GW2NET.MumbleLink.Interop
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
        Justification = "Native types do not follow the same naming conventions.")]
    [StructLayout(LayoutKind.Explicit, Size = 256)]
    public struct MumbleContext
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
}