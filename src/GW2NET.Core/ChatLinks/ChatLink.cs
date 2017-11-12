// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for chat links.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;
    using System.Runtime.InteropServices;

    using GW2NET.ChatLinks.Interop;

    /// <summary>Provides the base class for chat links.</summary>
    public abstract class ChatLink
    {
        private static readonly int Size = Marshal.SizeOf(typeof(ChatLinkStruct));

        /// <summary>Initializes static members of the <see cref="ChatLink"/> class.</summary>
        static ChatLink()
        {
            Factory = new ChatLinkFactory();
        }

        /// <summary>
        /// Gets a reference to the factory class that provides chat link factory methods.
        /// </summary>
        public static ChatLinkFactory Factory { get; private set; }

        public sealed override string ToString()
        {
            var value = new ChatLinkStruct();
            var length = this.CopyTo(value);
            var bytes = new byte[Size];
            var ptr = Marshal.AllocHGlobal(Size);
            try
            {
                Marshal.StructureToPtr(value, ptr, false);
                Marshal.Copy(ptr, bytes, 0, Size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return string.Format("[&{0}]", Convert.ToBase64String(bytes, 0, length));
        }

        /// <summary>Copies the current instance to a data structure for serialization. A return value indicates the number of bytes copied.</summary>
        /// <param name="value">An object to copy values to.</param>
        /// <returns>The number of significant bytes in the data structure after copying.</returns>
        protected abstract int CopyTo(ChatLinkStruct value);
    }
}