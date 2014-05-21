// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for chat links.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Provides the base class for chat links.</summary>
    public abstract class ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="ChatLink"/> class.</summary>
        /// <param name="type">The chat link type.</param>
        protected ChatLink(ChatLinkType type)
        {
            this.Type = type;
        }

        /// <summary>Gets the chat link type.</summary>
        public ChatLinkType Type { get; private set; }

        /// <summary>Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</summary>
        /// <returns>A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.</returns>
        public override string ToString()
        {
            return string.Format("[&{0}]", Convert.ToBase64String(this.GetBytes()));
        }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected abstract byte[] GetBytes();
    }
}