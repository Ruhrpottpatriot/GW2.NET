namespace GW2NET.MumbleLink.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [CLSCompliant(false)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
        Justification = "Native types do not follow the same naming conventions.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
        Justification = "Native types do not follow the same naming conventions.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Sockaddr
    {
        public ushort sa_family;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string sa_data;
    }
}