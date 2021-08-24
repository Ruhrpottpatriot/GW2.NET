// <copyright file="MumbleContext.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.MumbleLink.Interop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    [CLSCompliant(false)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter", Justification = "Native types do not follow the same naming conventions.")]
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

        [FieldOffset(48)]
        public uint uiState;

        [FieldOffset(52)]
        public ushort compassWidth;

        [FieldOffset(54)]
        public ushort compassHeight;

        [FieldOffset(56)]
        public float compassRotation;

        [FieldOffset(60)]
        public float playerX;

        [FieldOffset(64)]
        public float playerY;

        [FieldOffset(68)]
        public float mapCenterX;

        [FieldOffset(72)]
        public float mapCenterY;

        [FieldOffset(76)]
        public float mapScale;

        [FieldOffset(80)]
        public uint processId;

        [FieldOffset(84)]
        public byte mountIndex;

    }
}