// <copyright file="UnknownChatLink.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.ChatLinks
{
    using System;
    using Interop;

    /// <summary>Represents an unknown chat link type.</summary>
    public class UnknownChatLink : ChatLink
    {
        private readonly byte[] raw;

        public UnknownChatLink(byte[] raw)
        {
            if (raw == null)
            {
                throw new ArgumentNullException("raw");
            }

            this.raw = raw;
        }

        public byte[] Raw
        {
            get
            {
                return this.raw;
            }
        }

        // /// <inheritdoc />
        // public override string ToString()
        // {
        //     var stream = new UnknownChatLinkConverter().Convert(this, null);
        //     var buffer = new byte[stream.Length];
        //     stream.Read(buffer, 0, buffer.Length);
        //     return string.Format("[&{0}]", Convert.ToBase64String(buffer));
        // }
        /// <inheritdoc />
        protected override int CopyTo(ChatLinkStruct value)
        {
            throw new NotImplementedException();
        }
    }
}