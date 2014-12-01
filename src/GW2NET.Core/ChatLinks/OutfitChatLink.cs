// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OutfitChatLink.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to an outfit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to an outfit.</summary>
    public class OutfitChatLink : ChatLink
    {
        /// <summary>Gets or sets the outfit identifier.</summary>
        public int OutfitId { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            var stream = new ConverterForOutfitChatLink().Convert(this);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return string.Format("[&{0}]", Convert.ToBase64String(buffer));
        }
    }
}