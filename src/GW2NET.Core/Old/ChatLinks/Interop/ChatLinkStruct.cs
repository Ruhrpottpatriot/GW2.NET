// <copyright file="ChatLinkStruct.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.ChatLinks.Interop
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public class ChatLinkStruct
    {
        [FieldOffset(0)]
        public Header header;

        [FieldOffset(1)]
        public Coin coin;

        [FieldOffset(1)]
        public Item item;

        [FieldOffset(1)]
        public Text text;

        [FieldOffset(1)]
        public Map map;

        [FieldOffset(1)]
        public Skill skill;

        [FieldOffset(1)]
        public Trait trait;

        [FieldOffset(1)]
        public Recipe recipe;

        [FieldOffset(1)]
        public Skin skin;

        [FieldOffset(1)]
        public Outfit outfit;
    }
}