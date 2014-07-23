// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemBuffExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="ItemBuffContract" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.ChatLinks.Extensions
{
    using GW2DotNET.Items;
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Items.Contracts;

    /// <summary>Provides static extension methods for the <see cref="ItemBuffContract" /> class.</summary>
    public static class ItemBuffExtensions
    {
        /// <summary>Gets a skill chat link for the specified item buff.</summary>
        /// <param name="instance">The item buff.</param>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public static ChatLink GetSkillChatLink(this ItemBuff instance)
        {
            Preconditions.EnsureNotNull(paramName: "instance", value: instance);
            return new SkillChatLink { SkillId = instance.SkillId };
        }
    }
}