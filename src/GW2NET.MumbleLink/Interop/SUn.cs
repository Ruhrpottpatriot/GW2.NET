// <copyright file="SUn.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [CLSCompliant(false)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:FieldNamesMustNotContainUnderscore", Justification = "Native types do not follow the same naming conventions.")]
    [StructLayout(LayoutKind.Explicit)]
    public struct SUn
    {
        [FieldOffset(0)]
        public SUnB S_un_b;

        [FieldOffset(0)]
        public SUnW S_un_w;

        [FieldOffset(0)]
        public uint S_addr;
    }
}