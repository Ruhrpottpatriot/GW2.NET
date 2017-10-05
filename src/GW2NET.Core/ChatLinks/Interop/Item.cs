// <copyright file="Item.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.ChatLinks.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Item
    {
        [FieldOffset(0)]
        public byte count;

        [FieldOffset(1)]
        public UInt24 itemId;

        [FieldOffset(4)]
        public ItemModifiers Modifiers;

        [FieldOffset(5)]
        public int modifier1;

        [FieldOffset(9)]
        public int modifier2;

        [FieldOffset(13)]
        public int modifier3;
    }
}