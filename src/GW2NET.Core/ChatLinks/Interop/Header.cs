// <copyright file="Header.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.ChatLinks.Interop
{
    public enum Header : byte
    {
        Unknown = 0,

        Coin = 1,

        Item = 2,

        Text = 3,

        Map = 4,

        PvP = 5,

        Skill = 7,

        Trait = 8,

        Player = 9,

        Recipe = 10,

        Skin = 11,

        Outfit = 12
    }
}