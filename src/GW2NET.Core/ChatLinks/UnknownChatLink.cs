// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an unknown chat link type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.ChatLinks
{
    using System;

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

        /// <inheritdoc />
        public override string ToString()
        {
            var stream = new UnknownChatLinkConverter().Convert(this, null);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return string.Format("[&{0}]", Convert.ToBase64String(buffer));
        }
    }
}