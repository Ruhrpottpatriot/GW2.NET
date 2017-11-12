// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CombatBuff.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an item's combat buff.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using GW2NET.ChatLinks;

    /// <summary>Represents an item's combat buff.</summary>
    public class CombatBuff
    {
        /// <summary>Gets or sets the buff's description.</summary>
        public virtual string Description { get; set; }

        /// <summary>Gets or sets the buff's skill identifier.</summary>
        public virtual int? SkillId { get; set; }

        /// <summary>Gets a skill chat link for this item buff.</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public virtual ChatLink GetSkillChatLink()
        {
            var skill = this.SkillId;
            if (!skill.HasValue)
            {
                return null;
            }

            return new SkillChatLink
            {
                SkillId = skill.Value
            };
        }
    }
}
