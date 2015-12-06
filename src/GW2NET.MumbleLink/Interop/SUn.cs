namespace GW2NET.MumbleLink.Interop
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore",
        Justification = "Native types do not follow the same naming conventions.")]
    [StructLayout(LayoutKind.Explicit)]
    public struct SUn
    {
        [FieldOffset(0)]
        internal SUnB S_un_b;

        [FieldOffset(0)]
        internal SUnW S_un_w;

        [FieldOffset(0)]
        internal uint S_addr;
    }
}