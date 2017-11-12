namespace GW2NET.MumbleLink.Interop
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
        Justification = "Native types do not follow the same naming conventions.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
        Justification = "Native types do not follow the same naming conventions.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore",
        Justification = "Native types do not follow the same naming conventions.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AvatarDataContract
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
}
