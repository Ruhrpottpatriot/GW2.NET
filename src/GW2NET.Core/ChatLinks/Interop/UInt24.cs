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
