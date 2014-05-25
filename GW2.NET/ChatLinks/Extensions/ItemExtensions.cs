// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemExtensions.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides static extension methods for the <see cref="Item" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.ChatLinks.Extensions
{
    using GW2DotNET.Utilities;
    using GW2DotNET.V1.Items.Details.Contracts;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>Provides static extension methods for the <see cref="Item" /> class.</summary>
    public static class ItemExtensions
    {
        /// <summary>Gets a chat link for the specified item.</summary>
        /// <param name="instance">The item.</param>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public static ChatLink GetChatLink(this Item instance)
        {
            if (instance is CombatItem)
            {
                return GetChatLink(instance as CombatItem);
            }

            Preconditions.EnsureNotNull(instance);

            return new ItemChatLink { ItemId = instance.ItemId };
        }

        /// <summary>Gets a chat link for the specified item.</summary>
        /// <param name="instance">The item.</param>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public static ChatLink GetChatLink(this CombatItem instance)
        {
            Preconditions.EnsureNotNull(instance);

            return new ItemChatLink { ItemId = instance.ItemId, SuffixItemId = instance.SuffixItemId, SecondarySuffixItemId = instance.SecondarySuffixItemId };
        }
    }
}