// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MumbleLinkFile.Interop.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Contains interoperability types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.MumbleLink
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>Contains interoperability types.</summary>
    public partial class MumbleLinkFile
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
            Justification = "Native types do not follow the same naming conventions.")]
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
            Justification = "Native types do not follow the same naming conventions.")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct InAddr
        {
            internal SUn S_un;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
            Justification = "Native types do not follow the same naming conventions.")]
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
            Justification = "Native types do not follow the same naming conventions.")]
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

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1308:VariableNamesMustNotBePrefixed", 
            Justification = "Native types do not follow the same naming conventions.")]
        [StructLayout(LayoutKind.Sequential)]

        // ReSharper disable once InconsistentNaming
        internal struct SUnB
        {
            internal byte s_b1;

            internal byte s_b2;

            internal byte s_b3;

            internal byte s_b4;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1308:VariableNamesMustNotBePrefixed", 
            Justification = "Native types do not follow the same naming conventions.")]
        [StructLayout(LayoutKind.Sequential)]

        // ReSharper disable once InconsistentNaming
        internal struct SUnW
        {
            internal ushort s_w1;

            internal ushort s_w2;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
            Justification = "Native types do not follow the same naming conventions.")]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct Sockaddr
        {
            internal ushort sa_family;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            internal string sa_data;
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", 
            Justification = "Native types do not follow the same naming conventions.")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", 
            Justification = "Native types do not follow the same naming conventions.")]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        internal struct SockaddrIn
        {
            internal short sin_family;

            internal ushort sin_port;

            internal InAddr sin_addr;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
            internal string sin_zero;
        }
    }
}