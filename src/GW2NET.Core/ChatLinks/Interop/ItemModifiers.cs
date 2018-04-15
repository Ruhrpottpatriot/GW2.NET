// <copyright file="ItemModifiers.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.ChatLinks.Interop
{
    using System;

    [Flags]
    public enum ItemModifiers : byte
    {
        None = 0,

        SuffixItem = 0x40,

        SecondarySuffixItem = 0x60,

        Skin = 0x80
    }
}