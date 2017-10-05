// <copyright file="UInt24.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.ChatLinks.Interop
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct UInt24
    {
        public UInt24(uint value)
        {
            var b = BitConverter.GetBytes(value);
            this._b0 = b[0];
            this._b1 = b[1];
            this._b2 = b[2];
        }

        private readonly byte _b0;

        private readonly byte _b1;

        private readonly byte _b2;

        public uint Value
        {
            get
            {
                return (uint)(this._b0 | (this._b1 << 8) | (this._b2 << 16));
            }
        }
    }
}