namespace GW2NET.MumbleLink.Interop
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
        Justification = "Native types do not follow the same naming conventions.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
        Justification = "Native types do not follow the same naming conventions.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1308:VariableNamesMustNotBePrefixed", 
        Justification = "Native types do not follow the same naming conventions.")]
    [StructLayout(LayoutKind.Sequential)]

    // ReSharper disable once InconsistentNaming
    public struct SUnB
    {
        public byte s_b1;

        public byte s_b2;

        public byte s_b3;

        public byte s_b4;
    }
}