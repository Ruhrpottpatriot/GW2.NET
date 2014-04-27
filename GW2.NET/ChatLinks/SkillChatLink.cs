// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkillChatLink.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a chat link that links to a skill.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks
{
    using System;

    /// <summary>Represents a chat link that links to a skill.</summary>
    public class SkillChatLink : ChatLink
    {
        /// <summary>Initializes a new instance of the <see cref="SkillChatLink"/> class.</summary>
        /// <param name="skillId">The skill identifier.</param>
        public SkillChatLink(int skillId)
            : base(ChatLinkType.Skill)
        {
            this.SkillId = skillId;
        }

        /// <summary>Gets the skill identifier.</summary>
        public int SkillId { get; private set; }

        /// <summary>Gets the bytes.</summary>
        /// <returns>The <see cref="byte" /> array.</returns>
        protected override byte[] GetBytes()
        {
            var buffer = new byte[5];
            Buffer.SetByte(buffer, 0, (byte)this.Type);
            Buffer.BlockCopy(BitConverter.GetBytes(this.SkillId), 0, buffer, 1, 4);
            return buffer;
        }
    }
}